using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem37 : IProblem
    {
        public string Run()
        {
            List<int> primes = new List<int>();
            int i = 11;
            while (primes.Count < 11)
            {
                if (IsPrime(i) && sliceable(i.ToString()))
                    primes.Add(i);
                i += 2;
            }
            return primes.Sum().ToString();
        }
        private bool sliceable(string number)
        {
            string left = number;
            string right = number;
            while (left.Length > 1)
            {
                left = left.Substring(0, left.Length - 1);
                right = right.Substring(1);
                if (!IsPrime(Convert.ToInt32(left)) || !IsPrime(Convert.ToInt32(right)))
                    return false;
            }
            return true;
        }
        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
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
