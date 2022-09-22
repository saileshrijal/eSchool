using eSchool.Services;
using eSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eSchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_gradeService.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_gradeService.GetGradeById(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            return View(grade);
        }

        [HttpPost]
        public IActionResult Edit(GradeViewModel vm)
        {
            _gradeService.UpdateGrade(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GradeViewModel vm)
        {
            _gradeService.InsertGrade(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _gradeService.DeleteGrade(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
