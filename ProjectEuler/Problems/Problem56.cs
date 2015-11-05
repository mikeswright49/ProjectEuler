using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem56:IProblem
    {
        public string Run()
        {
            int maxSum = 0;
            for (int i = 2; i < 100; i++)
            {
                for (int x = 2; x < 100; x++)
                {
                    int sum = 0;
                    BigInteger value = BigInteger.Pow(i, x);
                    while (value > 10)
                    {
                        sum += (int)(value % 10);
                        value = value / 10;
                    }
                    sum += (int)value;

                    if (sum > maxSum)
                        maxSum = sum;

                }
            }
            return maxSum.ToString();
        }
    }
}
