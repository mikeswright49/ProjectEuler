using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem22 : IProblem
    {
        public string Run()
        {
            string[] names = File.ReadAllLines(Environment.CurrentDirectory+@"\Files\p022_names.txt");
            names = names.OrderBy(x => x).ToArray();
            long sum = 0;
            for (int i = 0; i < names.Length; i++)
            {
                int letterSum = 0;
                for (int x = 0; x < names[i].Length; x++)
                {
                    letterSum += (names[i][x] - 'A' + 1);
                }
                sum += (i + 1) * letterSum;
                Console.WriteLine(names[i] + " " + letterSum + " " + (i + 1) + " " + sum);
            }

            return sum.ToString();
        }
        //This merge sort implementation doesn't work;
        private string[] mergeSort(string[] input, int start, int end)
        {
            if (input.Length == 1)
                return input;

            int middle = (end - start) / 2;

            string[] left = splice(input, start, middle - 1);
            string[] right = splice(input, middle, end);
            left = mergeSort(left, 0, left.Length - 1);
            right = mergeSort(right, 0, right.Length - 1);
            return merge(left, right);
        }
        private string[] splice(string[] input, int start, int end)
        {
            if (input.Length == 1)
                return input;
            string[] tempArray;
            if (end - start < 1 || end < 0)
            {
                tempArray = new string[1];
                tempArray[0] = input[0];
            }
            else
            {
                tempArray = new string[end - start];
                for (int i = 0; i < tempArray.Length; i++)
                    tempArray[i] = input[end--];
            }

            return tempArray;
        }
        private string[] merge(string[] left, string[] right)
        {
            string[] merged = new string[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = 0; i < merged.Length; i++)
            {
                if (leftIndex >= left.Length)
                {
                    merged[i] = right[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    merged[i] = left[leftIndex];
                    leftIndex++;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex])!=1)
                {
                    merged[i] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    merged[i] = right[rightIndex];
                    rightIndex++;
                }
            }
            return merged;
        }
    }
}
