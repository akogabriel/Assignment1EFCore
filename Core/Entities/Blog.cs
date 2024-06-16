using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Blog : BaseEntity
    {

        public string Url { get; set; }
        public bool IsPublic { get; set; }

        public int BlogTypeId { get; set; }
        public BlogType BlogType { get; set; }

        public List<Post> Posts { get; set; }

    }
}
