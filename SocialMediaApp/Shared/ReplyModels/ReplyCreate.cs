using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Shared.ReplyModels
{
    public class ReplyCreate : CommentModels.CommentCreate
    {
        public int CommentId { get; set; }
    }
}
