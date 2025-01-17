﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class DetailsModel(StarLightAcademy.Data.StarLightAcademyContext context) : PageModel
{
    public Student Student { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await context.Students
            .AsNoTracking()
            .Include(s => s.Rank)
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.ID == id);

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
}
