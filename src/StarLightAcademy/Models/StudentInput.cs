using System.ComponentModel.DataAnnotations;

namespace StarLightAcademy.Models;

public class StudentInput
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

    [Display(Name = "Birth Date"), DisplayFormat(DataFormatString = "{0:D}"), DataType(DataType.Date)]
    public DateOnly DOB { get; set; }

    public List<Enrollment> Enrollments { get; set; } = [];


    public Student Create()
    {
        return new Student
        {
            RankID = RankID,
            Rank = Rank,
            LastName = LastName,
            FirstName = FirstName,
            Species = Species,
            DOB = DOB,
            Enrollments = Enrollments,
        };
    }

    public Student Update(Student current)
    {
        current.RankID = RankID;
        current.Rank = Rank;
        current.LastName = LastName;
        current.FirstName = FirstName;
        current.Species = Species;
        current.DOB = DOB;
        current.Enrollments = Enrollments;
        return current;
    }
}
