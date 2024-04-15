using Microsoft.EntityFrameworkCore;
using System.Data;
using VendingMachine.DBContext.Models;

namespace VendingMachine.DBContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Drink> Drinks => Set<Drink>();
        public DbSet<Coin> Coins => Set<Coin>();
        //public DbSet<Models.VendingMachine> VendingMachine => Set<Models.VendingMachine>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Models.VendingMachine vendingMachine = new() { VendingMachineId = 1 };

            Coin coin1 = new Coin() { CoinId = 1, Value = 1, IsBlocked = false, Amount = 0, VendingMachineId = vendingMachine.VendingMachineId};
            Coin coin2 = new Coin() { CoinId = 2, Value = 2, IsBlocked = false, Amount = 0, VendingMachineId = vendingMachine.VendingMachineId};
            Coin coin3 = new Coin() { CoinId = 3, Value = 5, IsBlocked = false, Amount = 0, VendingMachineId = vendingMachine.VendingMachineId};
            Coin coin4 = new Coin() { CoinId = 4, Value = 10, IsBlocked = false, Amount = 0, VendingMachineId = vendingMachine.VendingMachineId};

            var teaImagePath = Path.Combine("img", "Tea.png");
            var coffeeImagePath = Path.Combine("img", "Coffee.png");
            var waterImagePath = Path.Combine("img", "Water.png");
            Drink tea = new Drink() { DrinkId = 1, Name = "Tea", Cost = 5, Amount = 3, IMGPath = teaImagePath, VendingMachineId = vendingMachine.VendingMachineId };
            Drink coffee = new Drink() { DrinkId = 2, Name = "Coffee", Cost = 10, Amount = 3, IMGPath = coffeeImagePath, VendingMachineId = vendingMachine.VendingMachineId };
            Drink water = new Drink() { DrinkId = 3, Name = "Water", Cost = 3, Amount = 3, IMGPath = waterImagePath, VendingMachineId = vendingMachine.VendingMachineId };

            modelBuilder.Entity<Models.VendingMachine>().HasData([vendingMachine]);
            modelBuilder.Entity<Coin>().HasData([coin1, coin2, coin3, coin4]);
            modelBuilder.Entity<Drink>().HasData([tea, coffee, water]);

            modelBuilder.Entity<Models.VendingMachine>();
            modelBuilder.Entity<Coin>().HasOne(x => x.VendingMachine).WithMany(x => x.Coins).HasForeignKey(x => x.VendingMachineId);
            modelBuilder.Entity<Drink>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
