// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace digiturkProject.Models.Data // Proje adınıza göre değiştirin
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Modelleri DbSet olarak ekleyin, bunlar veritabanındaki tablolara karşılık gelir
        public DbSet<Match> Matches { get; set; }
        public DbSet<TvPackage> TvPackages { get; set; }
        public DbSet<InternetPackage> InternetPackages { get; set; }
        public DbSet<SpeedOption> SpeedOptions { get; set; }

        // Model oluşturulurken ek yapılandırmalar (opsiyonel)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri ve kısıtlamaları burada tanımlayabilirsiniz.
            // Örn: InternetPackage ve SpeedOption arasındaki bire çok ilişki
            modelBuilder.Entity<InternetPackage>()
                .HasMany(ip => ip.SpeedOptions)
                .WithOne(so => so.InternetPackage)
                .HasForeignKey(so => so.InternetPackageId)
                .OnDelete(DeleteBehavior.Cascade); // Ana paket silindiğinde hız seçenekleri de silinsin

            // TvPackage ve InternetPackage'daki FeaturesJson alanını JSON olarak saklamak için (opsiyonel, sadece veri okurken deserializasyon yapmanız gerekir)
            // Daha gelişmiş senaryolarda JSON tipi veya value converter kullanabilirsiniz.
            // Şimdilik sadece string olarak saklanacak ve C# tarafında manuel serileştirme/deserileştirme yapacağız.
        }
    }
}