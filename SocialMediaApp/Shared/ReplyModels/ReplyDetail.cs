using SocialMediaApp.Shared.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Shared.ReplyModels
{
    public class ReplyDetail : CommentDetail
    {
        public int CommentId { get; set; }
    }
}
