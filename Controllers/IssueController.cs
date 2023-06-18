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
    public class IssueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Issue> GetIssues()
        {
            return _unitOfWork.IssueRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Issue> GetIssue(int id)
        {
            var issue = _unitOfWork.IssueRepository.GetById(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }

            _unitOfWork.IssueRepository.Update(issue);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Issue> CreateIssue(Issue issue)
        {
            _unitOfWork.IssueRepository.Insert(issue);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetIssue), new { id = issue.Id }, issue);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIssue(int id)
        {
            var issue = _unitOfWork.IssueRepository.GetById(id);
            if (issue == null)
            {
                return NotFound();
            }

            _unitOfWork.IssueRepository.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}