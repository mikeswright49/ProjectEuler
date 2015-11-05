using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem61:IProblem
    {
        public string Run()
        {
            List<int>[] values = generateValues();
            var octoganal = values.ElementAt(1);
            values = values.Where(x => x != octoganal).ToArray();
            for (int i = 0; i < octoganal.Count; i++)
            {
                var seed = new List<int>(){octoganal.ElementAt(i)};
                var result = getLinkedValues( values, seed);
                if (result != -1)
                    return result.ToString();
            }
            return "No Solution";
        }
        private int getLinkedValues(List<int>[] values, List<int> valuesUsed)
        {
            if (valuesUsed.Count == 6)
                return valuesUsed.Sum();
            var value = valuesUsed.Last() % 100;
            List<KeyValuePair<List<int>,int>> possibles = values.SelectMany(x=> x.Select(q=> new KeyValuePair<List<int>,int>(x,q)).Where(n=> n.Value> value * 100 && n.Value< (value * 100) + 99 && !valuesUsed.Contains(n.Value))).ToList();
            if (possibles.Count == 0)
                return -1;
            List<int> bfs = new List<int>();
            foreach (KeyValuePair<List<int>,int> x in possibles)
            {
                var tempList = valuesUsed.ToList();
                tempList.Add(x.Value);
                var tempValues = values.ToList();
                tempValues.Remove(x.Key);
                bfs.Add(getLinkedValues(tempValues.ToArray(), tempList));
            }
            return bfs.Max();
        }
        private List<int>[] generateValues()
        {
            List<int>[] values = new List<int>[6];

            for (int i = 0; i < values.Length; i++)
            {
                int index = 1;
                while (true)
                {
                    int result = 0;
                    switch (i)
                    {
                        case 0:
                            result = generateTriangle(index);
                            break;
                        case 1:
                            result = generateSquare(index);
                            break;
                        case 2:
                            result = generatePentagon(index);
                            break;
                        case 3:
                            result = generateHexagon(index);
                            break;
                        case 4:
                            result = generateHeptagon(index);
                            break;
                        case 5:
                            result = generateOctagon(index);
                            break;

                    }
                    if (result >= 1000 && result < 10000)
                    {
                        if (values[i] == null)
                            values[i] = new List<int>();
                        values[i].Add(result);
                    }
                    else if (result > 10000)
                        break;
                    index++;
                }
            }
            return values;
        }

        private int generateTriangle(int x)
        {
            return (int)x*(x+1) / 2;
        }
        private int generateSquare(int x)
        {
            return (int)Math.Pow(x, 2);
        }
        private int generatePentagon(int x)
        {
            return (int)((3 * Math.Pow(x, 2)) - x) / 2;
        }
        private int generateHexagon(int x)
        {
            return (int)((2 * Math.Pow(x, 2)) - x);
        }
        private int generateHeptagon(int x)
        {
            return (int)((5 * Math.Pow(x, 2)) - (3*x))/2;
        }
        private int generateOctagon(int x)
        {
            return (int)((3 * Math.Pow(x, 2)) - (2 * x));
        }
    }
}
