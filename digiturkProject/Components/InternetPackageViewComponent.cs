// Components/ViewComponents/InternetPackageViewComponent.cs
using digiturkProject.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq; // Include için
using System.Text.Json; // JSON deserileştirme için
using System.Threading.Tasks;


namespace digiturkProject.Components.ViewComponents
{
    public class InternetPackageViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InternetPackageViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // SpeedOptions'ı da dahil etmek için Include kullanıyoruz
            var packages = await _context.InternetPackages
                                         .Include(ip => ip.SpeedOptions)
                                         .ToListAsync();

            // FeaturesJson'ı List<string>'e dönüştürmek için (TvPackage ile benzer)
            foreach (var package in packages)
            {
                if (!string.IsNullOrEmpty(package.FeaturesJson))
                {
                    // Burayı şimdilik boş bırakıyoruz, View tarafında Deserialize yapacağız
                }
            }

            return View(packages);
        }
    }
}