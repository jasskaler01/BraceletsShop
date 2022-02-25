using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BraceletsShop.Models
{
    public class Bracelet
    {
        public int ID { get; set; }
        public string Category { get; set; }

        public string Material { get; set; }

        public DateTime  CollectionDate { get; set; }

        public decimal Price { get; set; }

        public decimal Rating { get; set; }

    }
}
