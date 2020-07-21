using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Services;

namespace OnlineShop_AspNetCore_RazorPages.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = (categoryService.GetCategoriesAsync()).Result;
            return View(categories);
        }
    }
}
