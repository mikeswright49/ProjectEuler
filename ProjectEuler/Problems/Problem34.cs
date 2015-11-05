using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem34:IProblem
    {
        public string Run()
        {
            long sum = 0;
            for (int i = 3; i < 1000000; i++)
            {
                int result = i.ToString().Select(x => factorial(x - '0', 1)).Sum();
                if (result == i)
                {
                    sum += result;
                }
            }
            return sum.ToString();
        }
        private int factorial(int i, int total)
        {
            if (i <= 1)
                return total;
            int newTotal = total * i;
            return factorial(i - 1, newTotal);
        }
    }
}
