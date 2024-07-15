using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models.AcademyViewModels;

namespace StarLightAcademy.Pages;

public class AboutModel(StarLightAcademy.Data.StarLightAcademyContext context) : PageModel
{
    public IList<RankGroup> Students { get; set; } = default!;
    public async Task OnGetAsync()
    {
        IQueryable<RankGroup> data =
            from student in context.Students
            group student by student.Rank into rankGroup
            select new RankGroup()
            {
                Rank = rankGroup.Key,
                StudentCount = rankGroup.Count()
            };

        Students = await data.AsNoTracking().ToListAsync();
    }
}
