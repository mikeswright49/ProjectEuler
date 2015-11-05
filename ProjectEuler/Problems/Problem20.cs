using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem20 : IProblem
    {
        public string Run()
        {
            String result = Convert.ToString(factorial(100, 1));
            int sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += (result[i] - '0');
            }
            return sum.ToString();
        }

        private BigInteger factorial(int i, BigInteger total)
        {
            if (i <= 1)
                return total;
            Console.WriteLine (i + " " + total);
            BigInteger newTotal = total * i;
            return factorial(i - 1, newTotal);
        }
    }
}
