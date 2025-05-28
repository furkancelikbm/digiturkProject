using System.ComponentModel.DataAnnotations;

namespace digiturkProject.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [StringLength(30, ErrorMessage = "Ad soyad en fazla 30 karakter olabilir.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^5[0-9]{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz (5xxxxxxxxx).")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Açık rıza gereklidir.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Açık rıza metnini onaylamanız gerekmektedir.")]
        public bool Consent { get; set; }
    }
}