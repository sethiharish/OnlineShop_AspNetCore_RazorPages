using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OnlineShop.Data.Services;
using OnlineShop.Entities;

namespace OnlineShop_AspNetCore_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBannerService bannerService;
        private readonly IPieService pieService;

        public IndexModel(IBannerService bannerService, IPieService pieService)
        {
            this.bannerService = bannerService;
            this.pieService = pieService;
        }

        public List<Banner> Banners { get; set; }
        public Banner ActiveBanner { get { return Banners.FirstOrDefault(); } }

        public IEnumerable<Pie> PiesOfTheWeek { get; set; }

        public async Task OnGet()
        {
            PiesOfTheWeek = await pieService.GetPiesOfTheWeekAsync();
            Banners = (await bannerService.GetBannersAsync()).ToList();
        }
    }
}
