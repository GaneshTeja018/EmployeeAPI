using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.FiberConnection;
using FiberConnection.FiberConnection;

namespace FiberConnection.Repository
{
    public class EmployeeRepo:IEmployeeRepo<Employee>
    {
        private readonly IEmployee<Employee> e_obj;
        public EmployeeRepo(IEmployee<Employee> _e_obj)
        {
            e_obj = _e_obj;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await e_obj.GetAllEmployees();


        }
        public async Task<Employee> UpdateEmp(int Empid, Employee e)
        {
            return await e_obj.UpdateEmp(Empid, e);

        }
        public async Task<Employee> AddEmpl(Employee e)
        {
            return await e_obj.AddEmpl(e);
        }

        public async Task<Employee> DeleteEmployee(int Empid)
        {
            return await e_obj.DeleteEmployee(Empid);

        }

        public Employee GetLoginDetails(Employee e)
        {
            return e_obj.GetLoginDetails(e);
        }
        public async Task<Employee> GetByEmployee(int id)
        {
            return await e_obj.GetByEmployee(id);
        }
    }
}
