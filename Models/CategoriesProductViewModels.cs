using NorthWind.Models;

namespace NorthwindStore.Models
{
    public class CategoriesProductViewModels
    {
        public IEnumerable<Categories> Categories { get; set; } = [];
        public IEnumerable<Products> Products { get; set; } = [];
    }
}
