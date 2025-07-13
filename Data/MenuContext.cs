using Microsoft.EntityFrameworkCore;
using FoodMenu.Models;



namespace FoodMenu.Data
{
    public class MenuContext : DbContext
    {




        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {



        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DishIngredient>().HasKey(di => new { di.DishId, di.IngredientId });



            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);





            modelBuilder.Entity<Dish>().HasData(
                
            
                new Dish { Id = 1, Name = "Tonkotsu Ramen" , Price = 20.65 , ImageUrl = "https://noodleplanet.co.kr/wp-content/uploads/2024/10/webzine-10-story-2-1.jpg" }
                
                
            );


            modelBuilder.Entity<Ingredient>().HasData(


                new Ingredient { Id = 1, Name = "Chashu Pork" },
                new Ingredient { Id = 2, Name = "Ramen Eggs" },
                new Ingredient { Id = 3, Name = "Green Onions" }



            );




            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 3 }
            );





            base.OnModelCreating(modelBuilder);
        }




        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<DishIngredient> DishIngredients { get; set; }













    }
}
