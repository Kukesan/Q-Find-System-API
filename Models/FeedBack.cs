using System.ComponentModel.DataAnnotations;

namespace Qfind.Models
{
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
