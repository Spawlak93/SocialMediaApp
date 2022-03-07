using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Server.Services.CommentServices;
using SocialMediaApp.Shared.CommentModels;
using System.Threading.Tasks;

namespace SocialMediaApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreate model)
        {
            if (model == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool success = await _service.CreateReplyAsync(model);

            if (success)
                return Ok();
            return UnprocessableEntity();
        }

    }
}
