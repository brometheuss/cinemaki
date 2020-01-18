using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PosterDto
    {
        public int Id { get; set; }
        public string PosterTitle { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public IFormFile Image { get; set; }
    }
}
