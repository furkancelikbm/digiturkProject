// Components/ViewComponents/TvPackageViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json; // JSON deserileştirme için
using System.Threading.Tasks;
using digiturkProject.Data;
using digiturkProject.Models.Data;

namespace digiturkProject.Components.ViewComponents
{
    public class TvPackageViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TvPackageViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var packages = await _context.TvPackages.ToListAsync();

            // FeaturesJson'ı List<string>'e dönüştürmek için
            foreach (var package in packages)
            {
                if (!string.IsNullOrEmpty(package.FeaturesJson))
                {
                    // Runtime'da TvPackage modeline Features listesini atayabilmek için geçici bir ViewModel oluşturabilir veya dinamik bir tip kullanabiliriz.
                    // Şimdilik View tarafında doğrudan JsonSerializer.Deserialize kullanacağız, bu daha basit.
                    // Veya buradaki modeli, TvPackage'dan miras alan ve Features listesi olan bir ViewModel olarak da döndürebiliriz.
                    // Basitlik için sadece modeli döndürüyoruz.
                }
            }
            return View(packages);
        }
    }
}