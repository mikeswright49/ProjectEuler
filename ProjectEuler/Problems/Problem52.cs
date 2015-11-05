using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem52:IProblem
    {

        public string Run()
        {
            for (int i = 1; ; i++)
            {
                List<string> strings = new List<string>();
                for(int x=1; x<7; x++)
                {
                    strings.Add(String.Concat((i * x).ToString().OrderBy(q => q)));
                }
                if (strings.Distinct().Count() == 1)
                    return i.ToString();

            }
        }
    }
}
