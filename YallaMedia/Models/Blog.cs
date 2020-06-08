using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaMedia.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }
    }
}
