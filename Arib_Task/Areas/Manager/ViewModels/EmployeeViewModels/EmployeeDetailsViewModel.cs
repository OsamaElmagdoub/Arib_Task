namespace Arib_Task.Areas.Manager.ViewModels.EmployeeViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public string? ImageUrl { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
    }

}
