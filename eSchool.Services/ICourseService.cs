using eSchool.Utilities;
using eSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.Services
{
    public interface ICourseService
    {
        PagedResult<CourseViewModel> GetAll(int pageNumber, int pageSize);
        CourseViewModel GetCourseById(int id);
        void UpdateCourse(CourseViewModel course);
        void DeleteCourse(int id);
        void InsertCourse(CourseViewModel course);
    }
}
