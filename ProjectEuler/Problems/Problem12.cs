using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem12:IProblem
    {
        public string Run()
        {
            int total=1;
            for (int i = 2; i < Int32.MaxValue; i++)
            {
                total += i;
                if (GetFactors(total).Count > 250)
                    return total.ToString();

            }


            return total.ToString();
        }
        private List<int> GetFactors(int number)
        {
            List<int> factors = new List<int>();
            int sqrt = (int)Math.Sqrt(number);
            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                    factors.Add(i);
            }


            return factors;
        }

    }
}
