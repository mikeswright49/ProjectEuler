using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem42:IProblem
    {
        List<int> triangles = new List<int>();
        int triangleWords = 0;
        public string Run()
        {
            string[] words = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p042_words.txt");
            int longest = words.Select(x => x.Length).Max() * 26;
            int largestTriangle = 0;
            int i = 1;
            while (largestTriangle <= longest)
            {
                largestTriangle = (int)(.5 * (Math.Pow(i, 2) + i));
                triangles.Add(largestTriangle);
                i++;
            }
            foreach (string word in words)
            {
                if (triangles.Contains(getWordValue(word)))
                    triangleWords++;
            }
            return triangleWords.ToString();
        }
        private int getWordValue(string word)
        {
            int sum = 0;
            foreach (char letter in word)
            {
                sum += (letter - 'A') + 1;
            }
            return sum;
        }
    }
}
