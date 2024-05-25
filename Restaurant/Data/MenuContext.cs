using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Restaurant.Models;

    namespace Restaurant.Data
{
    public class MenuContext:DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Summer Salad", Price = 11.99, ImageUrl = "blob:chrome-untrusted://image-magnify/7c71590e-e99b-4b2d-9482-1b041bd71408" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomatoes" },
                new Ingredient { Id = 2, Name = "Cheese" },
                new Ingredient { Id = 3, Name = "Cucumbers" },
                new Ingredient { Id = 4, Name = "Olives" },
                new Ingredient { Id = 5, Name = "Marinated fefferoni peppers" }
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}

        public DbSet<DishIngredient> DishIngredients { get; set; } 
    }
}
