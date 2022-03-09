using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Shared.PostModels
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
        public int NumberOfComments { get; set; }
    }
}
