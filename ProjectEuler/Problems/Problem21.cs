using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem21 : IProblem
    {
        public string Run()
        {
            Console.WriteLine(SumOfFactors(220));
            List<KeyValuePair<int, bool>> values = new List<KeyValuePair<int, bool>>();
            for (int i = 1; i < 10000; i++)
            {
                values.Add(new KeyValuePair<int, bool>(SumOfFactors(i), false));
            }
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i].Key < values.Count && i + 1 != values[i].Key && values[values[i].Key - 1].Key == i + 1)
                {
                    values[i] = new KeyValuePair<int, bool>(values[i].Key, true);
                    values[values[i].Key - 1] = new KeyValuePair<int, bool>(values[values[i].Key - 1].Key, true);
                }
            }
            return values.Where(x => x.Value).Sum(x => x.Key).ToString();
        }
        private int SumOfFactors(int numbers)
        {
            int sum = 0;
            double sqrt = Math.Sqrt(numbers);
            for (int i = 1; i <= sqrt; i++)
            {
                double product = ((double)numbers / (double)i);
                if (product % 1 == 0){
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
