// Components/ViewComponents/MatchWeekViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace digiturkProject.Components.ViewComponents // Proje adınıza göre değiştirin
{
    public class MatchWeekViewComponent : ViewComponent
    {
        public class Match
        {
            public string League { get; set; }
            public string Time { get; set; }
            public string HomeTeamName { get; set; }
            public string HomeTeamImage { get; set; }
            public string AwayTeamName { get; set; }
            public string AwayTeamImage { get; set; }
            public string BuyLink { get; set; }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var matches = new List<Match>
            {
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
                    AwayTeamImage = "images/Konyaspor.webp",
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
            };
            return View(matches);
        }
    }
}