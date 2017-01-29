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
        private ICollection<TestCompleted> completedTests;

        public int Id { get; set; }

        public Submition()
        {
            this.SubmitionTime = DateTime.Now;
            this.completedTests = new HashSet<TestCompleted>();
        }

        public bool Finished { get; set; }      

        public int TestCounts { get; set; }

        public string Code { get; set; }

        public bool CanCompile { get; set; }

        public string CompileMessage { get; set; }

        public DateTime SubmitionTime { get; set; }

        public virtual ICollection<TestCompleted> CompletedTests { get { return this.completedTests; } set { this.completedTests = value; } }

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
