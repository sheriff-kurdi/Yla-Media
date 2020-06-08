using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YallaMedia.ViewModels
{
    public class BlogCreateVM
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageBinary { get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }

    }
}
