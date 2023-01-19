using Microsoft.AspNetCore.Mvc;
using MVC_RestaurentApp.Data;
using MVC_RestaurentApp.Models;

namespace MVC_RestaurentApp.Controllers
{
    public class RestaurentController : Controller
    {
        private MVCDemoDBContext mvcDemoDbContext;
        public RestaurentController(MVCDemoDBContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dishes = mvcDemoDbContext.Dishes.ToList();

            return View(dishes);
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var dish = mvcDemoDbContext.Dishes.FirstOrDefault(x => x.DishId == id);
            if (dish != null)
            {
                var viewModel = new UpdateDishViewModel()
                {
                    DishId = dish.DishId,
                    DishName = dish.DishName,
                    Description = dish.Description,
                    Quantity = dish.Quantity,
                    Price = dish.Price,
                    Image= dish.Image,
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveView(UpdateDishViewModel model)
        {
            var dish = mvcDemoDbContext.Dishes.Find(model.DishId);
            if (dish != null)
            {
                dish.DishName = model.DishName;
                dish.Description = model.Description;
                dish.DishId = model.DishId;
                dish.Price = model.Price;
                dish.Quantity = model.Quantity;
                dish.Image = model.Image;

                mvcDemoDbContext.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Add(AddRestaurentViewModel model)
        {
            var Dishes = new Dishes()
            {
                DishId = Guid.NewGuid(),
                DishName = model.DishName,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                Image = model.Image
            };
            mvcDemoDbContext.Dishes.Add(Dishes);
            mvcDemoDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(UpdateDishViewModel model)
        {
            var dish = mvcDemoDbContext.Dishes.Find(model.DishId);
            if (dish != null)
            {
                mvcDemoDbContext.Remove(dish);
                mvcDemoDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
