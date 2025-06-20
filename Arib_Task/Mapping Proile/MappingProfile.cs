using Arib_Task.Areas.Manager.ViewModels.DepartmentViewModels;
using Arib_Task.Areas.Manager.ViewModels.EmployeeViewModel;
using Arib_Task.Areas.Manager.ViewModels.EmployeeViewModels;
using Arib_Task.Models;
using AutoMapper;

namespace Arib_Task.Mapping_Proile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Department
            CreateMap<Department,AddDepartmentViewModel>().ReverseMap();

            CreateMap<Employee, AddEmployeeViewModel>().ReverseMap();


            CreateMap<Employee, EmployeeDetailsViewModel>()
    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Name))
    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
    //.ForMember(dest => dest.TaskTitles, opt => opt.MapFrom(src => src.Tasks.Select(t => t.Title).ToList()));

        }
    }
}
