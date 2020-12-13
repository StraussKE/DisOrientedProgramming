using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisOrientedProgramming.Models
{
    public class ResourceViewModel
    {
        public string ResourceName { get; set; }

        public string ResourceType { get; set; }

        public Uri Address { get; set; }

        public string Description { get; set; }

    }
}
