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

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _unitOfWork.ProjectRepository.GetAll();
        }

        // GET: api/Projects/5
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

        // PUT: api/Projects/5
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

        // POST: api/Projects
        [HttpPost]
        public ActionResult<Project> CreateProject(Project project)
        {
            _unitOfWork.ProjectRepository.Insert(project);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
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

