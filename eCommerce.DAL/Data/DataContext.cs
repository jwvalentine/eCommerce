using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// you can either pass the NAME of a conenction string (e.g. from a web.config), and explicitly delcare it.
        /// </summary>
        public DataContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// any entity to be persisted must me delcared here.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
