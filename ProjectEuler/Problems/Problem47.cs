using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem47 : IProblem
    {
        
        public string Run()
        {
            List<int> primes = new List<int>();
            List<bool> results = new List<bool>();

            for (int i = 1;; i++)
            {
                if (primeMultiplier(i, new List<int>(), getPrimeFactors(i)))
                {
                    if (primeMultiplier(i+1, new List<int>(), getPrimeFactors(i+1))
                        && primeMultiplier(i + 2, new List<int>(), getPrimeFactors(i + 2))
                        && primeMultiplier(i + 3, new List<int>(), getPrimeFactors(i + 3)))
                        return i.ToString();
                }
            }
        }
        private List<int> getPrimeFactors(int number)
        {
            List<int> primeFactors = new List<int>();
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                double result = (number / i);
                if (result % 1 == 0)
                {
                    if (IsPrime(i))
                        primeFactors.Add(i);
                    if (IsPrime((int)result))
                        primeFactors.Add((int)result);
                }
            }
            return primeFactors;
        }
        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            else if (number == 2)
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

        private bool primeMultiplier(int target, List<int> numbersUsed, List<int> numbersToUse)
        {
            if (target == 1 && numbersUsed.Distinct().Count() == 4)
                return true;
            if (target == 1)
                return false;

            foreach (int number in numbersToUse)
            {
                if (target % number == 0) 
                {
                    List<int> temp = new List<int>(numbersUsed);
                    temp.Add(number);
                    if (primeMultiplier((int)(target / number), temp, numbersToUse))
                    return true;   
                }
            }
            return false;
        }
    }
}
