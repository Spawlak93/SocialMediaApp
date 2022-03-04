using SocialMediaApp.Shared.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Shared.CommentModels
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int NumberOfReplies { get => Replies.Count; }
        public ICollection<ReplyDetail> Replies { get; set; } = new List<ReplyDetail>();
    }
}
