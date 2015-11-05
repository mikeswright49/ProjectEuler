using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Take the permutations from quest 24, then go through all permutations and take the highest prime
 * **/
namespace ProjectEuler.Problems
{
    public class Problem41 :IProblem 
    {
        public string Run()
        {
            string values = "123456789";
            int largest = 0;
            for (int i = 1; i < values.Length; i++)
            {
                string value = String.Concat(values.Take(i));
                string current = value;
                string next = getPermutation(value);
                while (current != next)
                {
                    if (IsPrime(Convert.ToInt32(current)))
                    {
                        largest = Convert.ToInt32(current);
                    }
                    current = next;
                    next = getPermutation(current);
                }
            }
            return largest.ToString();
        }

        private bool isPandigital(string number)
        {
            string pandigital = "123456789";
            return string.Concat(number.OrderBy(x => x)) == String.Concat(pandigital.Take(number.Length));
        }
        private bool IsPrime(int number)
        {
            if (number == 2)
                return true;
            else if (number % 2 == 0 || number % 5 == 0 && number != 5)
                return false;


            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0 && number != i)
                    return false;
            }
            return true;
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
                            source = source.Replace(source.Substring(i + 1), String.Concat(source.Substring(i + 1).Reverse()));
                            return source;
                        }
                    }
                }
            }
            return source;
        }
    }
}
