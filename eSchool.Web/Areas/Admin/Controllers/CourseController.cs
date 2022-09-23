using eSchool.Services;
using eSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eSchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_courseService.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = _courseService.GetCourseById(id);
            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = _courseService.GetCourseById(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel vm)
        {
            _courseService.UpdateCourse(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel vm)
        {
            _courseService.InsertCourse(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
