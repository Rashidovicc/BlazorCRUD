using Game.Web.Data.Domain;

namespace Game.Web.Data.Service
{
    public interface IEmployeeService
    {
        List<Employee> Employees { get; set; }
        Task LoadEmployees();
        Task<Employee> GetSingleEmployee(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee, int id);
        Task DeleteEmployee(int id);
    }
}
