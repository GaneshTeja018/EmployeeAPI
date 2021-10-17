using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiberConnection.FiberConnection
{
    public interface IEmployee<Employee>
    {
        public Task<List<Employee>> GetAllEmployees();
        public  Task<Employee> UpdateEmp(int Empid, Employee e);

        public Task<Employee> AddEmpl(Employee e);
        public  Task<Employee> DeleteEmployee(int Empid);
        public Employee GetLoginDetails(Employee e);
        public Task<Employee> GetByEmployee(int id);

    }
}
