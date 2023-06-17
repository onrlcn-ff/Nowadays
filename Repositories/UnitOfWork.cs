using Nowadays.Models;
using static Nowadays.Data.AplicationDbContext;

namespace Nowadays.Repositories
{
  public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IRepository<Company> companyRepository;
    private IRepository<Project> projectRepository;
    private IRepository<Employee> employeeRepository;
    private IRepository<Issue> issueRepository;
    private IRepository<Report> reportRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<Company> CompanyRepository
    {
        get
        {
            return companyRepository = companyRepository ?? new Repository<Company>(_context);
        }
    }

    public IRepository<Project> ProjectRepository
    {
        get
        {
            return projectRepository = projectRepository ?? new Repository<Project>(_context);
        }
    }

    public IRepository<Employee> EmployeeRepository
    {
        get
        {
            return employeeRepository = employeeRepository ?? new Repository<Employee>(_context);
        }
    }

    public IRepository<Issue> IssueRepository
    {
        get
        {
            return issueRepository = issueRepository ?? new Repository<Issue>(_context);
        }
    }

    public IRepository<Report> ReportRepository
    {
        get
        {
            return reportRepository = reportRepository ?? new Repository<Report>(_context);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
} 
}