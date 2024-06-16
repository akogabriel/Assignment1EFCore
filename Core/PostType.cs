﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PostType
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Post> Posts { get; set;}
    }
}