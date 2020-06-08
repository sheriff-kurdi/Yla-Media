using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YallaMedia.Models;

namespace YallaMedia.ViewModels
{
    public class BlogUpdateVM : Blog
    {
        [Display(Name = "Image")]

        public IFormFile ImageBinary { get; set; }

    }
}
