using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem28 : IProblem
    {

        public string Run()
        {
            long sum = 1;
            for (int i = 1; i < 501; i++)
            {
                sum += (long)(Math.Pow((2 * i) + 1, 2) 
                    + (Math.Pow((2 * i) + 1, 2) - (6 * i)) 
                    + (Math.Pow(2 * i, 2) + 1) 
                    + (Math.Pow((2 * i) + 1, 2) - (2 * i)));
            }
            return sum.ToString();
        }
    }
}
