using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class IndexModel(StarLightAcademy.Data.StarLightAcademyContext context) : PageModel
{
    public IList<Student> Student { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Student = await context.Students
            .Include(s => s.Rank).ToListAsync();
    }
}
