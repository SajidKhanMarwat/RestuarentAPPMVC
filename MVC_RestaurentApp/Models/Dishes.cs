using System.ComponentModel.DataAnnotations;

namespace MVC_RestaurentApp.Models
{
    public class Dishes
    {
        [Key]
        public Guid DishId { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }




    }
}
