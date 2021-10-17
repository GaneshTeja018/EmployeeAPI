using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FiberConnection.FiberConnection;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EmployeeAPI.FiberConnection
{
    public partial class Employee:IEmployee<Employee>
    {
        private readonly fiber_connectionContext fcc = new fiber_connectionContext();
        public Employee()
        {
            Statuses = new HashSet<Status>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string WorkLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePassword { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await fcc.Employees.ToListAsync();
        }
        public async Task<Employee> UpdateEmp(int Empid, Employee e)
        {
            fcc.Entry(e).State = EntityState.Modified;
            await fcc.SaveChangesAsync();
            return (await fcc.Employees.FindAsync(Empid));

        }
        public async Task<Employee> AddEmpl(Employee e)
        {
            fcc.Employees.Add(e);
            await fcc.SaveChangesAsync();
            return (e);

        }
        public async Task<Employee> DeleteEmployee(int Empid)
        {
            Employee e = fcc.Employees.Find(Empid);
            fcc.Employees.Remove(e);
            await fcc.SaveChangesAsync();
            return (e);

        }

        public Employee GetLoginDetails(Employee e)
        {
            Employee result = (from i in fcc.Employees
                               where i.EmployeeMail == e.EmployeeMail && i.EmployeePassword == e.EmployeePassword 
                               select i).FirstOrDefault();
            return result;
        }
        public async Task<Employee> GetByEmployee(int id)
        {
            return await (fcc.Employees.FindAsync(id));
        }
    }
}
