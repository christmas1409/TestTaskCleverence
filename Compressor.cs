using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCleverence
{
    public static class Compressor
    {
        /// <summary>
        /// Сжимает строку с помощью RLE (Run-Length Encoding)
        /// </summary>
        /// <param name="input">Исходная строка</param>
        /// <returns>Сжатая строка</returns>
        public static string Compress(string input)
        {

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();
            char current = input[0];
            int count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == current)
                    count++;
                else
                {
                    sb.Append(current);
                    if (current > 1)
                    {
                        sb.Append(count);
                        current = input[i];
                        count = 1;
                    }
                }
            }
            sb.Append(current);

            if (count > 1)
                sb.Append(count);

            return sb.ToString();
        }
    }
}
