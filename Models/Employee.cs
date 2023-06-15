using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nowadays.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TcNo { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        
    }
}