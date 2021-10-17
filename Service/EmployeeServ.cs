using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.FiberConnection;
using FiberConnection.FiberConnection;
using FiberConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiberConnection.Service
{
    public class EmployeeServ:IEmployeeServ<Employee>
    {
        private readonly IEmployeeRepo<Employee> e_repo;
        public EmployeeServ(IEmployeeRepo<Employee> _e_repo)
        {
            e_repo = _e_repo;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
           return await e_repo.GetAllEmployees();
            

        }
        public async Task<Employee> UpdateEmp(int Empid, Employee e)
        {
            return await e_repo.UpdateEmp(Empid, e);

        }
           public async Task<Employee> AddEmpl(Employee e)
        {
            return await e_repo.AddEmpl(e);
        }

        public async Task<Employee> DeleteEmployee(int Empid)
        {
            return await e_repo.DeleteEmployee(Empid);

        }

        public Employee GetLoginDetails(Employee e)
        {
            return e_repo.GetLoginDetails(e);
        }
        public async Task<Employee> GetByEmployee(int id)
        {
            return await e_repo.GetByEmployee(id);
        }

    }
}
