using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyAdministration.Models
{
    public class Attendance
    {

        public int ID { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public DateTime DateTime { get; set; }

    }
}
