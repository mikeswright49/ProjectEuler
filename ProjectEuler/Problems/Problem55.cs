using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem55:IProblem
    {
        public string Run()
        {
            int count = 1;
            for (int i = 197; i < 10000; i++)
            {
                if (isLychrel(i, 0))
                    count++;
            }
            return count.ToString();
        }
        private bool isLychrel(long seed, int depth)
        {
            if (depth > 26)
                return true;

            long result = seed + Convert.ToInt64(String.Concat(seed.ToString().Reverse()));
            return isPalindrome(result.ToString()) ? false : isLychrel(result, depth+1);
        }
        private bool isPalindrome(string word)
        {
            int x = word.Length - 1;
            for (int i = 0; i < (word.Length / 2) + 1; i++)
            {
                if (word[i] != word[x])
                    return false;
                x--;
            }

            return true;
        }
    }
}
