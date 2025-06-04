
using Microsoft.AspNetCore.Mvc; // ViewComponent kullanımı için.
using Microsoft.EntityFrameworkCore; // Veritabanı işlemleri (ToListAsync) için.
using digiturkProject.Models.Data; // Model sınıfları için.

namespace digiturkProject.Components.ViewComponents
{
    public class TvPackageViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamını tutar.

        // Yapıcı metot: Veritabanı bağlamını enjekte ederiz.
        public TvPackageViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        // View Component çağrıldığında çalışır ve asenkron olarak sonuç döndürür.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tüm TV paketlerini veritabanından asenkron olarak çekeriz.
            var packages = await _context.TvPackages.ToListAsync();

            // Her bir paketin FeaturesJson alanını işleriz.
            foreach (var package in packages)
            {
                if (!string.IsNullOrEmpty(package.FeaturesJson))
                {
                    // Şimdilik burada işlem yapmıyorum, View tarafında Deserialize edeceğim.
                }
            }

            // Çekilen TV paketlerini View'e göndeririz.
            return View(packages);
        }
    }
}