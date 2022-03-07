using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Server.Data;
using SocialMediaApp.Server.Models;
using SocialMediaApp.Shared.CommentModels;
using SocialMediaApp.Shared.Post;
using SocialMediaApp.Shared.PostModels;
using SocialMediaApp.Shared.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private string _userId;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePostAsync(PostCreate model)
        {
            var PostEntity = new Post
            {
                Title = model.Title,
                Content = model.Body,
                OwnerId = _userId,
                CreatedUtc = System.DateTimeOffset.Now,

            };
            _context.Posts.Add(PostEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
        {
            var postList = await _context.Posts.Include(p => p.Comments).Select(p => new PostListItem
            {
                Id = p.Id,
                Title = p.Title,
                NumberOfComments = p.Comments.Count,
                Preview = p.Content.Length <= 50 ? p.Content : p.Content.Take(50).ToString() + "..."
            }).ToListAsync();

            return postList;
        }

        public async Task<PostDetail> GetPostByIdAsync(int postId)
        {
            var postEntity = await _context
                .Posts
                .FirstOrDefaultAsync(p => postId == p.Id);

            var userEntity = postEntity.User;
            var commments = postEntity.Comments.ToList();

            if (postEntity is null)
                return null;

            var detail = new PostDetail
            {
                Id = postEntity.Id,
                Content = postEntity.Content,
                Title = postEntity.Title,
                CreatedUtc = postEntity.CreatedUtc,
                UpdatedUtc = postEntity.UpdatedUtc,
                UserName = userEntity.UserName,
                Comments = commments.Where(c => c is not Reply).ToList().Select(c =>
                {
                    var commentDetail = new CommentDetail
                    {
                        Id = c.Id,
                        Content = c.Content,
                        PostId = c.Id,
                        UserName = c.UserName,
                        Replies = AddReplies(c.Replies)
                    };
                    return commentDetail;
                }).ToList()
            };

            //foreach (Comment comment in commments)
            //{
            //    if (comment is Reply)
            //        continue;
            //    var commentDetail = new CommentDetail
            //    {
            //        Id = comment.Id,
            //        Content = comment.Content,
            //        PostId = comment.Id,
            //        UserName = comment.UserName,
            //        Replies = AddReplies(comment.Replies)
            //    };


            //}

            return detail;
        }

        private ICollection<ReplyDetail> AddReplies(ICollection<Reply> replies)
        {
            if (replies.Count == 0)
                return new List<ReplyDetail>();

            var detailedReplies = new List<ReplyDetail>();

            foreach(var reply in replies)
            {
                var detailedReply = new ReplyDetail
                {
                    Id = reply.Id,
                    CommentId = reply.CommentId,
                    Content = reply.Content,
                    PostId = reply.PostId,
                    UserName = reply.UserName,
                    Replies = AddReplies(reply.Replies)
                };
                detailedReplies.Add(detailedReply);
            }

            return detailedReplies;
        }

        public void SetUserId(string userId) => _userId = userId;
    }
}
