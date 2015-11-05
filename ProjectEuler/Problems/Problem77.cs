using ProjectEuler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * It is possible to write ten as the sum of primes in exactly five different ways:

7 + 3
5 + 5
5 + 3 + 2
3 + 3 + 2 + 2
2 + 2 + 2 + 2 + 2

What is the first value which can be written as the sum of primes in over five thousand different ways?*/


namespace ProjectEuler.Problems
{
    public class Problem77:IProblem
    {
        private LongPrimeGenerator generator = new LongPrimeGenerator();
       
        public string Run()
        {
            long[] primes = generator.Seive(100).ToArray();
            int[] values = new int[100];
            values[0]=1;
            for (int i = 0; i < primes.Length; i++)
            {
                for (long x = primes[i]; x < values.Length; x++)
                {
                    if (x - primes[i] >= 0)
                        values[x] += values[x-primes[i]];
                }
            }
            var results = values.Select((a, x) => new { a, x }).Where(x => x.a > 5000);
            return results.First().x.ToString();
        }
    }
}
