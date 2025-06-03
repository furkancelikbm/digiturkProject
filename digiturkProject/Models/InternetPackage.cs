// Models/InternetPackage.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // [NotMapped] için

namespace digiturkProject.Models // Proje adınıza göre değiştirin
{
    public class InternetPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageSrc { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageAlt { get; set; }

        [Required]
        [MaxLength(100)]
        public string BaseTitle { get; set; }

        [Required]
        [MaxLength(255)]
        public string Disclaimer { get; set; }

        [MaxLength(50)]
        public string BadgeLeft { get; set; }

        [MaxLength(50)]
        public string BadgeRight { get; set; }

        // SpeedOptions, InternetPackage'a bağlı olduğu için ayrı bir tabloya gidiyor.
        public List<SpeedOption> SpeedOptions { get; set; } // <--- Changed to List<SpeedOption>


        [Required]
        public string FeaturesJson { get; set; } // JSON string olarak tutulacak
    }
}