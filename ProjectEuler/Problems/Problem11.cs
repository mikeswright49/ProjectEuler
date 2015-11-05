﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem11:IProblem
    {
        public string Run()
        {
            int largestSum = 1;
            List<int[]> grid = new List<int[]>()
            };

            for (int i = 0; i < grid.Count; i++)
            {
                for(int x=0; x<grid[i].Length; x++){
                    //down
                    try
                    {
                        int downProduct = grid[i][x] * grid[i + 1][x] * grid[i + 2][x] * grid[i + 3][x];
                        if (downProduct > largestSum)
                            largestSum = downProduct;
                    }
                    catch { }
                    //right
                    try
                    {
                        int product = grid[i][x] * grid[i ][x+1] * grid[i][x+2] * grid[i][x+3];
                        if (product > largestSum)
                            largestSum = product;
                    }
                    catch { }
                    //down-right
                    try
                    {
                        int product = grid[i][x] * grid[i+1][x + 1] * grid[i+2][x + 2] * grid[i+3][x + 3];
                        if (product > largestSum)
                            largestSum = product;
                    }
                    catch { }
                    //down-left
                    try
                    {
                        int product = grid[i][x] * grid[i-1][x + 1] * grid[i-2][x + 2] * grid[i-3][x + 3];
                        if (product > largestSum)
                            largestSum = product;
                    }
                    catch { }
                }
            }
            return largestSum.ToString();
        }
    }
}