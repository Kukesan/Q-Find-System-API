using System.ComponentModel.DataAnnotations;

namespace Qfind.Models
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }
        public int Category { get; set; }
        public string? ContactName { get; set; }
        public int ContactNumber { get; set; }
        public int SeatsCount { get; set; }
        public string? DateTime { get; set; }
        public string? Description { get; set; }
    }
}
