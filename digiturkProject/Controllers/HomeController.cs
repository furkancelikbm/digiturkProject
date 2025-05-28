using Microsoft.AspNetCore.Mvc;
using digiturkProject.Models;

namespace digiturkProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Lütfen tüm alanları doğru şekilde doldurun." });
            }

            // Here you would typically save the form data to a database
            // For now, we'll just return a success message

            return Json(new { success = true, message = "Form başarıyla gönderildi. En kısa sürede sizinle iletişime geçilecektir." });
        }
    }
}