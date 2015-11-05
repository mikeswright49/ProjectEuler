using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem29:IProblem
    {
        public string Run()
        {
            List<double> values = new List<double>();
            for (int i = 2; i <= 100; i++)
            {
                for (int x = 2; x <= 100; x++)
                {
                    values.Add(Math.Pow(i, x));
                }
            }
            return values.Distinct().Count().ToString();
        }
    }
}
