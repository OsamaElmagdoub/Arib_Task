namespace Arib_Task.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Manager> Managers { get; set; }

    }
}
