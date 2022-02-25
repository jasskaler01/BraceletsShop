using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BraceletsShop.Models;

namespace BraceletsShop.Data
{
    public class BraceletsShopContext : DbContext
    {
        public BraceletsShopContext (DbContextOptions<BraceletsShopContext> options)
            : base(options)
        {
        }

        public DbSet<BraceletsShop.Models.Bracelet> Bracelet { get; set; }
    }
}
