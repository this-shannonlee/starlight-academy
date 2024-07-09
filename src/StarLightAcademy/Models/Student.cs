using System.ComponentModel.DataAnnotations;

namespace StarLightAcademy.Models;

public class Student
{
    public int ID { get; set; }

    public int RankID { get; set; }

    public Rank? Rank { get; set; }

    [Required, Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [Required, Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [Required]
    public required string Species { get; set; }

    [Display(Name = "Birth Date"), DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
    public DateTime DOB { get; set; }

    public List<Enrollment> Enrollments { get; set; } = [];
}
