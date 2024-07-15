using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarLightAcademy.Models;

namespace StarLightAcademy.Pages.Students;

public class IndexModel(StarLightAcademy.Data.StarLightAcademyContext context, IConfiguration configuration) : PageModel
{
    public PaginatedList<Student> Students { get; set; } = default!;
    public string? NameSort { get; set; }
    public string? DateSort { get; set; }
    public string? CurrentFilter { get; set; }
    public string? CurrentSort { get; set; }

    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
    {
        CurrentSort = sortOrder;
        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        DateSort = sortOrder == "Date" ? "date_desc" : "Date";
        if (searchString != null)
        {
            pageIndex = 1;
        }
        else
        {
            searchString = currentFilter;
        }


        CurrentFilter = searchString;

        IQueryable<Student> studentsIQ = from s in context.Students select s;

        if (!String.IsNullOrEmpty(searchString))
        {
            studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
        }

        studentsIQ = sortOrder switch
        {
            "name_desc" => studentsIQ.OrderByDescending(s => s.LastName),
            "Date" => studentsIQ.OrderBy(s => s.DOB),
            "date_desc" => studentsIQ.OrderByDescending(s => s.DOB),
            _ => studentsIQ.OrderBy(s => s.LastName),
        };

        var pageSize = configuration.GetValue("PageSize", 4);
        Students = await PaginatedList<Student>.CreateAsync(
            studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
    }
}
