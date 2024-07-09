﻿using StarLightAcademy.Models;

namespace StarLightAcademy.Data;

public static class DbInitializer
{
    public static void Initialize(StarLightAcademyContext context)
    {
        // Look for any students.
        if (context.Students.Any())
        {
            return;   // DB has been seeded
        }

        List<Rank> ranks =
        [
            new Rank() {ID = 200, Title = "Captian"},
            new Rank() {ID = 230, Title = "Commander"},
            new Rank() {ID = 250, Title = "Lieutenant Commander"},
            new Rank() {ID = 300, Title = "Lieutenant"},
            new Rank() {ID = 350, Title = "Lieutenant Junior Grade"},
            new Rank() {ID = 400, Title = "Ensign"},
            new Rank() {ID = 450, Title = "Crewman"},
            new Rank() {ID = 700, Title = "Chief Science Officer"},
            new Rank() {ID = 800, Title = "Chief Medical Officer"},
            new Rank() {ID = 820, Title = "Nurse"},
        ];

        context.Ranks.AddRange(ranks);
        context.SaveChanges();

        List<Student> students =
        [
            new() // ID = 1
            {
                FirstName = "Jean-Luc",
                LastName = "Picard",
                RankID = 200,
                Species = "Human",
                DOB = new DateTime(2305,07,13,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 2
            {
                FirstName = "Will",
                LastName = "Riker",
                RankID = 230,
                Species = "Human",
                DOB = new DateTime(2335,08,19,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 3
            {
                FirstName = "NFN",
                LastName = "Data",
                RankID = 250,
                Species="Android",
                DOB = new DateTime(2338,02,02,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 4
            {
                FirstName = "Geordi",
                LastName = "La Forge",
                RankID = 350,
                Species = "Human",
                DOB = new DateTime(2035,02,16,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 5
            {
                FirstName = "Deanna",
                LastName = "Troi",
                RankID = 250,
                Species = "Betazoid / Human",
                DOB = new DateTime(2335,03,29,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 6
            {
                FirstName = "Worf",
                LastName = "Son of Mogh",
                RankID = 350,
                Species = "Klingon",
                DOB = new DateTime(2340,01,01,0,0,0,DateTimeKind.Utc)
            },
            new() // ID = 7
            {
                FirstName = "Beverly",
                LastName = "Crusher",
                RankID = 800,
                Species = "Human",
                DOB = new DateTime(2324,10,13,0,0,0,DateTimeKind.Utc)
            }
        ];

        context.Students.AddRange(students);
        context.SaveChanges();

        List<Course> courses =
        [
            new Course { ID = 1050, Title = "Living Amongst Humans", Credits = 2 },
            new Course { ID = 1080, Title = "Maintaing a Healthy Personal Life", Credits = 2 },
            new Course { ID = 1100, Title = "Navigating a Your Career in StarFleet", Credits = 2 },
            new Course { ID = 1363, Title = "Andriod Legal Rights", Credits = 3 },
            new Course { ID = 1370, Title = "Becoming a Federation Ambassador", Credits = 3 },
            new Course { ID = 1829, Title = "Interpreting Pyschology as an Empath", Credits = 3 },
            new Course { ID = 1929, Title = "Exploring the Borg Hive Mind", Credits = 3 },
            new Course { ID = 1912, Title = "Q Continuum Relations", Credits = 3 },
            new Course { ID = 4041, Title = "Antimatter Containment ", Credits = 5 },
            new Course { ID = 3845, Title = "Positronic  Brain Theories", Credits = 4 },
            new Course { ID = 3141, Title = "Advanced Planetary Defense", Credits = 4 },
            new Course { ID = 3185, Title = "Advanced Tactical Strategies", Credits = 3 },
            new Course { ID = 2042, Title = "Working with Nanites", Credits = 4 },
            new Course { ID = 2870, Title = "Barclay's Protomorphosis Syndrome ", Credits = 3 }
        ];

        context.Courses.AddRange(courses);
        context.SaveChanges();

        List<Enrollment> enrollments =
        [
            new Enrollment { StudentID = 1, CourseID = 3185, Grade = Grade.A },
            new Enrollment { StudentID = 1, CourseID = 1929, Grade = Grade.B },
            new Enrollment { StudentID = 1, CourseID = 1912, Grade = Grade.B },
            new Enrollment { StudentID = 2, CourseID = 3185, Grade = Grade.A },
            new Enrollment { StudentID = 2, CourseID = 1100 },
            new Enrollment { StudentID = 2, CourseID = 1080, Grade = Grade.A },
            new Enrollment { StudentID = 3, CourseID = 1050, Grade = Grade.A },
            new Enrollment { StudentID = 3, CourseID = 3845 },
            new Enrollment { StudentID = 3, CourseID = 1363 },
            new Enrollment { StudentID = 4, CourseID = 4041 },
            new Enrollment { StudentID = 4, CourseID = 3141, Grade = Grade.F },
            new Enrollment { StudentID = 5, CourseID = 1829, Grade = Grade.C },
            new Enrollment { StudentID = 5, CourseID = 1050, Grade = Grade.A },
            new Enrollment { StudentID = 6, CourseID = 1050, Grade = Grade.F },
            new Enrollment { StudentID = 6, CourseID = 1370 },
            new Enrollment { StudentID = 7, CourseID = 2042, Grade = Grade.A },
            new Enrollment { StudentID = 7, CourseID = 2870, Grade = Grade.D },
        ];

        context.Enrollments.AddRange(enrollments);
        context.SaveChanges();
    }



}