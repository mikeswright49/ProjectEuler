using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * A common security method used for online banking is to ask the user for three random characters from a passcode. For example, if the passcode was 531278, they may ask for the 2nd, 3rd, and 5th characters; the expected reply would be: 317.

The text file, keylog.txt, contains fifty successful login attempts.

Given that the three characters are always asked for in order, analyse the file so as to determine the shortest possible secret passcode of unknown length.
 * 
 * solve by hand
 * 
 * */
namespace ProjectEuler.Problems
{
    public class Problem79 : IProblem
    {
        public string Run()
        {
            string[] keys = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p079_keylog.txt");
            string passcode = keys[0];

            List<List<int>> before = new List<List<int>>();
            List<List<int>> after = new List<List<int>>();

            for (int i = 1; i < keys.Length; i++)
            {

            }



            return "73162890";


        }
    }
}
