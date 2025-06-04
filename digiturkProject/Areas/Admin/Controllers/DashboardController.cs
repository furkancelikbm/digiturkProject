using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; // Veritabanı işlemleri için.
using digiturkProject.Models; // Genel modelleri içerir.
using digiturkProject.Models.Data; 


namespace digiturkProject.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu kontrolcü "Admin" alanına aittir.
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamı.

        // Yapıcı metot: Veritabanı bağlamını enjekte ederiz.
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Admin panelinin ana sayfasını gösteririz.
        public IActionResult Index()
        {
            return View();
        }


        // Maçları listeleriz.
        public async Task<IActionResult> Matches()
        {
            var matches = await _context.Matches.ToListAsync();
            return View(matches);
        }

        // Yeni maç oluşturma sayfasını gösteririz.
        public IActionResult CreateMatch()
        {
            return View();
        }

        // Yeni maç POST isteğiyle oluşturulur.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> CreateMatch([Bind("League,Time,HomeTeamName,HomeTeamImage,AwayTeamName,AwayTeamImage,BuyLink")] Match match)
        {
            if (ModelState.IsValid) // Model geçerliyse kaydet.
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Matches));
            }
            return View(match); // Hatalıysa aynı View'i göster.
        }

        // Maç düzenleme sayfasını gösteririz.
        public async Task<IActionResult> EditMatch(int? id)
        {
            if (id == null) return NotFound();
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            return View(match);
        }

        // Maç düzenleme POST isteğiyle güncellenir.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> EditMatch(int id, [Bind("Id,League,Time,HomeTeamName,HomeTeamImage,AwayTeamName,AwayTeamImage,BuyLink")] Match match)
        {
            if (id != match.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) // Çakışma durumunda hata yönetimi.
                {
                    if (!MatchExists(match.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Matches));
            }
            return View(match);
        }

        // Maç silme onay sayfasını gösteririz.
        public async Task<IActionResult> DeleteMatch(int? id)
        {
            if (id == null) return NotFound();
            var match = await _context.Matches.FirstOrDefaultAsync(m => m.Id == id);
            if (match == null) return NotFound();
            return View(match);
        }

        // Maç silme POST isteğiyle işlemi onaylarız.
        [HttpPost, ActionName("DeleteMatch")]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> DeleteMatchConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Matches));
        }

        // Maçın var olup olmadığını kontrol ederiz.
        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }


        // TV Paketlerini listeleriz.
        public async Task<IActionResult> TvPackages()
        {
            var tvPackages = await _context.TvPackages.ToListAsync();
            return View(tvPackages);
        }

        // Yeni TV paketi oluşturma sayfasını gösteririz.
        public IActionResult CreateTvPackage()
        {
            return View();
        }

        // Yeni TV paketi POST isteğiyle oluşturulur.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> CreateTvPackage([Bind("BadgeLeft,BadgeRight,ImageSrc,ImageAlt,Title,FeaturesJson,Price,DetailLink")] TvPackage tvPackage)
        {
            // FeaturesJson için serileştirme gerekirse burada yapın.
            if (ModelState.IsValid)
            {
                _context.Add(tvPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TvPackages));
            }
            return View(tvPackage);
        }

        // TV paketi düzenleme sayfasını gösteririz.
        public async Task<IActionResult> EditTvPackage(int? id)
        {
            if (id == null) return NotFound();
            var tvPackage = await _context.TvPackages.FindAsync(id);
            if (tvPackage == null) return NotFound();
            return View(tvPackage);
        }

        // TV paketi düzenleme POST isteğiyle güncellenir.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> EditTvPackage(int id, [Bind("Id,BadgeLeft,BadgeRight,ImageSrc,ImageAlt,Title,FeaturesJson,Price,DetailLink")] TvPackage tvPackage)
        {
            if (id != tvPackage.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) // Çakışma durumunda hata yönetimi.
                {
                    if (!TvPackageExists(tvPackage.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(TvPackages));
            }
            return View(tvPackage);
        }

        // TV paketi silme onay sayfasını gösteririz.
        public async Task<IActionResult> DeleteTvPackage(int? id)
        {
            if (id == null) return NotFound();
            var tvPackage = await _context.TvPackages.FirstOrDefaultAsync(m => m.Id == id);
            if (tvPackage == null) return NotFound();
            return View(tvPackage);
        }

        // TV paketi silme POST isteğiyle işlemi onaylarız.
        [HttpPost, ActionName("DeleteTvPackage")]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> DeleteTvPackageConfirmed(int id)
        {
            var tvPackage = await _context.TvPackages.FindAsync(id);
            if (tvPackage != null)
            {
                _context.TvPackages.Remove(tvPackage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(TvPackages));
        }

        // TV paketinin var olup olmadığını kontrol ederiz.
        private bool TvPackageExists(int id)
        {
            return _context.TvPackages.Any(e => e.Id == id);
        }


        // İnternet paketlerini listeleriz (hız seçenekleriyle birlikte).
        public async Task<IActionResult> InternetPackages()
        {
            var internetPackages = await _context.InternetPackages
                                                 .Include(ip => ip.SpeedOptions) // Hız seçeneklerini dahil et.
                                                 .ToListAsync();
            return View(internetPackages);
        }

        // Yeni İnternet paketi oluşturma sayfasını gösteririz.
        public IActionResult CreateInternetPackage()
        {
            return View();
        }

        // Yeni İnternet paketi POST isteğiyle oluşturulur.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> CreateInternetPackage([Bind("ImageSrc,ImageAlt,BaseTitle,Disclaimer,BadgeLeft,BadgeRight,FeaturesJson")] InternetPackage internetPackage)
        {
            // FeaturesJson için serileştirme gerekirse burada yapın.
            if (ModelState.IsValid)
            {
                _context.Add(internetPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InternetPackages));
            }
            return View(internetPackage);
        }

        // İnternet paketi düzenleme sayfasını gösteririz.
        public async Task<IActionResult> EditInternetPackage(int? id)
        {
            if (id == null) return NotFound();
            var internetPackage = await _context.InternetPackages
                                                 .Include(ip => ip.SpeedOptions) // Hız seçeneklerini dahil et.
                                                 .FirstOrDefaultAsync(ip => ip.Id == id);
            if (internetPackage == null) return NotFound();
            return View(internetPackage);
        }

        // İnternet paketi düzenleme POST isteğiyle güncellenir.
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> EditInternetPackage(int id, [Bind("Id,ImageSrc,ImageAlt,BaseTitle,Disclaimer,BadgeLeft,BadgeRight,FeaturesJson")] InternetPackage internetPackage, string[] speedOptionValues, string[] speedOptionDisplayTexts, string[] speedOptionFirstPrices, string[] speedOptionUrls, string[] speedOptionTitles, int[] speedOptionIds)
        {
            if (id != internetPackage.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internetPackage);

                    // Mevcut hız seçeneklerini silip yenilerini ekleriz.
                    var existingSpeedOptions = await _context.SpeedOptions
                                                             .Where(so => so.InternetPackageId == id)
                                                             .ToListAsync();
                    _context.SpeedOptions.RemoveRange(existingSpeedOptions);

                    if (speedOptionValues != null && speedOptionValues.Length > 0)
                    {
                        for (int i = 0; i < speedOptionValues.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(speedOptionValues[i]))
                            {
                                _context.SpeedOptions.Add(new SpeedOption // Yeni hız seçeneği ekle.
                                {
                                    Value = speedOptionValues[i],
                                    DisplayText = speedOptionDisplayTexts[i],
                                    FirstPrice = speedOptionFirstPrices[i],
                                    Url = speedOptionUrls[i],
                                    Title = speedOptionTitles[i],
                                    InternetPackageId = internetPackage.Id
                                });
                            }
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) // Çakışma durumunda hata yönetimi.
                {
                    if (!InternetPackageExists(internetPackage.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(InternetPackages));
            }
            return View(internetPackage);
        }

        // İnternet paketi silme onay sayfasını gösteririz.
        public async Task<IActionResult> DeleteInternetPackage(int? id)
        {
            if (id == null) return NotFound();
            var internetPackage = await _context.InternetPackages.FirstOrDefaultAsync(m => m.Id == id);
            if (internetPackage == null) return NotFound();
            return View(internetPackage);
        }

        // İnternet paketi silme POST isteğiyle işlemi onaylarız.
        [HttpPost, ActionName("DeleteInternetPackage")]
        [ValidateAntiForgeryToken] // CSRF koruması.
        public async Task<IActionResult> DeleteInternetPackageConfirmed(int id)
        {
            var internetPackage = await _context.InternetPackages.FindAsync(id);
            if (internetPackage != null)
            {
                _context.InternetPackages.Remove(internetPackage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(InternetPackages));
        }

        // İnternet paketinin var olup olmadığını kontrol ederiz.
        private bool InternetPackageExists(int id)
        {
            return _context.InternetPackages.Any(e => e.Id == id);
        }
    }
}