using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
    public class ForumTopic
    {
        public Guid ForumTopicId { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        //this is a very meh way of doing this
        //using this numebr to keep the topics in order
        public int OrderNumber { get; set; }
    }
}
