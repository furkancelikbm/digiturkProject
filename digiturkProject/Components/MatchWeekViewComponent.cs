
using digiturkProject.Models.Data; // Modeller ve veritabanı bağlamı için.
using Microsoft.AspNetCore.Mvc; // ViewComponent kullanımı için.
using Microsoft.EntityFrameworkCore; // Entity Framework Core'un asenkron metotları (ToListAsync) için.
using System.Collections.Generic; // Koleksiyon tipleri için.
using System.Threading.Tasks; // Asenkron işlemler için.

namespace digiturkProject.Components.ViewComponents
{
    public class MatchWeekViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamını tutar.

        // Yapıcı metot: Veritabanı bağlamını enjekte ederiz.
        public MatchWeekViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        // View Component çağrıldığında çalışır ve asenkron olarak sonuç döndürür.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Tüm maçları veritabanından asenkron olarak çekeriz.
            var matches = await _context.Matches.ToListAsync();

            // Çekilen maçları View'e göndeririz.
            return View(matches);
        }
    }
}