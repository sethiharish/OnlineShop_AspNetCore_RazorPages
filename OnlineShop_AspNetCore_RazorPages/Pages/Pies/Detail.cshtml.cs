﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Data.Services;
using OnlineShop.Entities;
using System.Threading.Tasks;

namespace OnlineShop_AspNetCore_RazorPages.Pages.Pies
{
    public class DetailModel : PageModel
    {
        private readonly IPieService pieService;

        public DetailModel(IPieService pieService)
        {
            this.pieService = pieService;
        }

        public Pie Pie { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Pie = await pieService.GetPieAsync(id);
            
            if(Pie == null)
            {
                return RedirectToPage("../NotFound");
            }
            
            return Page();
        }
    }
}