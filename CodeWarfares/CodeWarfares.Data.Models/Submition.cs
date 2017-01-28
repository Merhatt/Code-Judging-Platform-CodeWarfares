using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models
{
    public class Submition
    {
        public int Id { get; set; }

        public Submition()
        {
            this.SubmitionTime = DateTime.Now;
        }

        public bool Compiled { get; set; }

        public int PassingTests { get; set; }

        public int TestCounts { get; set; }

        public string Code { get; set; }

        public string CompileMessage { get; set; }

        public string Memories { get; set; }

        public string Errors { get; set; }

        public string StdOuts { get; set; }

        public DateTime SubmitionTime { get; set; }

        [Required]
        public int ProblemId { get; set; }

        [ForeignKey("ProblemId")]
        public virtual Problem Problem { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
