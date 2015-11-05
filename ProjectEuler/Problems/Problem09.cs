using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem09: IProblem
    {
        public string Run()
        {
            int total = 1000;

            for (int i = 5; i < 999; i++)
            {
                for (int x = 5; x < 999 - i; x++)
                {
                    int a = i * i;
                    int b = x * x;
                    int c = a + b;
                    double result = Math.Sqrt(c);
                    if (result % 1 == 0 && i + x + result == total)
                        return (i * x * result).ToString();
                }
            }

            return "";
        }
    }
}
