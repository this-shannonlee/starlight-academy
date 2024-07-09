using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class IndexModel(Data.StarLightAcademyContext context) : PageModel
{
    public IList<Student> Students { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Students = await context.Students
            .Include(s => s.Rank).ToListAsync();
    }
}
