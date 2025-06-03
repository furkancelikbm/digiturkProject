// Components/ViewComponents/MatchWeekViewComponent.cs
using digiturkProject.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ToListAsync için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace digiturkProject.Components.ViewComponents
{
    public class MatchWeekViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public MatchWeekViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var matches = await _context.Matches.ToListAsync();
            return View(matches);
        }
    }
}