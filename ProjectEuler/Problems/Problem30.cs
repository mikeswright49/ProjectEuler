using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem30:IProblem
    {

        public string Run()
        {
            long total = 0;
            for (int i = 1; i < 10000000; i++)
            {
                if (i == digitValues(i.ToString()))
                    total += i;
            }
            return (total-1).ToString();
        }
        public long digitValues(string value)
        {
            long total = 0;

            for (int i = 0; i < value.Length; i++)
            {
                total+= (long)Math.Pow((value[i]-'0'),5);
            }

            return total;
        }
    }
}
