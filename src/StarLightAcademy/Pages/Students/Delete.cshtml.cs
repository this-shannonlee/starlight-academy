using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class DeleteModel(StarLightAcademy.Data.StarLightAcademyContext context, ILogger<DeleteModel> logger) : PageModel
{
    [BindProperty]
    public Student Student { get; set; } = default!;
    public string ErrorMessage { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await context.Students
            .AsNoTracking()
            .Include(s => s.Rank)
            .FirstOrDefaultAsync(s => s.ID == id);

        if (student == null)
        {
            return NotFound();
        }
        else
        {
            Student = student;
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ErrorMessage = string.Format("Delete {0} failed. Try again", id);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }
        else
        {
            try
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}
