﻿using Microsoft.AspNetCore.Mvc;
using FoodMenu.Data;
using FoodMenu.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodMenu.Controllers
{
    public class FoodMenu : Controller
    {

        private readonly MenuContext _context;
        public FoodMenu(MenuContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes
                          select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }  
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _context.Dishes.Include(di => di.DishIngredients).ThenInclude(i => i.Ingredient).FirstOrDefaultAsync(x => x.Id == id);

            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);

        }
    }
}
