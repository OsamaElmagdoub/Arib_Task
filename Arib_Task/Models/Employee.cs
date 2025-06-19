using System.ComponentModel.DataAnnotations.Schema;

namespace Arib_Task.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
       
        public string? ImageUrl { get; set; }

        public int ManagerId { get; set; }    
        public Manager Manager { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<EmpTask> Tasks { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

    }
}
