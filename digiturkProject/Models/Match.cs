// Models/Match.cs
using System.ComponentModel.DataAnnotations; // Veritabanı kısıtlamaları için

namespace digiturkProject.Models // Proje adınıza göre değiştirin
{
    public class Match
    {
        [Key] // Primary Key olduğunu belirtir
        public int Id { get; set; }

        [Required] // Boş geçilemez
        [MaxLength(100)] // Maksimum uzunluk
        public string League { get; set; }

        [Required]
        [MaxLength(50)]
        public string Time { get; set; }

        [Required]
        [MaxLength(100)]
        public string HomeTeamName { get; set; }

        [Required]
        [MaxLength(255)] // Resim yolları genellikle daha uzundur
        public string HomeTeamImage { get; set; }

        [Required]
        [MaxLength(100)]
        public string AwayTeamName { get; set; }

        [Required]
        [MaxLength(255)]
        public string AwayTeamImage { get; set; }

        [Required]
        [MaxLength(255)]
        public string BuyLink { get; set; }
    }
}