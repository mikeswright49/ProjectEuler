using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem62:IProblem
    {
        public string Run()
        {
            List<KeyValuePair<long, string>> cubes = new List<KeyValuePair<long, string>>();

            for (int i = 5000; i < 10000; i++)
            {
                long value = (long)Math.Pow(i, 3);
                cubes.Add(new KeyValuePair<long, string>(value, String.Concat(value.ToString().OrderBy(x => x))));
            }
            var solution = cubes.GroupBy(x => x.Value).Where(x => x.Count() == 5).First().First();
            return solution.Key.ToString();
        }

        private bool isPermutation(string seed, long target)
        {
            string targetString = String.Concat(target.ToString().OrderBy(x=>x));
            return seed == targetString;
        }
    }
}
