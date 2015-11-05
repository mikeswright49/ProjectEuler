using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem45 : IProblem
    {
        public string Run()
        {
            int x = 143;
            while (true)
            {
                x++;
                double value = (2 * Math.Pow(x, 2)) - x;
                if (isTriangle(value) && isPentagonal(value))
                    return value.ToString();
            }
        }
        bool isTriangle(double number)
        {
            return Math.Sqrt((8 * number) + 1) % 1 == 0;
        }
        bool isPentagonal(double number)
        {
            return ((Math.Sqrt((24 * number) + 1) + 1) / 6) % 1 == 0;
        }
    }
}
