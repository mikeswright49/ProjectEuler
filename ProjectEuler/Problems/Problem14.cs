using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem14 : IProblem
    {
        public string Run()
        {
            int longest = 0;
            int startingNumber = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                int sequenceLength = SequenceLength(i);
                if (longest < sequenceLength)
                {
                    longest = sequenceLength;
                    startingNumber = i;
                }
                
            }
            return startingNumber.ToString();
        }
        private int SequenceLength(long number)
        {
            int count = 1;
            while (number != 1)
            {
                count++;
                number = number % 2 == 0 ? (number / 2) : ((3 * number) + 1);
            }
            count++;
            return count;
        }
    }
}
