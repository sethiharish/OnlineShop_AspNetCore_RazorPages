using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Data.Services;
using OnlineShop.Entities;

namespace OnlineShop_AspNetCore_RazorPages.Pages.Pies
{
    public class ListModel : PageModel
    {
        private readonly IPieService pieService;
        private readonly ICategoryService categoryService;

        public ListModel(IPieService pieService, ICategoryService categoryService)
        {
            this.pieService = pieService;
            this.categoryService = categoryService;
        }
        
        public IEnumerable<Pie> Pies { get; set; }

        public string SelectedCategoryName { get; set; }

        public async Task OnGet(string category)
        {
            Category selectedCategory = null;
            if (!string.IsNullOrEmpty(category))
            {
                selectedCategory = await categoryService.GetCategoryByNameAsync(category);
            }
            if(selectedCategory == null)
            {
                Pies = await pieService.GetPiesAsync();
            }
            else
            {
                Pies = await pieService.GetPiesByCategoryAsync(category);
                SelectedCategoryName = selectedCategory.Name;
            }
        }
    }
}