using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
    public class ForumPost
    {
        AppUser User { get; set; }

        string PostTitle { get; set; }

        string PostText { get; set; }

        //this is used to track if this post is in response to a diff forum post
        ForumPost ParentPost { get; set; }

        //this is used to track responses
        List<ForumPost> Responses { get; set; }
    }
}
