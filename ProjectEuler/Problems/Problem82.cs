using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 
 * NOTE: This problem is a more challenging version of Problem 81.

The minimal path sum in the 5 by 5 matrix below, by starting in any cell in the left column and finishing in any cell in the right column, and only moving up, down, and right, is indicated in red and bold; the sum is equal to 994.

⎛⎝⎜⎜⎜⎜⎜⎜131201630537805673968036997322343427464975241039654221213718150111956331⎞⎠⎟⎟⎟⎟⎟⎟
Find the minimal path sum, in matrix.txt (right click and "Save Link/Target As..."), a 31K text file containing a 80 by 80 matrix, from the left column to the right column.
 * 
 * */

namespace ProjectEuler.Problems
{
    public class Problem82:IProblem
    {
        public string Run()
        {
            string[] keys = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p082_matrix.txt");
            long[][] matrix = new long[keys.Length][];
            int count = keys.Length;
            for (int i = 0; i < keys.Length; i++)
            {
                matrix[i] = keys[i].Split(',').Select(x => Convert.ToInt64(x)).ToArray();
            }
            for (int i = count - 2; i >= 0; i--)
            {
                for (int x = count - 1; x >= 0; x--)
                {
                    if (x == 0)
                        matrix[x][i] += matrix[x][i + 1];
                    else
                    {
                        matrix[x][i] += Math.Min(matrix[x - 1][i] + matrix[x - 1][i + 1], matrix[x][i + 1]);
                    }

                }
            }

            long min = Int32.MaxValue;

            for(int x=0; x<matrix.Length; x++){
                if (matrix[x][0] < min)
                    min = matrix[x][0];
            }


            return min.ToString();
        }
    }
}
