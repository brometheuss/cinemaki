using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class ImdbTop100Response
    {
        public IEnumerable<ImdbTop100> Items { get; set; } = new List<ImdbTop100>();
        public string ErrorMessage { get; set; }
    }
}
