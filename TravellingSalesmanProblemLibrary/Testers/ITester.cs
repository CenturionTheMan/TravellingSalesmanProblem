using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblemLibrary.Testers
{
    public interface ITester
    {
        public void RunTest(string outputFileDir, string algorithmDetailsForPath);
    }
}
