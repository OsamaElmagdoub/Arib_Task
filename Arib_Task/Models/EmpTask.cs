namespace Arib_Task.Models
{
    public class EmpTask
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
