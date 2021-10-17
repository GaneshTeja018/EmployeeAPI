using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.FiberConnection;
using FiberConnection.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeeController));

        private readonly IEmployeeServ<Employee> e_serv;
        public EmployeeController(IEmployeeServ<Employee> _e_serv)
        {
            e_serv = _e_serv;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            _log4net.Info($"Getting All the Employee ");
            return Ok(await e_serv.GetAllEmployees());
        }
        [HttpPost]
        public async Task<IActionResult> AddEmpl(Employee e)
        {
            _log4net.Info($"Adding new the Employee by{e.Name}");
            return Ok(await e_serv.AddEmpl(e));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmp(int Empid, Employee e)
        {
            _log4net.Info($"Updating the Employee by{Empid}");
            return Ok(await e_serv.UpdateEmp(Empid, e));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Empid)
        {
            _log4net.Info($"Deleting the Employee by{Empid}");
            return Ok(await e_serv.DeleteEmployee(Empid));
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult GetLoginDetails(Employee e)
        {
            _log4net.Info($"Getting Login the Employee {e.EmployeeMail}");
            return Ok(e_serv.GetLoginDetails(e));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByEmployee(int id)
        {
            _log4net.Info($"Getting the Employee by{id}");
            return Ok(await e_serv.GetByEmployee(id));
        }
    }
}
