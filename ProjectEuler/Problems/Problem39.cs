using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 *  we need to generate all pythagorian triples and then see where they add up
 *  for a triple.
 * 
 * Following dickinson's method: https://en.wikipedia.org/wiki/Formulas_for_generating_Pythagorean_triples
 * r^2 = 2st
 * 
 * Therefore i just need to find the factors where r^2/2 = st meaning if r=6 then 18 = (1*18)|(2*9)|(3*6), so for r=6 there are 3 answers, 
 * need to find the max. r has to be even, as otherwise we don't get integer results for s,t
 * 
 * since p = 3r+2s+2t then Max(r) = p/3;
 * 
 * from there a = r+s, b = r+t, c = r+s+t
 * a^2+b^2=c^2
 * */
namespace ProjectEuler.Problems
{
    class Problem39 :IProblem
    {
        public string Run()
        {
            int[] values = new int[1001];

            for (int r = 2; r <= 333; r+=2)
            {
                double result = Math.Pow(r, 2) / (double)2;
                for (int s = 1; s < Math.Sqrt((double)result); s++)
                {
                    if (result % s == 0)
                    {
                        int t = (int)result / s;
                        double a = r + s;
                        double b = r + t;
                        double c = r + s + t;
                        if(a+b+c<values.Length)
                            values[(int)(a + b + c)]++;
                    }
                }
            }
            return values.Select((x, i) => new { x, i }).Where(x => values.Max() == x.x).Select(x => x.i).First().ToString();
        }
    }
}
