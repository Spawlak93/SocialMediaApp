using SocialMediaApp.Server.Data;
using SocialMediaApp.Server.Models;
using SocialMediaApp.Shared.ReplyModels;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.ReplyServices
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _context;
        private string _userId;

        public ReplyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReplyAsync(ReplyCreate model)
        {
            var ReplyEntity = new Reply
            {
                CommentId = model.CommentId,
                Content = model.Content,
                PostId = model.PostId,
                OwnerId = _userId
            };

            _context.Replies.Add(ReplyEntity);

            return await _context.SaveChangesAsync() == 1;
        }

        public Task<ReplyDetail> GetReplyById(int replyId)
        {
            throw new System.NotImplementedException();
        }

        public void SetUserId(string userId) => _userId = userId;

    }
}
