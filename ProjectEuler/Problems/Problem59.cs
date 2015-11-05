using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem59:IProblem
    {
        public string Run()
        {
            string cipher = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p059_cipher.txt")[0];
            byte[] content = cipher.Split(',').Select(x => Convert.ToByte(x)).ToArray();
            for (int i = 97; i < 124; i++)
            {
                for (int x = 97; x < 124; x++)
                {
                    for (int q = 97; q < 124; q++)
                    {
                        string text = decrypt(content, new byte[] { (byte)(i), (byte)(x), (byte)(q) });
                        if (text.Contains(" the "))
                            return text.Select(v => Convert.ToInt32(v)).Sum().ToString();
                    }
                }
            }

            return "";
        }
        private string decrypt(byte[] content, byte[] key)
        {
            byte[] temp = new byte[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                temp[i] = (byte)(content[i] ^ key[i % key.Length]);
            }
            return String.Concat(temp.Select(x => Convert.ToChar(x)));
        }
    }
}
