using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyAdministration.Models;

namespace StudyAdministration.Data
{
    public static class SeedData
    {

        public static void Initialise(IServiceProvider serviceProvider)
        {

            // Grab the database context to add data to
            using (var context = new StudyAdministrationContext(
                serviceProvider.GetRequiredService<DbContextOptions<StudyAdministrationContext>>()))
            {

                // If there aren't any students add them
                if (!context.Student.Any())
                {
                    context.Student.AddRange(
                        new Student
                        {
                            OasisID = 123456,
                            Firstname = "Bobby",
                            Lastname = "Bob",
                            FinishYear = 2019
                        },

                        new Student
                        {
                            OasisID = 123457,
                            Firstname = "Jillian",
                            Lastname = "Jill",
                            FinishYear = 2019
                        },

                        new Student
                        {
                            OasisID = 123458,
                            Firstname = "Dong",
                            Lastname = "Wong",
                            FinishYear = 2019
                        },

                        new Student
                        {
                            OasisID = 123459,
                            Firstname = "Peter",
                            Lastname = "Pastor",
                            FinishYear = 2020
                        },

                        new Student
                        {
                            OasisID = 123461,
                            Firstname = "Broken",
                            Lastname = "Brian",
                            FinishYear = 2020
                        },

                        new Student
                        {
                            OasisID = 123462,
                            Firstname = "Nancy",
                            Lastname = "Thorn",
                            FinishYear = 2020
                        }

                    );

                    context.SaveChanges();

                }

                // If there aren't any subjects add them
                if (!context.Subject.Any())
                {
                    context.Subject.AddRange(
                        new Subject
                        {
                            Position = 1,
                            Name = "English"
                        },

                        new Subject
                        {
                            Position = 2,
                            Name = "Maths"
                        },

                        new Subject
                        {
                            Position = 3,
                            Name = "Science"
                        },

                        new Subject
                        {
                            Position = 4,
                            Name = "HSIE"
                        },

                        new Subject
                        {
                            Position = 5,
                            Name = "PDHPE"
                        },

                        new Subject
                        {
                            Position = 6,
                            Name = "CAPA"
                        },

                        new Subject
                        {
                            Position = 7,
                            Name = "TAS"
                        },

                        new Subject
                        {
                            Position = 8,
                            Name = "Computing"
                        }

                    );

                    context.SaveChanges();

                }

                // If there isn't any attendance data, add it in
                if (!context.Attendance.Any())
                {
                    context.Attendance.AddRange(
                        new Attendance
                        {
                            StudentID = 1,
                            SubjectID = 1,
                            DateTime = new DateTime(2018, 8, 24, 9, 40, 0, 0)
                        },

                        new Attendance
                        {
                            StudentID = 2,
                            SubjectID = 1,
                            DateTime = new DateTime(2018, 8, 24, 9, 40, 30, 0)
                        },

                        new Attendance
                        {
                            StudentID = 3,
                            SubjectID = 1,
                            DateTime = new DateTime(2018, 8, 24, 9, 41, 0, 0)
                        },

                        new Attendance
                        {
                            StudentID = 4,
                            SubjectID = 1,
                            DateTime = new DateTime(2018, 8, 24, 9, 42, 0, 0)
                        },

                        new Attendance
                        {
                            StudentID = 1,
                            SubjectID = 2,
                            DateTime = new DateTime(2018, 8, 23, 12, 10, 0, 0)
                        },

                        new Attendance
                        {
                            StudentID = 2,
                            SubjectID = 3,
                            DateTime = new DateTime(2018, 8, 23, 12, 12, 0, 0)
                        },

                        new Attendance
                        {
                            StudentID = 3,
                            SubjectID = 4,
                            DateTime = new DateTime(2018, 8, 23, 12, 20, 0, 0)
                        }

                    );

                }

                context.SaveChanges();

            }
        }

    }
}
