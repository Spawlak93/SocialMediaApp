using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Shared.PostModels
{
    public class PostDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? UpdatedUtc { get; set; }

        public ICollection<CommentModels.CommentDetail> Comments { get; set; } = new List<CommentModels.CommentDetail>();

        public ICollection<ReplyModels.ReplyDetail> Replies { get; set; } = new List<ReplyModels.ReplyDetail>();

    }
}
