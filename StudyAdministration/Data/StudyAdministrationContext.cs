using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyAdministration.Models;

namespace StudyAdministration.Models
{
    public class StudyAdministrationContext : DbContext
    {
        public StudyAdministrationContext (DbContextOptions<StudyAdministrationContext> options)
            : base(options)
        {
        }

        public DbSet<StudyAdministration.Models.Student> Student { get; set; }
        public DbSet<StudyAdministration.Models.Subject> Subject { get; set; }
        public DbSet<StudyAdministration.Models.Attendance> Attendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Determine if this is required?
            //modelBuilder.Entity<Attendance>()
            //    .HasKey(l => new { l.StudentID, l.SubjectID});

            modelBuilder.Entity<Attendance>()
                .HasOne(l => l.Student)
                .WithMany(m => m.Attendances)
                .HasForeignKey(l => l.StudentID);

            modelBuilder.Entity<Attendance>()
                .HasOne(l => l.Subject)
                .WithMany(c => c.Attendances)
                .HasForeignKey(l => l.SubjectID);

        }

    }

}
