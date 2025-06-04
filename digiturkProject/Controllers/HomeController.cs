using digiturkProject.Models; // Bu satır, projenin modellerine erişim sağlar. Yani, ContactFormModel gibi yapıları kullanabiliriz.
using Microsoft.AspNetCore.Mvc; // ASP.NET Core MVC framework'ünün temel bileşenlerini içerir. Kontrolcüler ve eylem sonuçları burada tanımlıdır.
using System.Diagnostics; // Uygulamanın çalışma zamanı bilgilerini (örn. hata izleme) almak için kullanılır.

namespace digiturkProject.Controllers // Bu kısım, kontrolcülerin toplandığı bir isim alanıdır. Kodun düzenli kalmasına yardımcı olur.
{
    public class HomeController : Controller // HomeController sınıfı, Controller sınıfından miras alır. Bu, onun bir MVC kontrolcüsü olduğunu gösterir.
    {
        private readonly ILogger<HomeController> _logger; // _logger alanı, uygulamanın günlükleme (logging) işlemlerini yapmak için kullanılır.

        // HomeController'ın yapıcı metodudur. Bir HomeController örneği oluşturulduğunda logger'ı enjekte eder.
        // Ben burada bağımlılık enjeksiyonunu kullanarak logger'ı alıyorum, bu sayede uygulamanın çalışma zamanı olaylarını kolayca kaydedebilirim.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Gelen logger nesnesini _logger alanına atar.
        }

 

        // GET: /Home/Index adresi üzerinden yapılan istekleri bu metot karşılar.
        // Bu metot, genellikle bir sayfanın ilk yüklenmesinde veya kullanıcı form doldurmadan sayfayı ziyaret ettiğinde çağrılır.
        public IActionResult Index()
        {
            // Bu satır, Index view'ine boş bir ContactFormModel örneği gönderir.
            // Ben bu sayede formun ilk açılışında herhangi bir veriyle dolu olmamasını ve kullanıcı girişine hazır olmasını sağlıyorum.
            return View(new ContactFormModel());
        }



        // POST: /Home/Index adresine yapılan form gönderimlerini bu metot işler.
        [HttpPost] // Bu öznitelik, bu metodun sadece HTTP POST isteklerine yanıt vereceğini belirtir.
        [ValidateAntiForgeryToken] // CSRF (Siteler Arası İstek Sahteciliği) saldırılarını önlemek için bir güvenlik önlemidir.
                                   // Ben bu sayede kullanıcıların güvenli bir şekilde form gönderebildiğinden emin oluyorum.
        public IActionResult Index(ContactFormModel model) // Formdan gelen veriler, ContactFormModel tipindeki 'model' parametresine bağlanır.
        {
            if (ModelState.IsValid) // Bu kontrol, formdan gelen verilerin (ContactFormModel) belirlenen kurallara uygun olup olmadığını denetler.
            {
                // Form verileri geçerliyse bu blok çalışır.
                // Burada formdan gelen verileri işleyebiliriz (örneğin, bir veritabanına kaydetmek, e-posta göndermek vb.).
                // Ben şu an sadece bir başarı mesajı gösterip kullanıcıyı aynı sayfaya yönlendiriyorum.
                TempData["SuccessMessage"] = "Formunuz başarıyla gönderildi!"; // TempData, bir sonraki HTTP isteği için veri saklamak için kullanılır.
                return RedirectToAction("Index"); // İşlem başarılı olduğunda kullanıcıyı tekrar "Index" eylemine yönlendirir.
                                                  // Bu, sayfanın yenilenmesini ve başarı mesajının gösterilmesini sağlar.
            }
            // Eğer model doğrulama (ModelState.IsValid) başarısız olursa, yani formda hatalar varsa bu kısım çalışır.
            // Ben hatalarla birlikte aynı görünümü tekrar göstererek kullanıcının hangi alanları düzeltmesi gerektiğini görmesini sağlıyorum.
            return View(model); // Hatalarla birlikte aynı görünümü geri gönderir, böylece doğrulama mesajları kullanıcıya gösterilir.
        }

        // ---


        public IActionResult Privacy() // Gizlilik sayfasını gösteren eylem metodudur.
        {
            return View(); // Privacy görünümünü döndürür.
        }

        // [ResponseCache] özniteliği, bu eylemin istemci veya proxy sunucular tarafından önbelleğe alınmamasını sağlar.
        // Ben uygulamanın hata mesajlarının güncel ve doğru olduğundan emin olmak için önbelleklenmesini engelliyorum.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() // Uygulamada bir hata oluştuğunda bu metot çağrılır.
        {
            // ErrorViewModel'i kullanarak hata bilgilerini view'e gönderir.
            // RequestId, mevcut HTTP isteğinin benzersiz tanımlayıcısıdır.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}