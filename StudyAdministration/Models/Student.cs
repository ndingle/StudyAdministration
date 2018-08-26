using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudyAdministration.Models
{
    public class Student
    {
        public int ID { get; set; }
        public uint? UID { get; set; }
        public int OasisID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Range(2018, 2100)]
        public ushort FinishYear { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<Attendance> Attendances { get; set; }

        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
    }
}
