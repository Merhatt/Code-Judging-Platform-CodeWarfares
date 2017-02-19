using CodeWarfares.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models
{
    public class Problem
    {
        private ICollection<Submition> submition;
        private ICollection<Test> tests;
        private ICollection<User> users;

        public Problem()
        {
            this.submition = new HashSet<Submition>();
            this.tests = new HashSet<Test>();
            this.users = new HashSet<User>();
            this.CreationTime = DateTime.Now;
        }
        
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Name { get; set; }

        public long MaxMemory { get; set; }

        public double MaxTime { get; set; }

        public int TestsCount { get; set; }

        public int Xp { get; set; }

        public string CoverImageUrl { get; set; }

        public DateTime CreationTime { get; set; }

        public DifficultyType Difficulty { get; set; }

        public virtual ICollection<Submition> Submitions { get { return this.submition; } set { this.submition = value; } }

        public virtual ICollection<Test> Tests { get { return this.tests; } set { this.tests = value; } }

        public virtual ICollection<User> Users { get { return this.users; } set { this.users = value; } }
    }
}
