using SocialMediaApp.Shared.ReplyModels;
using System.Collections;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.ReplyServices
{
    public interface IReplyService
    {
        //Task<IEnumerable<ReplyListItem>> GetAllReplies();

        Task<bool> CreateReplyAsync(ReplyCreate model);

        Task<ReplyDetail> GetReplyById(int replyId);

        //Update TODO

        //Delete TODO
        void SetUserId(string userId);
    }
}
