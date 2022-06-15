using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AmlexTradeWeb.Models
{
    public class ForumDB : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<BoughtItem> BoughtItems { get; set; }
        public DbSet<BoughtCar> BoughtCars { get; set; }

        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<Command> Commands { get; set; }
        public ForumDB(DbContextOptions<ForumDB> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}


