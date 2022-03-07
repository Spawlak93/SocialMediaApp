using SocialMediaApp.Shared.CommentModels;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.CommentServices
{
    public interface ICommentService
    {
        //Task<IEnumerable<ReplyListItem>> GetAllReplies();

        Task<bool> CreateReplyAsync(CommentCreate model);

        Task<CommentDetail> GetReplyById(int replyId);

        //Update TODO

        //Delete TODO

        void SetUserId(string userId);
    }
}
