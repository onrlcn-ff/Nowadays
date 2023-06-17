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
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reports
        [HttpGet]
        public IEnumerable<Report> GetReports()
        {
            return _unitOfWork.ReportRepository.GetAll();
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public ActionResult<Report> GetReport(int id)
        {
            var report = _unitOfWork.ReportRepository.GetById(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public IActionResult UpdateReport(int id, Report report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ReportRepository.Update(report);
            _unitOfWork.Save();

            return NoContent();
        }

        // POST: api/Reports
        [HttpPost]
        public ActionResult<Report> CreateReport(Report report)
        {
            _unitOfWork.ReportRepository.Insert(report);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            var report = _unitOfWork.ReportRepository.GetById(id);
            if (report == null)
            {
                return NotFound();
            }

            _unitOfWork.ReportRepository.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}