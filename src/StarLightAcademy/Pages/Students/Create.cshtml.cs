using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class CreateModel(Data.StarLightAcademyContext context) : PageModel
{
    public IActionResult OnGet()
    {
        ViewData["Rank"] = new SelectList(context.Ranks, "ID", "Title");
        return Page();
    }

    [BindProperty]
    public Student Student { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Students.Add(Student);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
