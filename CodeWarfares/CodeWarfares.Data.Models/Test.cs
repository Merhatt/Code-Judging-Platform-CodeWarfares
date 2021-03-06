﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWarfares.Data.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string TestParameter { get; set; }

        public string CorrectAnswer { get; set; }

        public int? ProblemId { get; set; }

        [ForeignKey("ProblemId")]
        public virtual Problem Problem { get; set; }
    }
}