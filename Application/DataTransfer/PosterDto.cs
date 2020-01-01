using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PosterDto
    {
        public string PosterTitle { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public IFormFile Image { get; set; }
    }
}
