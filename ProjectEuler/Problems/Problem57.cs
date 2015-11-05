using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem57:IProblem
    {
        Tuple<BigInteger, BigInteger>[] fractions = new Tuple<BigInteger, BigInteger>[1001];

        public string Run()
        {
            BigInteger weirdFractions = 0;
            fractions[0] = new Tuple<BigInteger, BigInteger>(1, 1);
            for (int i = 1; i < fractions.Length; i++)
            {
                fractions[i] = new Tuple<BigInteger, BigInteger>((2 * fractions[i - 1].Item1)+(i>1?fractions[i - 1].Item2:0), fractions[i - 1].Item1);
            }
            for (int i = 0; i < fractions.Length; i++)
            {
                if ((int)BigInteger.Log10((fractions[i].Item1 + fractions[i].Item2)) > (int)BigInteger.Log10(fractions[i].Item1))
                    weirdFractions++;
            }

            return weirdFractions.ToString();
        }
    }
}
