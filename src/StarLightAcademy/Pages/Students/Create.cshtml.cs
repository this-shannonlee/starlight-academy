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

        //context.Students.Add(Student);
        //await context.SaveChangesAsync();

        //return RedirectToPage("./Index");

        //var emptyStudent = new Student();

        //if (await TryUpdateModelAsync<Student>(
        //    emptyStudent,
        //    "student",   // Prefix for form value.
        //    s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
        //{
        //    _context.Students.Add(emptyStudent);
        //    await _context.SaveChangesAsync();
        //    return RedirectToPage("./Index");
        //}
        Student newStudent = new()
        {
            Rank = Student.Rank,
            LastName = Student.LastName,
            FirstName = Student.FirstName,
            Species = Student.Species,
            DOB = Student.DOB,
        };

        if (await TryUpdateModelAsync<Student>(newStudent))
        {
            context.Students.Add(newStudent);
            await context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        return Page();
    }
}
