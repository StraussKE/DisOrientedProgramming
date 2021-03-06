﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
    public class ForumPost
    {
        [Key]
        public Guid ForumPostId { get; set; }
        public virtual AppUser User { get; set; }

        [Required(ErrorMessage = "Title your post! (30 character max)"), MaxLength(30)]
        public string PostTitle { get; set; }

        [Required(ErrorMessage = "Say something!")]
        public string PostText { get; set; }

        public DateTime TimePosted { get; set; }

        public virtual ForumTopic Topic { get; set; }

        //this is used to track if this post is in response to a diff forum post
        public virtual ForumPost ParentPost { get; set; }

        //this is used to track responses
        public virtual List<ForumPost> Responses { get; set; }
    }
}
