using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudyAdministration.Models
{
    
    /// <summary>
    /// Used to fix the display issues I was having with SelectListItem container (fuck that guy)
    /// </summary>
    public class SelectListYear
    {
        public ushort FinishYear { get; set; }

        public string DisplayYear
        {
            get
            {
                return (12 - (FinishYear - DateTime.Now.Year)).ToString();
            }
        }

        public override string ToString()
        {
            return DisplayYear;
        }

    }

    /// <summary>
    /// View model used by the Attendance Index action to filter data, like a pro.
    /// </summary>
    public class AttendanceFilterViewModel
    {
        public List<Attendance> Attendances;
        public SelectList Years;
        public string YearFilter { get; set; } = "";
        public SelectList Subjects;
        public string SubjectFilter { get; set; } = "";
    }
}
