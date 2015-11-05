using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem40 : IProblem
    {
        public string Run()
        {
            int product = 1;
            int number = 10;
            int values = 13;

            bool hundred = false;
            bool thousand = false;
            bool tenK = false;
            bool hundredThousand = false;
            bool million = false;

            while (values < 1000000)
            {
                number++;
                values += (number / 10).ToString().Length+1;

                if (values > 100 && !hundred)
                {
                    product *= number.ToString()[values - 101]-'0';
                    hundred = true;
                }
                else if (values >= 1000 && !thousand)
                {
                    product *= number.ToString()[values - 1001] - '0';
                    thousand = true;
                }
                else if (values > 10000 && !tenK)
                {
                    product *= number.ToString()[values - 10001] - '0';
                    tenK = true;
                }
                else if (values > 100000 && !hundredThousand)
                {
                    product *= number.ToString()[values - 100001] - '0';
                    hundredThousand = true;
                }
                else if (values > 1000000 && !million)
                {
                    product *= number.ToString()[values - 1000001] - '0';
                    million = true;
                }
            }

            return product.ToString();
        }
    }
}
