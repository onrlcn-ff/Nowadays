using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nowadays.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public List<Employee> AssignedEmployees { get; set; } = new List<Employee>();
    }
}