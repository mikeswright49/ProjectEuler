using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem49:IProblem
    {
        public string Run()
        {
            bool[] primes = new bool[10000];
            for (int i = 1000; i < 10000; i++)
            {
                primes[i-1000] = IsPrime(i);
            }
            for (int x = 4999; x > 0; x--)
            {
                for (int i = 0; i + (x * 2) < primes.Length; i++)
                {
                    if (primes[i] && primes[(i + x)] && primes[(i + x * 2)])
                    {
                        string w = (1000 + i).ToString();
                        string y = (1000 + (i + x)).ToString();
                        string z = (1000 + (i + (x * 2))).ToString();

                        if (String.Concat(w.OrderBy(q => q)) == String.Concat(y.OrderBy(q => q)) 
                            && String.Concat(w.OrderBy(q => q)) == String.Concat(z.OrderBy(q => q))
                            && String.Concat(w.OrderBy(q => q))!="1478")
                            return w + y + z;
                    }
                }
            }
            return "no answer";
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
