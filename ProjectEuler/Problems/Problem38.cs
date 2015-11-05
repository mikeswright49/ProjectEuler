using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * So since 9 is pandigital for n=5, n<5
 * Since 2*x + 1 *x (20000+10000 = 10 digits, therefore x<10000)
 * */
namespace ProjectEuler.Problems
{
    public class Problem38:IProblem
    {
        public string Run()
        {
            
            int largest = 0;
            for (int x = 1; x < 10000; x++)
            {
                string first = x.ToString();
                string second = (x*2).ToString();
                string third = (x * 3).ToString();
                string fourth = (x * 4).ToString();

                if (isPandigital(first + second)) {
                    int value = Convert.ToInt32(first + second);
                    largest = largest < value ? value : largest;
                }
                else if(isPandigital(first + second + third))
                {
                    int value = Convert.ToInt32(first + second + third);
                    largest = largest < value ? value : largest;
                }
                else if (isPandigital(first + second + third + fourth))
                {
                    int value = Convert.ToInt32(first + second + third + fourth);
                    largest = largest < value ? value : largest;
                }
            }
            return largest.ToString();
        }
        private bool isPandigital(string number)
        {
            string pandigital = "123456789";
            return string.Concat(number.OrderBy(x => x)) == pandigital;
        }
    }
}
