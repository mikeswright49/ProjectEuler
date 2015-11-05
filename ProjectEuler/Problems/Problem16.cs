using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem16 : IProblem
    {
        public string Run()
        {
            string result = Convert.ToString(new BigInteger(Math.Pow(2, 1000)));
            Console.WriteLine(result);
            int sum = 0;
            for (int i = 0; i < result.Length; i++)
                sum += (int)(result[i]-'0');

            return sum.ToString();

        }
    }
}
