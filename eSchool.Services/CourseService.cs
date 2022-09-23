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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteCourse(int id)
        {
            var model = _unitOfWork.GenericRepository<Course>().GetById(id);
            _unitOfWork.GenericRepository<Course>().Delete(model);
            _unitOfWork.save();
        }

        public PagedResult<CourseViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new CourseViewModel();
            int totalCount;
            List<CourseViewModel> vmList = new List<CourseViewModel>();
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Course>().GetAll()
                                    .Skip(excludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Course>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {

                throw;
            }
            var result = new PagedResult<CourseViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<CourseViewModel> ConvertModelToViewModelList(List<Course> modelList)
        {
            return modelList.Select(x => new CourseViewModel(x)).ToList();
        }

        public CourseViewModel GetCourseById(int id)
        {
            var model = _unitOfWork.GenericRepository<Course>().GetById(id);
            var vm = new CourseViewModel(model);
            return vm;
        }

        public void InsertCourse(CourseViewModel course)
        {
            var model = new CourseViewModel().ConvertViewModel(course);
            _unitOfWork.GenericRepository<Course>().Add(model);
            _unitOfWork.save();

        }

        public void UpdateCourse(CourseViewModel course)
        {
            var model = new CourseViewModel().ConvertViewModel(course);
            var modelById = _unitOfWork.GenericRepository<Course>().GetById(model.Id);
            modelById.Name = model.Name;
            modelById.Description = model.Description;
            modelById.Grade = model.Grade;

            _unitOfWork.GenericRepository<Course>().Update(modelById);
            _unitOfWork.save();
        }
    }
}
