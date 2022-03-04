using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Server.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }

    public class Reply : Comment
    {
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
