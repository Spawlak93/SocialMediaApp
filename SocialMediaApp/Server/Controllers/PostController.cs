using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Server.Services.PostServices;
using SocialMediaApp.Shared.PostModels;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            SetUserIdInService();

            return Ok(await _postService.GetAllPostsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            SetUserIdInService();


            var post = await _postService.GetPostByIdAsync(id);
            if (post == null) return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreate model)
        {
            SetUserIdInService();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model == null) return BadRequest();

            bool success = await _postService.CreatePostAsync(model);

            if (success) return Ok();
            return UnprocessableEntity();
        }


        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null) return false;
            _postService.SetUserId(userId);
            return true;
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIdClaim == null) return null;
            return userIdClaim;
        }
    }
}
