﻿using TallinnaRakenduslikKolledzKaur.Models;


namespace TallinnaRakenduslikKolledzKaur.Data
{
    public class Dbinitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstName = "George",LastName = "Teemus",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Abra",LastName = "Kadabra",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Nipi",LastName = "Tiri",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "BA",LastName = "ZOOKA",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Pori",LastName = "Kärbes",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Tori",LastName = "Hobune",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Alev",LastName = "Ström",EnrollmentDate = DateTime.Now },
                new Student{FirstName = "Super",LastName = "Mario",EnrollmentDate = DateTime.Now }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            if (context.Courses.Any()) {return; }
            var courses = new Course[]
            {
                new Course{CourseId=1001, Title="Programmeerimise Alused", Credits=3 },
                new Course{CourseId=2002, Title="Programmeerimise 1", Credits=6 },
                new Course{CourseId=3003, Title="Programmeerimise 2", Credits=9 },
                new Course{CourseId=2003, Title="Tarkvara Arendusprotsess", Credits=3 },
                new Course{CourseId=1002, Title="Multimeedia", Credits=3 },
                new Course{CourseId=3001, Title="Hajusrakenduste Alused", Credits=3 },
                new Course{CourseId=9001, Title="Crypto 101", Credits=0 },
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            if (context.Enrollments.Any()) { return; }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=1, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=2, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment{StudentID=2, CourseID=1002, CurrentGrade=Grade.MA},
                new Enrollment{StudentID=3, CourseID=1001, CurrentGrade=Grade.C},
                new Enrollment{StudentID=3, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment{StudentID=4, CourseID=1002, CurrentGrade=Grade.D},
                new Enrollment{StudentID=4, CourseID=2003, CurrentGrade=Grade.F},
                new Enrollment{StudentID=5, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=5, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=6, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment{StudentID=6, CourseID=1002, CurrentGrade=Grade.MA},
                new Enrollment{StudentID=7, CourseID=1001, CurrentGrade=Grade.C},
                new Enrollment{StudentID=7, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment{StudentID=8, CourseID=1002, CurrentGrade=Grade.D},
                new Enrollment{StudentID=8, CourseID=2003, CurrentGrade=Grade.F},
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            if (context.Instructors.Any()) { return; }
            var instructors = new Instructor[]
            {
                new Instructor{ FirstName="DONKEH", LastName="Dragon", HireDate=DateTime.Now, VacationDays=4},
                new Instructor{ FirstName="SHREK", LastName="Ö G E R", HireDate=DateTime.Now, VacationDays=999},
                new Instructor{ FirstName="Abra", LastName="HamLincoln", HireDate=DateTime.Now, VacationDays=2},
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }
    }
}
