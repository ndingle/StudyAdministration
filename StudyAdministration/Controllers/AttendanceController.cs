using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyAdministration.Models;

namespace StudyAdministration.Controllers
{
    public class AttendanceController : Controller
    {

        private readonly StudyAdministrationContext _context;

        public AttendanceController(StudyAdministrationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var yearFilters = from y in _context.Student
                              orderby y.FinishYear
                              select y.FinishYear;

            var attendances = _context.Attendance
                .Include(a => a.Student)
                .Include(a => a.Subject)
                .OrderByDescending(a => a.DateTime);

            //var viewModel = new AttendanceFilterViewModel();
            //viewModel.Years = new SelectList(await yearFilters.Distinct().ToListAsync());
            //viewModel.Attendances = await attendances.ToListAsync();

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //}

            return View(attendances);
        }


        public async Task<IActionResult> FilterTest(string yearFilter, string subjectFilter)
        {
            var viewModel = new AttendanceFilterViewModel();

            var years = from y in _context.Student
                        orderby y.FinishYear
                        select y.FinishYear;

            var subjects = from s in _context.Subject
                           orderby s.Position
                           select s.Name;

            // Collect unique year values and convert them to the SelectListYear container to display correctly.
            viewModel.Years = new SelectList(await years.Distinct().Select(y =>
                new SelectListYear
                {
                    FinishYear = y
                }
            ).ToListAsync());

            viewModel.Subjects = new SelectList(await subjects.Distinct().ToListAsync());

            // Finally lets get those pesky attendance values
            var attendances = from a in _context.Attendance
                                .Include(a => a.Student)
                                .Include(a => a.Subject)
                                .OrderByDescending(a => a.DateTime)
                              select a;

            // Set the year filter
            if (!string.IsNullOrEmpty(yearFilter))
            {
                // This truly is ugly
                attendances = attendances.Where(a => (12 - (a.Student.FinishYear - DateTime.Now.Year)) == Convert.ToUInt16(yearFilter));
                viewModel.YearFilter = yearFilter;
            }

            // Set the subject filter
            if (!string.IsNullOrEmpty(subjectFilter))
            {
                // TODO: HOLY SHIT USE THE ID MAN!
                attendances = attendances.Where(a => a.Subject.Name == subjectFilter);
            }

            // Set the final filtered?? attendance data.
            viewModel.Attendances = await attendances.ToListAsync();

            return View(viewModel);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Student)
                .Include(a => a.Subject)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

    }
}