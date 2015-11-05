using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * https://math.stackexchange.com/questions/166800/primality-and-repeated-digits
 * 
 * have to replace 3, 6, or 9 digits
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem51:IProblem
    {
        public string Run()
        {
            for (int i = 2; ; i = nextPrime(i))
            {
                foreach (char digit in i.ToString().GroupBy(x => x).Where(x => x.Count() % 3 == 0).Select(x => x.First()))
                {
                    int primes = 0;
                    string number = i.ToString();
                    for (int x = 1; x < 10 && primes<2; x++)
                    {
                        if (!IsPrime(Convert.ToInt32(number.Replace(digit, x.ToString()[0]))))
                        {
                            primes++;
                        }
                    }
                    if (primes<2)
                        return i.ToString();
                }
            }
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
