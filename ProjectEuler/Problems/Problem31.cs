using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem31 : IProblem
    {
        int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
        static int target = 200;
        int[] ways = new int[target+1];

        public string Run()
        {
            ways[0] = 1;
            for (int x = 0; x < coins.Length; x++)
            {
                for (int i = 0; i <= target; i++)
                {
                    if(i-coins[x]>=0)
                        ways[i] += ways[i - coins[x]];
                }
            }
            return ways[200].ToString();
        }
    }
}
