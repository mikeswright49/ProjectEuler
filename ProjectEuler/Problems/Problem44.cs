using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem44:IProblem
    {
        public string Run()
        {
            int i = 1;
            while (true)
            {
                for (int x = i - 1; x > 0; x--)
                {
                    double first = getPentagonal(i);
                    double second = getPentagonal(x);

                    if (isPentagonal(first + second) && isPentagonal(Math.Abs(first - second)))
                        return (first - second).ToString();

                }
                i++;
            }
        }
        private double getPentagonal(int n)
        {
            return ((3*Math.Pow(n,2)) - n)*.5;
        }
        bool isPentagonal(double number)
        {
            return ((Math.Sqrt((24 * number) + 1) + 1) / 6) % 1 == 0;
        }
    }
}
