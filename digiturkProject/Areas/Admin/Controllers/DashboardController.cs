using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using digiturkProject.Models; // Models klasörünüzü buraya ekleyin
using digiturkProject.Models.Data; // Data klasörünüzü buraya ekleyin
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json; // JSON serileştirme/deserileştirme için

namespace digiturkProject.Areas.Admin.Controllers
{
    [Area("Admin")] // Bu controller'ın "Admin" alanına ait olduğunu belirtir
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin Dashboard Ana Sayfası
        public IActionResult Index()
        {
            return View();
        }

        // MARK: - Match CRUD Operations

        // Maçları Listele
        public async Task<IActionResult> Matches()
        {
            var matches = await _context.Matches.ToListAsync();
            return View(matches);
        }

        // Yeni Maç Oluştur (GET)
        public IActionResult CreateMatch()
        {
            return View();
        }

        // Yeni Maç Oluştur (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMatch([Bind("League,Time,HomeTeamName,HomeTeamImage,AwayTeamName,AwayTeamImage,BuyLink")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Matches));
            }
            return View(match);
        }

        // Maç Düzenle (GET)
        public async Task<IActionResult> EditMatch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return View(match);
        }

        // Maç Düzenle (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMatch(int id, [Bind("Id,League,Time,HomeTeamName,HomeTeamImage,AwayTeamName,AwayTeamImage,BuyLink")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Matches));
            }
            return View(match);
        }

        // Maç Sil (GET)
        public async Task<IActionResult> DeleteMatch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // Maç Sil (POST)
        [HttpPost, ActionName("DeleteMatch")]
        [ValidateAntiForgeryToken]
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

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }

        // MARK: - TvPackage CRUD Operations

        // TV Paketlerini Listele
        public async Task<IActionResult> TvPackages()
        {
            var tvPackages = await _context.TvPackages.ToListAsync();
            return View(tvPackages);
        }

        // Yeni TvPackage Oluştur (GET)
        public IActionResult CreateTvPackage()
        {
            return View();
        }

        // Yeni TvPackage Oluştur (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTvPackage([Bind("BadgeLeft,BadgeRight,ImageSrc,ImageAlt,Title,FeaturesJson,Price,DetailLink")] TvPackage tvPackage)
        {
            // FeaturesJson alanını List<string> olarak alıp serileştirme
            // Not: Bu modelde FeaturesJson zaten string, bu yüzden doğrudan kullanabiliriz.
            // Eğer formdan List<string> olarak geliyorsa, burada serileştirme yapmalısınız.
            // Örneğin: tvPackage.FeaturesJson = JsonSerializer.Serialize(featuresList);

            if (ModelState.IsValid)
            {
                _context.Add(tvPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TvPackages));
            }
            return View(tvPackage);
        }

        // TvPackage Düzenle (GET)
        public async Task<IActionResult> EditTvPackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvPackage = await _context.TvPackages.FindAsync(id);
            if (tvPackage == null)
            {
                return NotFound();
            }
            return View(tvPackage);
        }

        // TvPackage Düzenle (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTvPackage(int id, [Bind("Id,BadgeLeft,BadgeRight,ImageSrc,ImageAlt,Title,FeaturesJson,Price,DetailLink")] TvPackage tvPackage)
        {
            if (id != tvPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvPackageExists(tvPackage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TvPackages));
            }
            return View(tvPackage);
        }

        // TvPackage Sil (GET)
        public async Task<IActionResult> DeleteTvPackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvPackage = await _context.TvPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvPackage == null)
            {
                return NotFound();
            }

            return View(tvPackage);
        }

        // TvPackage Sil (POST)
        [HttpPost, ActionName("DeleteTvPackage")]
        [ValidateAntiForgeryToken]
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

        private bool TvPackageExists(int id)
        {
            return _context.TvPackages.Any(e => e.Id == id);
        }

        // MARK: - InternetPackage CRUD Operations (with SpeedOptions)

        // İnternet Paketlerini Listele
        public async Task<IActionResult> InternetPackages()
        {
            // SpeedOptions'ı dahil etmek için Include kullanın
            var internetPackages = await _context.InternetPackages
                                                 .Include(ip => ip.SpeedOptions)
                                                 .ToListAsync();
            return View(internetPackages);
        }

        // Yeni InternetPackage Oluştur (GET)
        public IActionResult CreateInternetPackage()
        {
            return View();
        }

        // Yeni InternetPackage Oluştur (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInternetPackage([Bind("ImageSrc,ImageAlt,BaseTitle,Disclaimer,BadgeLeft,BadgeRight,FeaturesJson")] InternetPackage internetPackage)
        {
            if (ModelState.IsValid)
            {
                // FeaturesJson, List<string> olarak geliyorsa burada serileştirme yapın
                // Örneğin: internetPackage.FeaturesJson = JsonSerializer.Serialize(featuresList);
                _context.Add(internetPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(InternetPackages));
            }
            return View(internetPackage);
        }

        // InternetPackage Düzenle (GET)
        public async Task<IActionResult> EditInternetPackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // SpeedOptions'ı da yüklemek için Include kullanın
            var internetPackage = await _context.InternetPackages
                                                 .Include(ip => ip.SpeedOptions)
                                                 .FirstOrDefaultAsync(ip => ip.Id == id);
            if (internetPackage == null)
            {
                return NotFound();
            }
            return View(internetPackage);
        }

        // InternetPackage Düzenle (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInternetPackage(int id, [Bind("Id,ImageSrc,ImageAlt,BaseTitle,Disclaimer,BadgeLeft,BadgeRight,FeaturesJson")] InternetPackage internetPackage, string[] speedOptionValues, string[] speedOptionDisplayTexts, string[] speedOptionFirstPrices, string[] speedOptionUrls, string[] speedOptionTitles, int[] speedOptionIds)
        {
            if (id != internetPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internetPackage);

                    // SpeedOptions'ı güncelle
                    var existingSpeedOptions = await _context.SpeedOptions
                                                             .Where(so => so.InternetPackageId == id)
                                                             .ToListAsync();
                    _context.SpeedOptions.RemoveRange(existingSpeedOptions); // Mevcutları sil

                    if (speedOptionValues != null && speedOptionValues.Length > 0)
                    {
                        for (int i = 0; i < speedOptionValues.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(speedOptionValues[i]))
                            {
                                _context.SpeedOptions.Add(new SpeedOption
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
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternetPackageExists(internetPackage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(InternetPackages));
            }
            return View(internetPackage);
        }

        // InternetPackage Sil (GET)
        public async Task<IActionResult> DeleteInternetPackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var internetPackage = await _context.InternetPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (internetPackage == null)
            {
                return NotFound();
            }

            return View(internetPackage);
        }

        // InternetPackage Sil (POST)
        [HttpPost, ActionName("DeleteInternetPackage")]
        [ValidateAntiForgeryToken]
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

        private bool InternetPackageExists(int id)
        {
            return _context.InternetPackages.Any(e => e.Id == id);
        }
    }
}
