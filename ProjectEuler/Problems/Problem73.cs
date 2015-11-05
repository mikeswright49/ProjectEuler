using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem73 :IProblem
    {
        public string Run()
        {
            List<Tuple<double, double>> values = new List<Tuple<double, double>>();
            for (double i = 12000; i > 0; i--)
            {
                for (double x = Math.Ceiling(i / 3d); x < Math.Ceiling(i / 2d); x++)
                {
                    values.Add(new Tuple<double, double>(x, i));
                }
            }
            return values.Select(x => x.Item1 / x.Item2).Where(x=>x>1d/3d).Distinct().Count().ToString();
        }
    }
}
