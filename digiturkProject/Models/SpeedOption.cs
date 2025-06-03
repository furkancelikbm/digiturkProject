// Models/SpeedOption.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // [ForeignKey] için

namespace digiturkProject.Models // Proje adınıza göre değiştirin
{
    public class SpeedOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)] // "16", "35", "1000" gibi değerler
        public string Value { get; set; }

        [Required]
        [MaxLength(50)] // "16 Mbps", "1000 Mbps" gibi değerler
        public string DisplayText { get; set; }

        [Required]
        [MaxLength(10)] // "459", "579" gibi fiyatlar
        public string FirstPrice { get; set; }

        [Required]
        [MaxLength(255)]
        public string Url { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        // Foreign Key to InternetPackage
        public int InternetPackageId { get; set; }
        [ForeignKey("InternetPackageId")]
        public InternetPackage InternetPackage { get; set; }
    }
}