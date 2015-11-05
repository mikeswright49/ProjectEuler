using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/**
 * Consider quadratic Diophantine equations of the form:

    x2 – Dy2 = 1

    For example, when D=13, the minimal solution in x is 6492 – 13×1802 = 1.

    It can be assumed that there are no solutions in positive integers when D is square.

    By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:

    32 – 2×22 = 1
    22 – 3×12 = 1
    92 – 5×42 = 1
    52 – 6×22 = 1
    82 – 7×32 = 1

    Hence, by considering minimal solutions in x for D ≤ 7, the largest x is obtained when D=5.

    Find the value of D ≤ 1000 in minimal solutions of x for which the largest value of x is obtained.
 * 
 * */
/**
 * 
 * if even period of Sqrt(D) then its the last repeating numbers
 * 
 * if odd, then pull the last one off the end and expand the fraction up
 * 
 * 
 * **/
namespace ProjectEuler.Problems
{
    class Problem66:IProblem
    {
        public string Run()
        {
            BigInteger max = 0;
            int maxIndex = 0;
            for (int i = 2; i <= 1000; i++)
            {
                if (Math.Sqrt(i) % 1 == 0)
                    continue;
                List<Tuple<BigInteger, BigInteger, BigInteger>> solutions = getPeriod(i);

                BigInteger tempMax = 0;
                if (solutions.Count % 2 == 0)
                {
                    tempMax = (BigInteger)(solutions.Last().Item1 * solutions.Last().Item3 + solutions.Last().Item2);
                }
                else
                {
                    solutions.Reverse();
                    Tuple<BigInteger, BigInteger, BigInteger>[] fractions = new Tuple<BigInteger, BigInteger, BigInteger>[solutions.Count];
                    fractions[0] = new Tuple<BigInteger, BigInteger, BigInteger>(1, solutions.ElementAt(0).Item3, 0);
                    for (int x = 1; x < fractions.Length; x++)
                    {
                        BigInteger numerator = (solutions.ElementAt(x).Item3 * fractions[x - 1].Item1) + (x > 1 ? fractions[x - 1].Item2 : 0);
                        fractions[x] = new Tuple<BigInteger, BigInteger, BigInteger>(numerator, fractions[x - 1].Item1, numerator + fractions[x - 1].Item1);
                    }
                    tempMax = (BigInteger)fractions.Last().Item3;
                }


                if (tempMax > max)
                {
                    maxIndex = i;
                    max = tempMax;
                }
            }

            return maxIndex.ToString();
        }

        private List<Tuple<BigInteger, BigInteger, BigInteger>> getPeriod(int i)
        {
            List<Tuple<BigInteger, BigInteger, BigInteger>> solutions = new List<Tuple<BigInteger, BigInteger, BigInteger>>();
            BigInteger mn = 0;
            BigInteger dn = 1;
            BigInteger a0 = (int)Math.Floor(Math.Sqrt(i));
            BigInteger an = (int)Math.Floor(Math.Sqrt(i));

            while (an!=2*a0&&!solutions.Contains(new Tuple<BigInteger, BigInteger, BigInteger>(mn, dn, an)))
            {
                solutions.Add(new Tuple<BigInteger, BigInteger, BigInteger>(mn, dn, an));
                mn = an * dn - mn;
                dn = (i - BigInteger.Pow(mn, 2)) / dn;
                an = (a0 + mn) / dn;
            }
            return solutions;
        }
    }
}
