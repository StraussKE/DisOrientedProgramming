using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
    public class ForumPost
    {
        public int ForumPostId { get; set; }
        public AppUser User { get; set; }

        public string PostTitle { get; set; }

        public string PostText { get; set; }

        public ForumTopic Topic { get; set; }

        //this is used to track if this post is in response to a diff forum post
        public ForumPost ParentPost { get; set; }

        //this is used to track responses
        public List<ForumPost> Responses { get; set; }
    }
}
