using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            IProblem problem = new Problem80();

            string answer = problem.Run();
            double milliseconds = (DateTime.Now - start).TotalMilliseconds;
            Console.WriteLine("Total Time:"+ milliseconds +"ms Answer:"+answer);
            Console.Read();
        }
    }
}
