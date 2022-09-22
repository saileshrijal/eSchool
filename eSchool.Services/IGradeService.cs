using eSchool.Utilities;
using eSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.Services
{
    public interface IGradeService
    {
        PagedResult<GradeViewModel> GetAll(int pageNumber, int pageSize);
        GradeViewModel GetGradeById(int id);
        void UpdateGrade(GradeViewModel model);
        void DeleteGrade(int id);
        void InsertGrade(GradeViewModel model); 
    }
}
