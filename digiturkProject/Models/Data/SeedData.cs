// Data/SeedData.cs
using digiturkProject.Models;
using digiturkProject.Models.Data; // Add this line
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json; // JSON serileştirme/deserileştirme için


namespace digiturkProject.Data // Proje adınıza göre değiştirin
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Veritabanında veri olup olmadığını kontrol edin
                if (context.Matches.Any() || context.TvPackages.Any() || context.InternetPackages.Any())
                {
                    return; // DB zaten seed edilmiş
                }

                // Maç verileri
                context.Matches.AddRange(
                    new Match
                    {
                        League = "Trendyol Süper Lig",
                        Time = "Cuma 20:00",
                        HomeTeamName = "Antalyaspor",
                        HomeTeamImage = "images/Antalyaspor.webp",
                        AwayTeamName = "Trabzonspor",
                        AwayTeamImage = "images/Trabzonspor.webp",
                        BuyLink = "/secim"
                    },
                    new Match
                    {
                        League = "Trendyol Süper Lig",
                        Time = "Cuma 20:00",
                        HomeTeamName = "Galatasaray",
                        HomeTeamImage = "images/Galatasaray.webp",
                        AwayTeamName = "Başakşehir",
                        AwayTeamImage = "images/Başakşehir.webp",
                        BuyLink = "/secim"
                    },
                    new Match
                    {
                        League = "Trendyol Süper Lig",
                        Time = "Cumartesi 16:00",
                        HomeTeamName = "Fenerbahçe",
                        HomeTeamImage = "images/Fenerbahçe.webp",
                        AwayTeamName = "Konyaspor",
                        AwayTeamImage = "Konyaspor.webp",
                        BuyLink = "/secim"
                    },
                    new Match
                    {
                        League = "Trendyol Süper Lig",
                        Time = "Pazar 19:00",
                        HomeTeamName = "Bodrumspor",
                        HomeTeamImage = "images/Bodrumspor.webp",
                        AwayTeamName = "Beşiktaş",
                        AwayTeamImage = "images/Beşiktaş.webp",
                        BuyLink = "/secim"
                    }
                );

                // TV Paketleri verileri
                context.TvPackages.AddRange(
                    new TvPackage
                    {
                        BadgeLeft = "Online Test",
                        BadgeRight = "TV",
                        ImageSrc = "images/card1.png",
                        ImageAlt = "Lorem ipsum dolor sit amet.",
                        Title = "Lorem ipsum dolor.",
                        FeaturesJson = JsonSerializer.Serialize(new List<string>
                        {
                            "Lorem ipsum dolo ex sapien vitae pellentesque",
                            "malesuada lacinia integer nunc posuere",
                            "malesuada lacinia integer nunc posuere",
                            "malesuada lacinia integer nunc posuere",
                            "malesuada lacinia integer nunc posuere"
                        }),
                        Price = "₺999 /Ay",
                        DetailLink = "/digiturk-taraftar-paketi-2"
                    },
                    new TvPackage
                    {
                        BadgeLeft = "Online Test",
                        BadgeRight = "TV",
                        ImageSrc = "images/card2.png",
                        ImageAlt = "Pulvinar vivamus fringilla lacus nec metus",
                        Title = "Tempus leo eu aenean sed diam urna",
                        FeaturesJson = JsonSerializer.Serialize(new List<string>
                        {
                            "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                            "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                            "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                            "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                            "Lorem ipsum dolor sit amet consectetur adipiscing eli"
                        }),
                        Price = "₺123 /Ay",
                        DetailLink = "/digiturk-sporun-yildizi-paketi-2"
                    },
                    new TvPackage
                    {
                        BadgeLeft = "Pulvinar vivamus",
                        BadgeRight = "TV",
                        ImageSrc = "images/card3.png",
                        ImageAlt = " inceptos himenaeos.",
                        Title = "Lorem ipsum dolor sit amet consectetur adipiscing elit",
                        FeaturesJson = JsonSerializer.Serialize(new List<string>
                        {
                            "Tempus leo eu aenean sed diam urna",
                            "Pulvinar vivamus fringilla lacus nec metus bibendum",
                            "Pulvinar vivamus fringilla lacus nec metus bibendum",
                            "Pulvinar vivamus fringilla lacus nec metus bibendum",
                            "Pulvinar vivamus fringilla lacus nec metus bibendum"
                        }),
                        Price = "₺444 /Ay",
                        DetailLink = "/digiturk-eglencenin-ve-avrupanin-yildizi-paketi"
                    }
                );
                context.SaveChanges(); // Önce Tv Paketleri ve Match'leri kaydet

                // İnternet Paketleri verileri
                // SpeedOptions, InternetPackage kaydedildikten sonra Id'ye ihtiyaç duyar.
                var internetPackage1 = new InternetPackage
                {
                    ImageSrc = "images/digiturk-ev-interneti.webp",
                    ImageAlt = "Digiturk Ev İnterneti",
                    BaseTitle = "Digiturk Ev İnterneti",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    FeaturesJson = JsonSerializer.Serialize(new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }),
                    SpeedOptions = new List<SpeedOption>() // Boş bırakın, aşağıda eklenecek
                };
                context.InternetPackages.Add(internetPackage1);
                context.SaveChanges(); // InternetPackage'ı kaydet ki Id oluşsun

                internetPackage1.SpeedOptions.AddRange(new List<SpeedOption>
                {
                    new SpeedOption { Value = "16", DisplayText = "16 Mbps", FirstPrice = "459", Url = "digiturk-ev-interneti-16-mbps", Title = "Digiturk Ev İnterneti 16 Mbps", InternetPackageId = internetPackage1.Id },
                    new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "459", Url = "digiturk-ev-interneti-35-mbps", Title = "Digiturk Ev İnterneti 35 Mbps", InternetPackageId = internetPackage1.Id },
                    new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "539", Url = "digiturk-ev-interneti-50-mbps", Title = "Digiturk Ev İnterneti 50 Mbps", InternetPackageId = internetPackage1.Id },
                    new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "579", Url = "digiturk-ev-interneti-100-mbps", Title = "Digiturk Ev İnterneti 100 Mbps", InternetPackageId = internetPackage1.Id }
                });


                var internetPackage2 = new InternetPackage
                {
                    ImageSrc = "images/digiturk-internet.webp",
                    ImageAlt = "Digiturk İnternet",
                    BaseTitle = "Digiturk İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    FeaturesJson = JsonSerializer.Serialize(new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }),
                    SpeedOptions = new List<SpeedOption>()
                };
                context.InternetPackages.Add(internetPackage2);
                context.SaveChanges();

                internetPackage2.SpeedOptions.AddRange(new List<SpeedOption>
                {
                    new SpeedOption { Value = "16", DisplayText = "16 Mbps", FirstPrice = "499", Url = "digiturk-internet-16-mbps", Title = "Digiturk İnternet 16 Mbps", InternetPackageId = internetPackage2.Id },
                    new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "499", Url = "digiturk-internet-35-mbps", Title = "Digiturk İnternet 35 Mbps", InternetPackageId = internetPackage2.Id },
                    new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "589", Url = "digiturk-internet-50-mbps", Title = "Digiturk İnternet 50 Mbps", InternetPackageId = internetPackage2.Id },
                    new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "629", Url = "digiturk-internet-100-mbps", Title = "Digiturk İnternet 100 Mbps", InternetPackageId = internetPackage2.Id }
                });

                var internetPackage3 = new InternetPackage
                {
                    ImageSrc = "images/digiturk-vdsl-internet.webp",
                    ImageAlt = "Digiturk VDSL internet",
                    BaseTitle = "Digiturk VDSL İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Test Online",
                    BadgeRight = "TV+İnternet",
                    FeaturesJson = JsonSerializer.Serialize(new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }),
                    SpeedOptions = new List<SpeedOption>()
                };
                context.InternetPackages.Add(internetPackage3);
                context.SaveChanges();

                internetPackage3.SpeedOptions.AddRange(new List<SpeedOption>
                {
                    new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "534", Url = "digiturk-vdsl-internet-35-mbps", Title = "Digiturk VDSL İnternet 35 Mbps", InternetPackageId = internetPackage3.Id },
                    new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "614", Url = "digiturk-vdsl-internet-50-mbps", Title = "Digiturk VDSL İnternet 50 Mbps", InternetPackageId = internetPackage3.Id },
                    new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "654", Url = "digiturk-vdsl-internet-100-mbps", Title = "Digiturk VDSL İnternet 100 Mbps", InternetPackageId = internetPackage3.Id },
                    new SpeedOption { Value = "200", DisplayText = "200 Mbps", FirstPrice = "754", Url = "digiturk-vdsl-internet-200-mbps", Title = "Digiturk VDSL İnternet 200 Mbps", InternetPackageId = internetPackage3.Id },
                    new SpeedOption { Value = "500", DisplayText = "500 Mbps", FirstPrice = "904", Url = "digiturk-vdsl-internet-500-mbps", Title = "Digiturk VDSL İnternet 500 Mbps", InternetPackageId = internetPackage3.Id },
                    new SpeedOption { Value = "1000", DisplayText = "1000 Mbps", FirstPrice = "1104", Url = "digiturk-vdsl-internet-1000-mbps", Title = "Digiturk VDSL İnternet 1000 Mbps", InternetPackageId = internetPackage3.Id }
                });

                var internetPackage4 = new InternetPackage
                {
                    ImageSrc = "images/digiturk-fiber-internet.webp",
                    ImageAlt = "Digiturk Fiber İnternet",
                    BaseTitle = "Digiturk Fiber İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    FeaturesJson = JsonSerializer.Serialize(new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }),
                    SpeedOptions = new List<SpeedOption>()
                };
                context.InternetPackages.Add(internetPackage4);
                context.SaveChanges();

                internetPackage4.SpeedOptions.AddRange(new List<SpeedOption>
                {
                    new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "574", Url = "digiturk-fiber-internet-35-mbps", Title = "Digiturk Fiber İnternet 35 Mbps", InternetPackageId = internetPackage4.Id },
                    new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "664", Url = "digiturk-fiber-internet-50-mbps", Title = "Digiturk Fiber İnternet 50 Mbps", InternetPackageId = internetPackage4.Id },
                    new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "704", Url = "digiturk-fiber-internet-100-mbps", Title = "Digiturk Fiber İnternet 100 Mbps", InternetPackageId = internetPackage4.Id },
                    new SpeedOption { Value = "200", DisplayText = "200 Mbps", FirstPrice = "804", Url = "digiturk-fiber-internet-200-mbps", Title = "Digiturk Fiber İnternet 200 Mbps", InternetPackageId = internetPackage4.Id },
                    new SpeedOption { Value = "500", DisplayText = "500 Mbps", FirstPrice = "954", Url = "digiturk-fiber-internet-500-mbps", Title = "Digiturk Fiber İnternet 500 Mbps", InternetPackageId = internetPackage4.Id },
                    new SpeedOption { Value = "1000", DisplayText = "1000 Mbps", FirstPrice = "1154", Url = "digiturk-fiber-internet-1000-mbps", Title = "Digiturk Fiber İnternet 1000 Mbps", InternetPackageId = internetPackage4.Id }
                });

                context.SaveChanges(); // Tüm değişiklikleri kaydet
            }
        }
    }
}