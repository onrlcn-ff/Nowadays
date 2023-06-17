using Nowadays.Models;

namespace Nowadays.Repositories
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> CompanyRepository { get; }
        IRepository<Project> ProjectRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Issue> IssueRepository { get; }
        IRepository<Report> ReportRepository { get; }
        void Save();
    } 
    
}