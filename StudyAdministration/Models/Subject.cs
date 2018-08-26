using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudyAdministration.Models
{
    public class Subject
    {

        public int ID { get; set; }
        public uint Position { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(100)]
        public string Name { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

    }
}
