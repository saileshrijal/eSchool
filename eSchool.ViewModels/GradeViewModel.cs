using eSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.ViewModels
{
    public class GradeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GradeViewModel()
        {

        }

        public GradeViewModel(Grade model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
        }

        public Grade ConvertViewModel(GradeViewModel model)
        {
            return new Grade
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
