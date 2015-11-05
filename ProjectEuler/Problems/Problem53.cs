using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem53:IProblem
    {
        public string Run()
        {
            int total = 0;
            int limit = 1000000;
            for (int n = 23; n <= 100; n++)
            {
                bool leftLimit = true;
                bool rightLimit = true;
                int result = n / 2;
                int loop = 0;
                while (leftLimit || rightLimit)
                {
                    leftLimit = leftLimit?choose(n, result - loop)>limit:leftLimit;
                    rightLimit = rightLimit?choose(n, result + loop) > limit:rightLimit;

                    if (leftLimit)
                        total++;
                    if (rightLimit && loop != 0)
                        total++;
                    loop++;
                }
            }
            return total.ToString();
        }
        private BigInteger factorial(int i, BigInteger total)
        {
            if (i <= 1)
                return total;
            BigInteger newTotal = total * i;
            return factorial(i - 1, newTotal);
        }
        private BigInteger choose(int n, int r)
        {
            return factorial(n, 1) / (factorial(r, 1) * factorial(n - r, 1));
        }
    }
}
