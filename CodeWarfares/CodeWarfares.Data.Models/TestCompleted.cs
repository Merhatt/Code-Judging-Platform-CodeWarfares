using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWarfares.Data.Models
{
    public class TestCompleted
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public bool Error { get; set; }

        public bool Correct { get; set; }

        public double Time { get; set; }

        public long Memory { get; set; }

        [Required]
        public int SubmitionId { get; set; }

        [ForeignKey("SubmitionId")]
        public virtual Submition Submition { get; set; }
    }
}