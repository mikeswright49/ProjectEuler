using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Picked the algorithm from Wikipedia on permutations
 * Moral of the story start from the end and work back rather than the other way around.
 * */
namespace ProjectEuler.Problems
{
    
    public class Problem24:IProblem
    {
        string seed = "0123456789";
        string[] permutations = new string[1000000];

    
        public string Run()
        {
            permutations[0] = seed;
            for (int i = 1; i < 1000000; i++)
            {
                permutations[i] = getPermutation(seed);
                seed = permutations[i];
            }
            return permutations[permutations.Length - 1];
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
                            source = source.Replace(source.Substring(i+1), String.Concat(source.Substring(i+1).Reverse()));
                            return source;
                        }
                    }
                }
            }
            return source;
        }

    }
}
