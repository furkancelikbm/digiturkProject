// Components/ViewComponents/TvPackageViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace digiturkProject.Components.ViewComponents 
{
    public class TvPackageViewComponent : ViewComponent
    {
        public class TvPackage
        {
            public string BadgeLeft { get; set; }
            public string BadgeRight { get; set; }
            public string ImageSrc { get; set; }
            public string ImageAlt { get; set; }
            public string Title { get; set; }
            public List<string> Features { get; set; }
            public string Price { get; set; }
            public string DetailLink { get; set; }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var packages = new List<TvPackage>
            {
                new TvPackage
                {
                    BadgeLeft = "Online Test",
                    BadgeRight = "TV",
                    ImageSrc = "images/card1.png",
                    ImageAlt = "Lorem ipsum dolor sit amet.",
                    Title = "Lorem ipsum dolor.",
                    Features = new List<string>
                    {
                        "Lorem ipsum dolo ex sapien vitae pellentesque",
                        "malesuada lacinia integer nunc posuere",
                        "malesuada lacinia integer nunc posuere",
                        "malesuada lacinia integer nunc posuere",
                        "malesuada lacinia integer nunc posuere"
                    },
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
                    Features = new List<string>
                    {
                        "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                        "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                        "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                        "Lorem ipsum dolor sit amet consectetur adipiscing eli",
                        "Lorem ipsum dolor sit amet consectetur adipiscing eli"
                    },
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
                    Features = new List<string>
                    {
                        "Tempus leo eu aenean sed diam urna",
                        "Pulvinar vivamus fringilla lacus nec metus bibendum",
                        "Pulvinar vivamus fringilla lacus nec metus bibendum",
                        "Pulvinar vivamus fringilla lacus nec metus bibendum",
                        "Pulvinar vivamus fringilla lacus nec metus bibendum"
                    },
                    Price = "₺444 /Ay",
                    DetailLink = "/digiturk-eglencenin-ve-avrupanin-yildizi-paketi"
                }
            };
            return View(packages);
        }
    }
}