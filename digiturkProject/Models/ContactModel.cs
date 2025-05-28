
using System.ComponentModel.DataAnnotations;

namespace digiturkProject.Models
{

        public class ContactModel
        {
            [Required(ErrorMessage = "Ad soyad gereklidir.")]
            [Display(Name = "Ad Soyad")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Telefon numarası gereklidir.")]
            [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
            [Display(Name = "Telefon")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Açık rıza gereklidir.")]
            [Display(Name = "Açık Rıza")]
            public bool Consent { get; set; }
        }
    
}
