using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * 
 * In the 5 by 5 matrix below, the minimal path sum from the top left to the bottom right, by only moving to the right and down, is indicated in bold red and is equal to 2427.

⎛⎝⎜⎜⎜⎜⎜⎜131201630537805673968036997322343427464975241039654221213718150111956331⎞⎠⎟⎟⎟⎟⎟⎟
Find the minimal path sum, in matrix.txt (right click and "Save Link/Target As..."), a 31K text file containing a 80 by 80 matrix, from the top left to the bottom right by only moving right and down.
 * 
 * (\*/
namespace ProjectEuler.Problems
{
    class Problem81:IProblem
    {
        public string Run()
        {
            string[] keys = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p081_matrix.txt");
            long[][] matrix = new long[keys.Length][];
            int count = keys.Length;
            for (int i = 0; i < keys.Length; i++)
            {
                matrix[i] = keys[i].Split(',').Select(x => Convert.ToInt64(x)).ToArray();
            }
            for (int i = count - 2; i >= 0; i--)
            {
                for (int x = count-1; x >= i; x--)
                {
                    if (x == count - 1)
                    {
                        matrix[i][x] += matrix[i + 1][x];
                        matrix[x][i] += matrix[x][i + 1];
                    }
                    else if(x!=i)
                    {
                        matrix[i][x] += Math.Min(matrix[i + 1][x], matrix[i][x + 1]);
                        matrix[x][i] += Math.Min(matrix[x + 1][i], matrix[x][i + 1]);
                    }
                    else
                    {
                        matrix[i][i] += Math.Min(matrix[i + 1][i], matrix[i][i + 1]);
                    }
                }
            }

            return matrix[0][0].ToString();
        }
    }
}
