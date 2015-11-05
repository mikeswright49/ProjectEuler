using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Euler's Totient function, φ(n) [sometimes called the phi function], 
 * is used to determine the number of numbers less than n which are relatively prime to n. For example, 
 * as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6.

n	Relatively Prime	φ(n)	n/φ(n)
2	1	1	2
3	1,2	2	1.5
4	1,3	2	2
5	1,2,3,4	4	1.25
6	1,5	2	3
7	1,2,3,4,5,6	6	1.1666...
8	1,3,5,7	4	2
9	1,2,4,5,7,8	6	1.5
10	1,3,7,9	4	2.5
It can be seen that n=6 produces a maximum n/φ(n) for n ≤ 10.

Find the value of n ≤ 1,000,000 for which n/φ(n) is a maximum.
 * 
 * */
 
namespace ProjectEuler.Problems
{
    public class Problem69:IProblem
    {

        public string Run()
        {
            int index = 1;
            int previous = 0;

            while(true)
            {
                previous = nextPrime(previous);
                index *= previous;
                if (index >= 1000000)
                    return (index / previous).ToString();
            }
        }

        private int[] generatePrimes(int count)
        {
            int[] primes = new int[count];
            int previous = 1;
            for (int i = 0; i < primes.Length; i++)
            {
                previous = nextPrime(previous);
                primes[i] = previous;
            }
            return primes;
        }
        private int nextPrime(int previous)
        {
            for (int i = previous + 1; ; i++)
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
