using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem27 : IProblem
    {
        public string Run()
        {
            int largest = -99999999;
            int a = 0;
            int b = 0;
            for (int i = -999; i < 1000; i++)
            {
                for (int x = -999; x < 1000; x++)
                {
                    if(!IsPrime(Math.Abs(x)))
                        continue;

                    int test = 0;
                    int n = 0;
                    while (IsPrime(Math.Abs((test * test) + (i * test) + x)))
                    {
                        n++;
                        test++;
                    }
                    if (n > largest)
                    {
                        largest = n;
                        a = i;
                        b = x;
                    }

                }
            }
            return (a * b).ToString();
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
    }
}
