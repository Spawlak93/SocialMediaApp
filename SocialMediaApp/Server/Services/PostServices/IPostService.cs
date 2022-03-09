using SocialMediaApp.Shared.PostModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Services.PostServices
{
    public interface IPostService
    {
        Task<IEnumerable<PostListItem>> GetAllPostsAsync();

        Task<bool> CreatePostAsync(PostCreate model);

        Task<PostDetail> GetPostByIdAsync(int postId);

        //Update TODO

        //Delete TODO

        void SetUserId(string userId);
    }
}
