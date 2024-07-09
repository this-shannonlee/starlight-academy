using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarLightAcademy.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Required]
    public required string Title { get; set; }

    public int Credits { get; set; }

    public List<Enrollment> Enrollments { get; set; } = [];
}