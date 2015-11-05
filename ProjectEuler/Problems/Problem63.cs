using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem63:IProblem
    {
        public string Run()
        {
            int count = 0;
            for(int i= 1;; i++){
                int currentCount = count;
                for (int x = 1; ; x++)
                {
                    if (x != 10)
                    {
                        var value = (int) (BigInteger.Log10(BigInteger.Pow(x, i))+1);
                        if (value == i)
                            count++;
                        if (value > i)
                            break;
                    }

                    
                }
                if (count == currentCount)
                    return count.ToString();
            }

        }
    }
}
