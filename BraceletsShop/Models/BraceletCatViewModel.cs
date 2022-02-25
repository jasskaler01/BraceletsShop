using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BraceletsShop.Models
{
    public class BraceletCatViewModel
    {
        public List<Bracelet> Bracelets { get; set; }
        public SelectList Category { get; set; }
        public string BraceletCat { get; set; }
        public string SearchString { get; set; }
    }
}
