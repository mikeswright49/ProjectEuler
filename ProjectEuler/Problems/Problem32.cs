using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem32:IProblem
    {
        public string Run()
        {
            string sorted = "123456789";
            List<int> answers = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                for (int x = 9999; x > 0; x--)
                {
                    int result = i * x;
                    string all = i.ToString() + x.ToString() + result.ToString();
                    if (all.Count() == sorted.Count())
                    {
                        if (String.Concat(all.OrderBy(z => z)) == sorted)
                            answers.Add(result);
                    }
                }
            }
            return answers.Distinct().Sum(x => x).ToString();
        }
    }
}
