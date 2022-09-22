using eSchool.Models;
using eSchool.Repository.Interface;
using eSchool.Utilities;
using eSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteGrade(int id)
        {
            var model = _unitOfWork.GenericRepository<Grade>().GetById(id);
            _unitOfWork.GenericRepository<Grade>().Delete(model);
            _unitOfWork.save(); 
        }

        public PagedResult<GradeViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new GradeViewModel();
            int totalCount;
            List<GradeViewModel> vmList = new List<GradeViewModel>();
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Grade>().GetAll()
                                    .Skip(excludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Grade>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<GradeViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;  
        }

        private List<GradeViewModel> ConvertModelToViewModelList(List<Grade> modelList)
        {
            return modelList.Select(x => new GradeViewModel(x)).ToList();
        }

        public GradeViewModel GetGradeById(int id)
        {
            var model = _unitOfWork.GenericRepository<Grade>().GetById(id);
            var vm = new GradeViewModel(model);
            return vm;
        }

        public void InsertGrade(GradeViewModel model)
        {
            var grade = new GradeViewModel().ConvertViewModel(model);
            _unitOfWork.GenericRepository<Grade>().Add(grade);
            _unitOfWork.save();
        }

        public void UpdateGrade(GradeViewModel model)
        {
            var grade = new GradeViewModel().ConvertViewModel(model);
            var modelById = _unitOfWork.GenericRepository<Grade>().GetById(grade.Id);
            modelById.Name = model.Name;
            _unitOfWork.save();
        }
    }
}
