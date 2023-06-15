using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nowadays.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Issue> Issues { get; set; } = new List<Issue>(); 
    }
}