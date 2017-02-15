using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWarfares.Data.Models
{
    public class TestCompleted
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public bool IsCorrect { get; set; }

        public double Time { get; set; }

        public bool Compiled { get; set; }

        public string ExpectedResult { get; set; }

        public long Memory { get; set; }

        public string SendId { get; set; }

        [Required]
        public int SubmitionId { get; set; }

        [ForeignKey("SubmitionId")]
        public virtual Submition Submition { get; set; }
    }
}