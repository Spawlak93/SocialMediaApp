using SocialMediaApp.Server.Data;
using SocialMediaApp.Server.Models;
using SocialMediaApp.Shared.CommentModels;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private string _userId;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReplyAsync(CommentCreate model)
        {
            var commentEntity = new Comment
            {
                Content = model.Content,
                OwnerId = _userId,
                PostId = model.PostId,
            };

            _context.Add(commentEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<CommentDetail> GetReplyById(int replyId)
        {
            throw new System.NotImplementedException();
        }

        public void SetUserId(string userId) => _userId = userId;

    }
}
