using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/**
 * It is well known that if the square root of a natural number is not an integer, then it is irrational. The decimal expansion of such square roots is infinite without any repeating pattern at all.

The square root of two is 1.41421356237309504880..., and the digital sum of the first one hundred decimal digits is 475.

For the first one hundred natural numbers, find the total of the digital sums of the first one hundred decimal digits for all the irrational square roots.
 * 
 * */
/*
 * Big Decimal.Pow won't work (it doesn't generate the precision we need)
 * https://en.wikipedia.org/wiki/Methods_of_computing_square_roots
 * 
 * x_{n+1}=x_n-\frac{f(x_n)}{f'(x_n)}=x_n-\frac{x_n^2-S}{2x_n}=\frac{1}{2}\left(x_n+\frac{S}{x_n}\right)
 * 
 * */
namespace ProjectEuler.Problems
{

    public class Problem80:IProblem
    {
        public string Run()
        {
            long total = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (Math.Sqrt(i) % 1 == 0)
                    continue;
                BigDecimal xn = new BigDecimal(1, 0);
                BigDecimal xn1 = new BigDecimal(0, 0);
                BigDecimal s = new BigDecimal(i, 0);
                
                for (int q = 0; q < 50; q++)
                {
                    xn1 = .5 * ((xn) + (s / xn));
                    xn = xn1;
                }
                string points = String.Concat(xn1.ToString().Take(100));
                for (int x = 0; x < points.Length; x++)
                {
                    total += points[x] - '0';
                }
            }
            return total.ToString();
        }
    }
}
