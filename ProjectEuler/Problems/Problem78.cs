using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/**
 * Let p(n) represent the number of different ways in which n coins can be separated into piles. For example, five coins can be separated into piles in exactly seven different ways, so p(5)=7.

OOOOO
OOOO   O
OOO   OO
OOO   O   O
OO   OO   O
OO   O   O   O
O   O   O   O   O
Find the least value of n for which p(n) is divisible by one million.
 * 
 * p(k) = p(k − 1) + p(k − 2) − p(k − 5) − p(k − 7) + p(k − 12) + p(k − 15) − p(k − 22)...
 * 
 * p(n)=\sum_k (-1)^{k-1}p(n-g_k)
 * */
namespace ProjectEuler.Problems
{
    public class Problem78:IProblem
    {
        public List<BigInteger> values = new List<BigInteger>(){1};
        int n = 1;
        public string Run()
        {
            while (true)
            {
                BigInteger total = 0;
                int k = 0;
                int gk = 1;

                while (n - G(k) >= 0)
                {
                    gk = G(k);
                    total += (BigInteger)((k/2) %2 == 0?1:-1) * values[n - gk];
                    k++;
                }


                if (total % 1000000 == 0)
                    return (n).ToString();
                else
                    values.Add(total);
                n++;
            }

        }
        private int G(int i)
        {
            int k = (int)Math.Pow(-1, i) * ((i / 2) + 1);
            return (k * ((3 * k) - 1)) / 2;
        }
    }
}
