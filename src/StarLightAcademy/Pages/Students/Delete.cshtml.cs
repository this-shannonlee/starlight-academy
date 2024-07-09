﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class DeleteModel(Data.StarLightAcademyContext context) : PageModel
{
    [BindProperty]
    public Student Student { get; set; } = default!;

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
        else
        {
            Student = student;
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
        if (student != null)
        {
            Student = student;
            context.Students.Remove(Student);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}