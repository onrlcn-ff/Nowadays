using Microsoft.AspNetCore.Mvc;
using Nowadays.Models;
using Nowadays.Repositories;

namespace NowadaysProject.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _unitOfWork.ProjectRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _unitOfWork.ProjectRepository.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProjectRepository.Update(project);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            _unitOfWork.ProjectRepository.Insert(project);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _unitOfWork.ProjectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            _unitOfWork.ProjectRepository.Delete(id);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}

