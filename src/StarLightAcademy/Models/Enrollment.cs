﻿using System.ComponentModel.DataAnnotations;

namespace StarLightAcademy.Models;

public enum Grade
{
    A = 4, B = 3, C = 2, D = 1, F = 0
}
public class Enrollment
{
    public int ID { get; set; }

    public int CourseID { get; set; }

    public int StudentID { get; set; }

    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }

    public Course Course { get; set; } = null!;

    public Student Student { get; set; } = null!;
}