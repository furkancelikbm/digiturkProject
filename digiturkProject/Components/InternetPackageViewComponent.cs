// Components/ViewComponents/InternetPackageViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace digiturkProject.Components.ViewComponents // Proje adınıza göre değiştirin
{
    public class InternetPackageViewComponent : ViewComponent
    {
        public class InternetPackage
        {
            public string ImageSrc { get; set; }
            public string ImageAlt { get; set; }
            public string BaseTitle { get; set; }
            public string Disclaimer { get; set; }
            public string BadgeLeft { get; set; }
            public string BadgeRight { get; set; }
            public List<SpeedOption> SpeedOptions { get; set; }
            public List<string> Features { get; set; }
        }

        public class SpeedOption
        {
            public string Value { get; set; }
            public string DisplayText { get; set; }
            public string FirstPrice { get; set; }
            public string Url { get; set; }
            public string Title { get; set; }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var packages = new List<InternetPackage>
            {
                new InternetPackage
                {
                    ImageSrc = "images/digiturk-ev-interneti.webp",
                    ImageAlt = "Digiturk Ev İnterneti",
                    BaseTitle = "Digiturk Ev İnterneti",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    SpeedOptions = new List<SpeedOption>
                    {
                        new SpeedOption { Value = "16", DisplayText = "16 Mbps", FirstPrice = "459", Url = "digiturk-ev-interneti-16-mbps", Title = "Digiturk Ev İnterneti 16 Mbps" },
                        new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "459", Url = "digiturk-ev-interneti-35-mbps", Title = "Digiturk Ev İnterneti 35 Mbps" },
                        new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "539", Url = "digiturk-ev-interneti-50-mbps", Title = "Digiturk Ev İnterneti 50 Mbps" },
                        new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "579", Url = "digiturk-ev-interneti-100-mbps", Title = "Digiturk Ev İnterneti 100 Mbps" }
                    },
                    Features = new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }
                },
                new InternetPackage
                {
                    ImageSrc = "images/digiturk-internet.webp",
                    ImageAlt = "Digiturk İnternet",
                    BaseTitle = "Digiturk İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    SpeedOptions = new List<SpeedOption>
                    {
                        new SpeedOption { Value = "16", DisplayText = "16 Mbps", FirstPrice = "499", Url = "digiturk-internet-16-mbps", Title = "Digiturk İnternet 16 Mbps" },
                        new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "499", Url = "digiturk-internet-35-mbps", Title = "Digiturk İnternet 35 Mbps" },
                        new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "589", Url = "digiturk-internet-50-mbps", Title = "Digiturk İnternet 50 Mbps" },
                        new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "629", Url = "digiturk-internet-100-mbps", Title = "Digiturk İnternet 100 Mbps" }
                    },
                    Features = new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }
                },
                new InternetPackage
                {
                    ImageSrc = "images/digiturk-vdsl-internet.webp",
                    ImageAlt = "Digiturk VDSL internet",
                    BaseTitle = "Digiturk VDSL İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Test Online",
                    BadgeRight = "TV+İnternet",
                    SpeedOptions = new List<SpeedOption>
                    {
                        new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "534", Url = "digiturk-vdsl-internet-35-mbps", Title = "Digiturk VDSL İnternet 35 Mbps" },
                        new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "614", Url = "digiturk-vdsl-internet-50-mbps", Title = "Digiturk VDSL İnternet 50 Mbps" },
                        new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "654", Url = "digiturk-vdsl-internet-100-mbps", Title = "Digiturk VDSL İnternet 100 Mbps" },
                        new SpeedOption { Value = "200", DisplayText = "200 Mbps", FirstPrice = "754", Url = "digiturk-vdsl-internet-200-mbps", Title = "Digiturk VDSL İnternet 200 Mbps" },
                        new SpeedOption { Value = "500", DisplayText = "500 Mbps", FirstPrice = "904", Url = "digiturk-vdsl-internet-500-mbps", Title = "Digiturk VDSL İnternet 500 Mbps" },
                        new SpeedOption { Value = "1000", DisplayText = "1000 Mbps", FirstPrice = "1104", Url = "digiturk-vdsl-internet-1000-mbps", Title = "Digiturk VDSL İnternet 1000 Mbps" }
                    },
                    Features = new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }
                },
                new InternetPackage
                {
                    ImageSrc = "images/digiturk-fiber-internet.webp",
                    ImageAlt = "Digiturk Fiber İnternet",
                    BaseTitle = "Digiturk Fiber İnternet",
                    Disclaimer = "1500 TL'ye kadar cayma bedeli Digiturk' ten!",
                    BadgeLeft = "Online'a Özel",
                    BadgeRight = "TV+İnternet",
                    SpeedOptions = new List<SpeedOption>
                    {
                        new SpeedOption { Value = "35", DisplayText = "35 Mbps", FirstPrice = "574", Url = "digiturk-fiber-internet-35-mbps", Title = "Digiturk Fiber İnternet 35 Mbps" },
                        new SpeedOption { Value = "50", DisplayText = "50 Mbps", FirstPrice = "664", Url = "digiturk-fiber-internet-50-mbps", Title = "Digiturk Fiber İnternet 50 Mbps" },
                        new SpeedOption { Value = "100", DisplayText = "100 Mbps", FirstPrice = "704", Url = "digiturk-fiber-internet-100-mbps", Title = "Digiturk Fiber İnternet 100 Mbps" },
                        new SpeedOption { Value = "200", DisplayText = "200 Mbps", FirstPrice = "804", Url = "digiturk-fiber-internet-200-mbps", Title = "Digiturk Fiber İnternet 200 Mbps" },
                        new SpeedOption { Value = "500", DisplayText = "500 Mbps", FirstPrice = "954", Url = "digiturk-fiber-internet-500-mbps", Title = "Digiturk Fiber İnternet 500 Mbps" },
                        new SpeedOption { Value = "1000", DisplayText = "1000 Mbps", FirstPrice = "1154", Url = "digiturk-fiber-internet-1000-mbps", Title = "Digiturk Fiber İnternet 1000 Mbps" }
                    },
                    Features = new List<string>
                    {
                        "12 Ay Boyunca Trendyol Süperlig dahil",
                        "Trendyol 1. Lig ve Basketbol Maçları",
                        "Premier League , Fransa Ligue 1, Bundesliga",
                        "beIN CONNECT ile dilediğin yerde izle!"
                    }
                }
            };
            return View(packages);
        }
    }
}