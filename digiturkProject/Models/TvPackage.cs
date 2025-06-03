// Models/TvPackage.cs
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace digiturkProject.Models // Proje adınıza göre değiştirin
{
    public class TvPackage
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string BadgeLeft { get; set; } // Nullable olabilir

        [MaxLength(50)]
        public string BadgeRight { get; set; } // Nullable olabilir

        [Required]
        [MaxLength(255)]
        public string ImageSrc { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageAlt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        // Özellikleri virgülle ayrılmış bir string olarak tutabiliriz
        // veya ayrı bir tabloda ilişkili olarak tutabiliriz. Basitlik için string tercih edildi.
        [Required]
        public string FeaturesJson { get; set; } // JSON string olarak tutulacak
        // Örn: "[\"Özellik 1\", \"Özellik 2\"]"

        [Required]
        [MaxLength(50)]
        public string Price { get; set; }

        [Required]
        [MaxLength(255)]
        public string DetailLink { get; set; }
    }
}