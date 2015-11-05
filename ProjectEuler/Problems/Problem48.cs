using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem48:IProblem
    {
        public string Run()
        {
            BigInteger total = new BigInteger(0);
            for (int i = 1; i <= 1000; i++)
            {
                total += BigInteger.Pow(i, i);
            }
            return total.ToString().Substring(total.ToString().Length - 10);
        }
    }
}
