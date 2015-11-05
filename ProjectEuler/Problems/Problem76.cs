using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/**
 * It is possible to write five as a sum in exactly six different ways:

4 + 1
3 + 2
3 + 1 + 1
2 + 2 + 1
2 + 1 + 1 + 1
1 + 1 + 1 + 1 + 1

How many different ways can one hundred be written as a sum of at least two positive integers?
 * 
 * */

namespace ProjectEuler.Problems
{
    public class Problem76 : IProblem
    {
        public BigInteger[] values = new BigInteger[101];
        public string Run()
        {
            values[0] = 1;
            for (int i = 1; i <= 99; i++)
            {
                for (int x = i; x <= 100; x++)
                    values[x] += values[x - i];
            }

            return values[100].ToString();
        }
    }
}
