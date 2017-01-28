using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWarfares.Data.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string TestParameters { get; set; }

        [Required]
        public int ProblemId { get; set; }

        [ForeignKey("ProblemId")]
        public virtual Problem Problem { get; set; }
    }
}