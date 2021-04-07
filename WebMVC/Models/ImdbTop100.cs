using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class ImdbTop100
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string RankUpDown { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public string Crew { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbRatingCount { get; set; }
    }
}
