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
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            return _unitOfWork.CompanyRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompany(int id)
        {
            var company = _unitOfWork.CompanyRepository.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CompanyRepository.Update(company);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Company> CreateCompany(Company company)
        {
            _unitOfWork.CompanyRepository.Insert(company);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _unitOfWork.CompanyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            _unitOfWork.CompanyRepository.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}