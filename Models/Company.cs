using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nowadays.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}