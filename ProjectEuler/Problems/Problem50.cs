using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem50 : IProblem
    {

        public string Run()
        {

            int largestPrime = 0;
            int longestChain = 0;
            int previousPrime = 2;
            int limit = 1000000;
            List<int> primes = new List<int>(){2};
            bool last = false;
            while (!last)
            {
                previousPrime = nextPrime(previousPrime);
                if (previousPrime < limit)
                    primes.Add(previousPrime);
                else
                    last = true;
            }
            for (int i = 0; i < primes.Count; i++)
            {
                int sum = 0;
                for (int x = (i + 1); x < primes.Count && sum<limit; x++)
                {
                    sum += primes[x];
                    if ((x - i) > longestChain && sum<limit && IsPrime(sum))
                    {
                        largestPrime = sum;
                        longestChain = (x - i);
                    }
                }
            }
            return largestPrime.ToString();
        }
        private int nextPrime(int previous)
        {
            for(int i=previous+1; ;i++)
            {
                if (IsPrime(i))
                    return i;
            }
        }
        private bool IsPrime(int number)
        {
            if (number == 2)
                return true;
            else if (number % 2 == 0 || number % 5 == 0 && number != 5)
                return false;


            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0 && number != i)
                    return false;
            }
            return true;
        }

    }
}
