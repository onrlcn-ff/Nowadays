using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models;
using Nowadays.Repositories;

namespace NowadaysProject.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        // GET: api/Employees/5
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

        // PUT: api/Employees/5
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

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> CreateEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Insert(employee);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
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