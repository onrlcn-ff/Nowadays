using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models;
using Nowadays.Repositories;
using Nowadays.Services;

namespace NowadaysProject.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeServices _employeeServices;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeeServices = new EmployeeServices();
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            if(!_employeeServices.TCKimlikNoDogrula(employee.TcNo,employee.Name,employee.Surname, employee.BirtYear))
                return BadRequest("Tc Kimlik Numaranız Doğrulanamadı");

            _unitOfWork.EmployeeRepository.Insert(employee);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _unitOfWork.EmployeeRepository.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}