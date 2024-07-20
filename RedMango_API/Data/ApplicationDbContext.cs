using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Models;
using Microsoft.Extensions.Configuration;
namespace RedMango_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ShopingCart> ShopingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>()
               .HasOne(ci => ci.MenuItem)
               .WithMany()
               .HasForeignKey(ci => ci.MenuItemId)
               .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення
            // Налаштування зв'язків між CartItem та ShopingCart
            modelBuilder.Entity<CartItem>()
                .HasOne<ShopingCart>()
                .WithMany(sc => sc.CartItems)
                .HasForeignKey(ci => ci.ShopingCartId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            // Налаштування зв'язків між OrderHeader та ApplicationUser
            modelBuilder.Entity<OrderHeader>()
                .HasOne(oh => oh.User)
                .WithMany()
                .HasForeignKey(oh => oh.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            // Налаштування зв'язків між OrderDetails та MenuItem
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.MenuItem)
                .WithMany()
                .HasForeignKey(od => od.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            // Налаштування зв'язків між OrderDetails та OrderHeader
            modelBuilder.Entity<OrderDetails>()
                .HasOne<OrderHeader>()
                .WithMany(oh => oh.OrderDetails)
                .HasForeignKey(od => od.OrderHeaderId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    Id = 1,
                    Name = "Spring Roll",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/spring roll.jpg",
                    Price = 7.99,
                    Category = "Appetizer",
                    SpecialTag = ""
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Idli",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/idli.jpg",
                    Price = 8.99,
                    Category = "Appetizer",
                    SpecialTag = ""
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Panu Puri",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque масса auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/pani puri.jpg",
                    Price = 8.99,
                    Category = "Appetizer",
                    SpecialTag = "Best Seller"
                },
                new MenuItem
                {
                    Id = 4,
                    Name = "Hakka Noodles",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/hakka noodles.jpg",
                    Price = 10.99,
                    Category = "Entrée",
                    SpecialTag = ""
                },
                new MenuItem
                {
                    Id = 5,
                    Name = "Malai Kofta",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/malai kofta.jpg",
                    Price = 12.99,
                    Category = "Entrée",
                    SpecialTag = "Top Rated"
                },
                new MenuItem
                {
                    Id = 6,
                    Name = "Paneer Pizza",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/paneer pizza.jpg",
                    Price = 11.99,
                    Category = "Entrée",
                    SpecialTag = ""
                },
                new MenuItem
                {
                    Id = 7,
                    Name = "Paneer Tikka",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque масса auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/paneer tikka.jpg",
                    Price = 13.99,
                    Category = "Entrée",
                    SpecialTag = "Chef's Special"
                },
                new MenuItem
                {
                    Id = 8,
                    Name = "Carrot Love",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque масса auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/carrot love.jpg",
                    Price = 4.99,
                    Category = "Dessert",
                    SpecialTag = ""
                },
                new MenuItem
                {
                    Id = 9,
                    Name = "Rasmalai",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque масса auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/rasmalai.jpg",
                    Price = 4.99,
                    Category = "Dessert",
                    SpecialTag = "Chef's Special"
                },
                new MenuItem
                {
                    Id = 10,
                    Name = "Sweet Rolls",
                    Description = "Fusc tincidunt maximus leo, sed scelerisque масса auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    Image = "https://redmangoimages2024.blob.core.windows.net/redmango/sweet rolls.jpg",
                    Price = 3.99,
                    Category = "Dessert",
                    SpecialTag = "Top Rated"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _configuration.GetConnectionString("DefaultDbConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            }
        }
    }
}
