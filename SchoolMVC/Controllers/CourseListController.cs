using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMVC.Data;
using System.Linq;
using SchoolMVC.Models;

namespace SchoolMVC.Controllers
{
    public class CourseListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseListController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Students
            var students = await _context.Students
                .OrderBy(s => s.FirstName)
                .ToListAsync();
            ViewBag.StudentList = new SelectList(students, "StudentId", "FullName");

            // Courses
            var courses = await _context.Courses.ToListAsync();
            ViewBag.CourseList = new SelectList(courses, "CourseId", "CourseName");

            return View();
        }

        public async Task<IActionResult> AllTeachers(int? CourseId)
        {
            if (CourseId == null || _context.CourseLists == null)
            {
                TempData["ErrorMessage"] = "You have to choose a course";
                return RedirectToAction("Index");
            }

            var teacherName = await _context.CourseLists
                            .Include(t => t.Teachers)
                            .Include(c => c.Courses)
                            .Where(c => c.FK_CourseId == CourseId)
                            .Select(t => t.Teachers.FullName)
                            .ToListAsync();

            if (teacherName == null)
            {
                return NotFound();
            }

            var distinctTeachersName = teacherName.Distinct();

            return View(distinctTeachersName);
        }


        public async Task<IActionResult> GetAllStudentsTeachers()
        {
            var allStudTeach = await _context.CourseLists
                .Include(cl => cl.Courses)
                .Include(cl => cl.Students)
                .Include(cl => cl.Teachers)
                .ToListAsync();

            var studTeachList = allStudTeach
                .GroupBy(cl => cl.Students)
                .Select(group => new
                {
                    Student = group.Key.FullName,
                    Teachers = group.Select(cl => cl.Teachers.FullName).Distinct().ToList()
                })
                .ToList();

            ViewBag.studTeachList = studTeachList;

            return View();
        }



        public async Task<IActionResult> StudentsTeachersInCourse(int? CourseId)
        {
            if (CourseId == null || _context.CourseLists == null)
            {
                TempData["ErrorMessage"] = "You have to choose a course";
                return RedirectToAction("Index");
            }

            var allList = await _context.CourseLists
                        .Include(t => t.Teachers)
                        .Include(s => s.Students)
                        .Include(c => c.Courses)
                        .Where(c => c.FK_CourseId == CourseId)
                        .ToListAsync();

            if (allList == null)
            {
                return NotFound();
            }

            ViewBag.studList = allList.Select(s => s.Students.FullName);
            ViewBag.teachList = allList.Select(t => t.Teachers.FullName).Distinct();
            return View();
        }


        // GET CourseList
        public async Task<IActionResult> ChangeTeacher(int? StudentId, int? CourseId)
        {
            if (TempData.ContainsKey("StudentId"))
            {
                StudentId = (int)TempData["StudentId"];
                CourseId = (int)TempData["CourseId"];

            }

            if (StudentId == null || CourseId == null)
            {
                TempData["ErrorMessage"] = "You have to choose a student and a course";
                return RedirectToAction("Index");
            }

            // All info
            var studentCourses = await _context.CourseLists
                    .Include(t => t.Teachers)
                    .Include(s => s.Students)
                    .Include(c => c.Courses)
                    .Where(c => c.FK_StudentId == StudentId && c.FK_CourseId == CourseId)
                    .ToListAsync();

            if (!studentCourses.Any())
            {
                TempData["ErrorMessage"] = "This student doesn't take this course";
                return RedirectToAction("Index");
            }

            // Teachers
            var teachers = await _context.CourseLists
                    .Include(t => t.Teachers)
                    .Include(c => c.Courses)
                    .Where(c => c.FK_CourseId == CourseId)
                    .Select(t => t.Teachers)
                    .Distinct()
                    .ToListAsync();

            // CourseLists
            var courseList = await _context.CourseLists
                    .SingleOrDefaultAsync(c => c.FK_StudentId == StudentId && c.FK_CourseId == CourseId);

            if (courseList == null)
            {
                TempData["ErrorMessage"] = "The specified course list does not exist.";
                return RedirectToAction("Index");
            }



            ViewBag.Teachers = new SelectList(teachers, "TeacherId", "FullName");
            ViewBag.StudentName = studentCourses.Select(s => s.Students.FullName);
            ViewBag.TeacherName = studentCourses.Select(s => s.Teachers.FullName).ToList();          
            ViewBag.SelectedCourse = studentCourses.Select(c => c.Courses.CourseName);
            ViewData["CourseListId"] = courseList.CourseListId;

            return View(courseList);

        }

        // POST CourseList
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CourseList>> ChangeTeacherPOST(int TeacherId, int CourseListId)
        {
            var courseListList = await _context.CourseLists
                                .Where(c => c.CourseListId == CourseListId)
                                .FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                courseListList.FK_TeacherId = TeacherId;
                _context.Update(courseListList);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Teacher succefully changed";
                return RedirectToAction("ChangeTeacher");
            }
            else
            {
                int id1 = courseListList.FK_StudentId;
                TempData["StudentId"] = id1;
                int id2 = courseListList.FK_CourseId;
                TempData["CourseId"] = id2;
                TempData["ErrorMessage"] = "You have to choose a teacher";
                return RedirectToAction("ChangeTeacher");
            }
        }
    }
}
