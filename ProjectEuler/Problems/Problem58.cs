using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem58:IProblem
    {
        public string Run()
        {
            double primes = 8;
            for (int i = 4; ; i++)
            {
                int bottom =(int)(Math.Pow((2 * i) + 1, 2) - (6 * i));
                int left = (int)(Math.Pow(2 * i, 2) + 1);
                int right = (int)(Math.Pow((2 * i) + 1, 2) - (2 * i));

                if (IsPrime(bottom))
                    primes++;
                if (IsPrime(left))
                    primes++;
                if (IsPrime(right))
                    primes++;

                if ((primes / ((i * 4) + 1)) < .1)
                    return ((2 * i)+1).ToString();

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
