using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem25 : IProblem
    {
        public string Run()
        {
            string result = "";
            BigInteger left = new BigInteger(1);
            BigInteger right = new BigInteger(1);
            BigInteger current = new BigInteger(0);
            int index = 2;
            while (result.Length < 1000)
            {
                current = left + right;
                result = current.ToString();
                left = right;
                right = current;
                index++;
            }

            return index.ToString();
        }

    }
}
