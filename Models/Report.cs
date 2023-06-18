
using System.ComponentModel.DataAnnotations;

namespace Nowadays.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int ProjectId { get; set; }
    }

}