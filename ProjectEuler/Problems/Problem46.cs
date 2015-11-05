using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * (x - P)/2 = Math.S
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem46:IProblem
    {

        public string Run()
        {
            for (int i = 35; ; i += 2)
            {
                if (!IsPrime(i))
                {
                    bool found = false;
                    for (int x = 2; x < i; x++)
                    {
                        if (IsPrime(x))
                        {
                            double value = i - x;
                            if(Math.Sqrt(value / 2) % 1 == 0)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                        return i.ToString();
                }
            }
        }
        private bool IsPrime(int number)
        {
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
