﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BlogType : BaseEntity
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}