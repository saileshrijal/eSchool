using eSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int GradeId { get; set; }

        public CourseViewModel()
        {

        }

        public CourseViewModel(Course model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            GradeId = model.GradeId;
        }

        public Course ConvertViewModel(CourseViewModel model)
        {
            return new Course
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                GradeId = model.GradeId,
            };
        }
    }
}
