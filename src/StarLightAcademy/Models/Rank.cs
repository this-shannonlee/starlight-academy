using System.ComponentModel.DataAnnotations;

namespace StarLightAcademy.Models;

public class Rank
{
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    [Required]
    public required string Title { get; set; }

    public List<Student> Students { get; set; } = [];

}
