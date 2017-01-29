using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.PassingTests
{
    public interface IPassingTestsChecker
    {
        bool[] GetPassingTests(Submition submition, Problem problem);
    }
}
