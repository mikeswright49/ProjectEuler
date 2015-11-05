
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*
 * Trick -> repeating number has to be less than the denominator in length
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem26 : IProblem
    {
        public string Run()
        {
            
            int longest = 0;
            int longestLength = 0;
            for (int i = 2; i < 1000; i++)
            {
                BigDecimal points = new BigDecimal(1,0,2000)/new BigDecimal(i,0,2000);
                string value = points.ToString();
                value = value.Substring(0, value.IndexOf("E"));
                if (value.Length==2000)
                {
                    int repeatingLength = getRepeatingLength(value, i);
                    if(repeatingLength>longestLength)
                    {
                        longestLength = repeatingLength;
                        longest = i;
                    }
                }
            }

            return longest.ToString();
        }
        private int getRepeatingLength(string value, int windowSize)
        {
            for (int i = 1; i <= windowSize; i++)
            {
                string left = value.Substring(value.Length - (i * 2) - 1, i);
                string right = value.Substring(value.Length - (i) - 1, i);
                if (left == right)
                    return i;
            }
            return 0;
        }
    }
}
