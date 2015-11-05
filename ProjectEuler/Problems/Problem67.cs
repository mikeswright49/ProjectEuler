using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom in triangle.txt (right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.
 * */
/*
 * Can't do a bfs, as that involves recalcing the tree
 * */
namespace ProjectEuler.Problems
{
    public class Problem67:IProblem
    {

        public string Run()
        {
            string[] triangle = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p067_triangle.txt");
            int[][] tree = new int[triangle.Length][];
            for(int i=0;i<triangle.Length; i++){
                tree[i] = triangle[i].Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            }
            for (int i = tree.Length - 2; i >= 0; i--)
            {
                for (int x = 0; x < tree[i].Length; x++)
                    tree[i][x] += Math.Max(tree[i + 1][x], tree[i + 1][x + 1]);
            }
            return tree[0][0].ToString();
        }
        /**
         * This won't work
         * */
        private int GetMax(int[][] tree, int depth, int index)
        {
            if (depth == tree.Length-1)
                return tree[depth][index];
            else
                return tree[depth][index] + Math.Max(GetMax(tree, depth + 1, index), GetMax(tree, depth + 1, index + 1));
        }
    }
}
