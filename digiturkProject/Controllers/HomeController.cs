using digiturkProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace digiturkProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            // Form için boş bir model örneği gönderin
            return View(new ContactFormModel());
        }

        // POST: /Home/Index (Form gönderimi)
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF saldırılarını önlemek için
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Form verilerini işleyin (örneğin, bir hizmete gönderin, veritabanına kaydedin vb.)
                // Başarılı bir işlem sonrası kullanıcıyı başka bir sayfaya yönlendirebilirsiniz
                // veya bir başarı mesajı gösterebilirsiniz.
                TempData["SuccessMessage"] = "Formunuz başarıyla gönderildi!";
                return RedirectToAction("Index"); // Aynı sayfayı yenile veya başka bir sayfaya yönlendir
            }
            // Model doğrulama hataları varsa, aynı görünümü hatalarla birlikte geri gönderin
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}