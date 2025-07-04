﻿
using Arib_Task.Areas.Manager.ViewModels.DepartmentViewModels;
using Arib_Task.Models;
using Arib_Task.Repository.Department_Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arib_Task.Areas.Manager.Controllers
{
    [Area("Manager")]

    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllWithEmployees();
            return View(departments);
        }
        public IActionResult CreateDepartment()
        {
            return View(new AddDepartmentViewModel());
        }
        [HttpPost]

        public async Task<IActionResult> CreateDepartment(AddDepartmentViewModel addDepartmentViewModel)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); 
                }
                return View(addDepartmentViewModel);
            }
            try
            {
                var category = _mapper.Map<Department>(addDepartmentViewModel);
                await _departmentRepository.Add(category);
                await _departmentRepository.SaveChanges();

                ViewBag.ShowSuccessModal = true;

                return View(new AddDepartmentViewModel()); // إعادة النموذج فاضي

            }

            catch
            {
                ModelState.AddModelError("", "حدث خطأ أثناء حفظ القسم.");
                return View(addDepartmentViewModel);
            }


        }

    }
}
