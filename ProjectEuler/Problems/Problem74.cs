using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
/**
 * 
 * The number 145 is well known for the property that the sum of the factorial of its digits is equal to 145:

1! + 4! + 5! = 1 + 24 + 120 = 145

Perhaps less well known is 169, in that it produces the longest chain of numbers that link back to 169; it turns out that there are only three such loops that exist:

169 → 363601 → 1454 → 169
871 → 45361 → 871
872 → 45362 → 872

It is not difficult to prove that EVERY starting number will eventually get stuck in a loop. For example,

69 → 363600 → 1454 → 169 → 363601 (→ 1454)
78 → 45360 → 871 → 45361 (→ 871)
540 → 145 (→ 145)

Starting with 69 produces a chain of five non-repeating terms, but the longest non-repeating chain with a starting number below one million is sixty terms.

How many chains, with a starting number below one million, contain exactly sixty non-repeating terms?
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem74:IProblem
    {
        public string Run()
        {
            int[] chains = new int[1000000];
            int result = 0;
            for (int i = 1; i < chains.Length; i++)
            {
                if (chains[i] != 0)
                    continue;

                List<int> path = new List<int>(){i};
                int value = i;
                while (true)
                {
                    value = DigitFactorialSum(value);
                    if (path.Contains(value))
                    {
                        chains[i] = path.Count;
                        if (value < chains.Length && value!=i)
                        {
                            chains[(int)value] = path.Count - path.IndexOf(value);
                        }
                        if (chains[i] == 60)
                            result++;
                        if (chains[(int)value] == 60)
                            result++;
                        break;
                    }
                    else if(!path.Contains(value) && (value<chains.Length && chains[(int)value]!=0)){
                        chains[i] = path.Count + chains[(int)value];
                        if (chains[i] == 60)
                            result++;
                        break;
                    }
                    else
                    {
                        path.Add(value);
                    }
                }
            }
            return result.ToString();
        }
        private int DigitFactorialSum(int value)
        {
            int sum = 0;
            while(value!=0)
            {
                sum += factorial((int)value%10, 1);
                value /= 10;
            }
            return sum;
        }
        private int factorial(int i, int total)
        {
            if (i <= 1)
                return total;
            int newTotal = total * i;
            return factorial(i - 1, newTotal);
        }
    }
}
