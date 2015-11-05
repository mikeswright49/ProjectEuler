using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem23:IProblem
    {
        bool[] values = new bool[28124];
        public string Run()
        {
            for (int i = 1; i < values.Length; i++)
            {
                values[i] = isAbundant(i);
            }
            long sum = 0;
            IEnumerable<int> abundant = values.Select((v, i) => new { value = v, index = i }).Where(x => x.value).Select(x => x.index);
            for(int i=0; i < values.Length; i++){
                bool expressable = false;
                foreach (int value in abundant)
                {
                    if (i - value > 0 && values[i - value])
                    {
                        expressable = true;
                        break;
                    }
                }
                if (!expressable)
                {
                    sum += i;
                }
            }

            return sum.ToString();
        }
        private bool isAbundant(int number)
        {
            return SumOfFactors(number) > number;
        }
        private int SumOfFactors(int numbers)
        {
            int sum = 0;
            double sqrt = Math.Sqrt(numbers);
            for (int i = 1; i <= sqrt; i++)
            {
                double product = ((double)numbers / (double)i);
                if (product % 1 == 0)
                {
                    if (i < numbers)
                        sum += i;
                    if (product != i && product != numbers)
                        sum += (int)product;
                }
            }
            return sum;
        }
    }
}
