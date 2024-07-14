using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class EditModel(Data.StarLightAcademyContext context) : PageModel
{
    [BindProperty]
    public StudentInput Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await context.Students.FirstOrDefaultAsync(m => m.ID == id);
        if (student == null)
        {
            return NotFound();
        }
        Student = student;
        ViewData["RankID"] = new SelectList(context.Ranks, "ID", "Title");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        //var studentToUpdate = await context.Students.FindAsync(id);
        var studentToUpdate = await context.Students.FirstOrDefaultAsync(m => m.ID == id);

        if (studentToUpdate == null)
        {
            return NotFound();
        }

        try
        {
            studentToUpdate.CurrentValues.SetValues(StudentVM);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(Student.ID))
            {
                return NotFound();
}
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool StudentExists(int id)
{
    return context.Students.Any(e => e.ID == id);
}
}
