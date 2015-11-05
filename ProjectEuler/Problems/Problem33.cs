using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 
 * The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

    We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

    There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

    If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
 * 
 * */   
namespace ProjectEuler.Problems
{
    public class Problem33:IProblem
    {


        public string Run()
        {
            List<object> values = new List<object>();
            for (decimal i = 11; i < 100; i++)
            {
                if(i%10==0)i++;
                for (decimal x = 11; x < i; x++)
                {
                    if (x % 10 == 0) x++;
                    if ((x % 10) == ((int)i / (int)10) || (int)((int)x / (int)10) == (i % 10))
                    {
                        decimal result = x / i;
                        decimal once = (x % 10) / ((int)i / (int)10);
                        decimal reverse = (int)((int)x / (int)10) / (i % 10);
                        if (result == once || result == reverse)
                        {
                            values.Add(new {Numerator= x, Denominator=i });
                        }
                    }
                }
            }
            int numerator = 1;
            int denominator = 1;
            foreach (dynamic o in values)
            {
                numerator *= o.Numerator;
                denominator *= o.Denominator;
            }
            return (denominator/GCD(numerator, denominator)).ToString();
        }
        public int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a > b)
                return GCD(a % b, b);
            else
                return GCD(a, b % a);
        }
    }
}
