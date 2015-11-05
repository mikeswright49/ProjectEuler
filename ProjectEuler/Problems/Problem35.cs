using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem35:IProblem
    {
        public string Run()
        {
            bool[] circularPrime = new bool[1000001];
            for (int i = 3; i < 1000001; i+=2)
            {
                if (!circularPrime[i] && IsPrime(i))
                {
                    string representation = i.ToString();
                    if (representation.Length == 1)
                        circularPrime[i] = true;
                    else
                    {
                        bool circular = true;
                        int[] values = new int[representation.Length];
                        values[0] = i;
                        for (int x = 1; x < representation.Length; x++)
                        {
                            string temp = representation.Substring(1);
                            representation = temp + representation[0];
                            int value = Convert.ToInt32(representation);
                            if (circular)
                                circular = IsPrime(value);

                            values[x] = value;
                            
                        }
                        for (int x = 0; x < values.Count(); x++)
                        {
                            if (!circularPrime[values[x]] && circular)
                                circularPrime[values[x]] = circular;
                        }
                    }
                }
            }

            return (circularPrime.Where(x => x).Count()+1).ToString();
        }
        private bool IsPrime(int number)
        {
            if (number == 2)
                return true;
            else if (number % 2 == 0 ||number % 5==0 && number!=5)
                return false;


            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0 && number != i)
                    return false;
            }
            return true;
        }

    }
}
