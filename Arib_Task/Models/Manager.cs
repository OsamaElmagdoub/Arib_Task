namespace Arib_Task.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<EmpTask> Tasks { get; set; }
    }
}
