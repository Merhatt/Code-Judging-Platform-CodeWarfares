using CodeWarfares.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeWarfares.Web.EventArguments
{
    public class ProblemUploadClickEventArgs : EventArgs
    {
        public ProblemUploadClickEventArgs(string fileName, string problemName, string imgUrl, long maxTime, long maxMemory, int points, int testsCount, IEnumerable<Tuple<string, string>> tests, string difficulty)
        {
            this.FileName = fileName;
            this.ProblemName = problemName;
            this.ImgUrl = imgUrl;
            this.MaxTime = maxTime;
            this.MaxMemory = maxMemory;
            this.Points = points;
            this.TestsCount = testsCount;
            this.Tests = tests;
            this.Difficulty = difficulty;
        }

        public string FileName { get; private set; }
        public string ImgUrl { get; private set; }
        public long MaxMemory { get; private set; }
        public long MaxTime { get; private set; }
        public int Points { get; private set; }
        public string ProblemName { get; private set; }
        public IEnumerable<Tuple<string, string>> Tests { get; private set; }
        public int TestsCount { get; private set; }
        public string Difficulty { get; set; }
    }
}