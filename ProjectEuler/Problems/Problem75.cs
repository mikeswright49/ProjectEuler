using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * It turns out that 12 cm is the smallest length of wire that can be bent to form an integer sided right angle triangle in exactly one way, but there are many more examples.

12 cm: (3,4,5)
24 cm: (6,8,10)
30 cm: (5,12,13)
36 cm: (9,12,15)
40 cm: (8,15,17)
48 cm: (12,16,20)

In contrast, some lengths of wire, like 20 cm, cannot be bent to form an integer sided right angle triangle, and other lengths allow more than one solution to be found; for example, using 120 cm it is possible to form exactly three different integer sided right angle triangles.

120 cm: (30,40,50), (20,48,52), (24,45,51)

Given that L is the length of the wire, for how many values of L ≤ 1,500,000 can exactly one integer sided right angle triangle be formed?
 * 
 * */
/*
 * https://en.wikipedia.org/wiki/Pythagorean_triple
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem75:IProblem
    {


        public string Run()
        {
            List<Tuple<long, long, long>> values = new List<Tuple<long, long, long>>();
            for (int m = 1; m < 1000; m++)
            {
                for (int n = 1; n < m; n++)
                {
                    if ((m - n) % 2 == 1 && GCD(n, m) == 1)
                    {
                        long a = ((m * m) - (n * n));
                        long b = (2 * m * n);
                        long c = ((m * m) + (n * n));
                        long k = 1;

                        if (n % 2 == 1 && m % 2 == 1)
                        {
                            a /= 2;
                            b /= 2;
                            c /= 2;
                        }


                        while (k * (a + b + c) <= 1500000)
                        {
                            values.Add(new Tuple<long, long, long>(k * a, k * b, k * c));
                            k++;
                        }
                    }
                }
            }
            return values.Select(x => x.Item1 + x.Item2 + x.Item3).GroupBy(x => x).Where(x => x.Count() == 1).Count().ToString();
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
    public class TupleComparer : IEqualityComparer<Tuple<int, int, int>>
    {

        public bool Equals(Tuple<int, int, int> x, Tuple<int, int, int> y)
        {
            return (x.Item1 == y.Item1 && x.Item2 == x.Item2 && x.Item3 == y.Item3)
                    || (x.Item1 == y.Item1 && x.Item2 == x.Item3 && x.Item3 == y.Item2)
                    || (x.Item1 == y.Item2 && x.Item2 == x.Item1 && x.Item3 == y.Item3)
                    || (x.Item1 == y.Item2 && x.Item2 == x.Item3 && x.Item3 == y.Item1)
                    || (x.Item1 == y.Item3 && x.Item2 == x.Item1 && x.Item3 == y.Item2)
                    || (x.Item1 == y.Item3 && x.Item2 == x.Item2 && x.Item3 == y.Item1);

        }

        public int GetHashCode(Tuple<int, int, int> obj)
        {
                if (Object.ReferenceEquals (obj, null)) return 0;

                // Get the hash code for the name field if it is not null. 
                int hashProductName = obj.ToString() == null ? 0 : obj.GetHashCode();

                // Get the hash code for the code field. 
                int hashProductCode = obj.GetHashCode();

                // Calculate the hash code for the product. 
                return hashProductName ^ hashProductCode;
        }
    }
}
