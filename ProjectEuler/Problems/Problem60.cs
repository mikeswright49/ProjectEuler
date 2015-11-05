using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem60:IProblem
    {
        public string Run()
        {
            long[] primes = new long[10000];            
            primes[0]=2;
            int index = 1;
            long lowestSum = 999999999999;
            for (int i = 3; index<primes.Length; i += 2)
            {
                if(IsPrime(i))
                {
                    primes[index] = i;
                    index++;
                }
            }
            for (int i = 0; i < primes.Length; i++)
            {
                for (int x = i + 1; x < primes.Length; x++)
                {

                    if((primes[i] + primes[x]*4) < lowestSum && IsConcatPrime(primes, primes[x], new long[] { i }))
                    {
                        for (int q = x + 1; q < primes.Length; q++)
                        {

                            if((primes[i] + primes[x] + primes[q]*3) < lowestSum && IsConcatPrime(primes, primes[q], new long[] { i, x }))
                            {
                                for (int n = q + 1; n < primes.Length; n++)
                                {

                                    if ((primes[i] + primes[x] + primes[q] + primes[n]*2 < lowestSum) &&  IsConcatPrime(primes, primes[n], new long[] { i, x, q }))
                                    {
                                        for (int p = n + 1; p < primes.Length; p++)
                                        {

                                            if ((primes[i] + primes[x] + primes[q] + primes[n] + primes[p]) < lowestSum && IsConcatPrime(primes, primes[p], new long[] { n, q, x, i }))
                                            {
                                                Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", primes[i], primes[x], primes[q],primes[n], primes[p]));
                                                lowestSum = (primes[i] + primes[x] + primes[q] + primes[n] + primes[p]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return lowestSum.ToString();
        }
        private bool IsConcatPrime(long[] primes, long value, long[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                var value1 = Concat(value, primes[indexes[i]]);
                var value2 = Concat(primes[indexes[i]], value);
                if (!IsPrime(value1)
                    || !IsPrime(value2))
                    return false;
            }
            return true;
        }
        private bool IsPrime(long number)
        {
            if (number == 2 || number == 5)
                return true;
            else if (number % 2 == 0 || number % 5 == 0)
                return false;


            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0 && number != i)
                    return false;
            }
            return true;
        }
        private long Concat(long a, long b)
        {
            int i=  (int)Math.Pow(10, (int)Math.Log10(b)+1);
            return ((long)a*(long)i) + b;
        }
    }
}
