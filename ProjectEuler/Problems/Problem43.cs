using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem43 :IProblem
    {
        string seed = "1023456789";
        int[] divisors = { 2, 3, 5, 7, 11, 13, 17 };
        public string Run()
        {
            List<long> divisibles = new List<long>();
            while (seed != "9876543210")
            {
                seed = getPermutation(seed);
                bool divisible = true;
                for (int i = 0; i < divisors.Length; i++)
                {
                    divisible = Convert.ToInt32(seed.Substring(i + 1, 3)) % divisors[i] == 0;
                    if (!divisible)
                        break;
                }
                if (divisible)
                    divisibles.Add(Convert.ToInt64(seed));
            }

            return divisibles.Sum().ToString();
        }

        private string getPermutation(string source)
        {
            for (int i = source.Length - 2; i >= 0; i--)
            {
                if (source[i] < source[i + 1])
                {
                    for (int k = source.Length - 1; k > i; k--)
                    {
                        if (source[k] > source[i])
                        {
                            char temp = source[k];
                            char temp2 = source[i];
                            source = source.Replace(source[k], 'K').Replace(source[i], 'I').Replace('K', temp2).Replace('I', temp);
                            source = source.Replace(source.Substring(i + 1), String.Concat(source.Substring(i + 1).Reverse()));
                            return source;
                        }
                    }
                }
            }
            return source;
        }
    }
}
