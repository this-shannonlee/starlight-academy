using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarLightAcademy.Models;

public class Student : StudentInput
{
    [Column(TypeName = "decimal(4, 3)"), DisplayFormat(DataFormatString = "{0:0.00}")]
    public decimal GPA { get; set; }
}
