using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem36 : IProblem
    {

    
        public string Run()
        {
            List<int> palindromes = new List<int>();
            for (int i = 1; i < 1000000; i++)
            {
                if (isPalindrome(i.ToString()) && isPalindrome(Convert.ToString(i, 2)))
                    palindromes.Add(i);
            }
            return palindromes.Sum().ToString();
        }
        private bool isPalindrome(string word)
        {
            int x = word.Length - 1;
            for (int i = 0; i < (word.Length/2)+1; i++)
            {
                if (word[i] != word[x])
                    return false;
                x--;
            }

                return true;
        }
    }
}
