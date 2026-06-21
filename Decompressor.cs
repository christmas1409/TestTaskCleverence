using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCleverence
{
    public static class Decompressor
    {
        /// <summary>
        /// Восстанавливает исходную строку из сжатой RLE
        /// </summary>
        /// <param name="compressed">Сжатая строка</param>
        /// <returns>Исходная строка</returns>
        public static string Decompress(string input)
        {
            // Проверка на пустоту строки
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder sb = new StringBuilder();

            // Прохождение по всей строке
            for (int i = 0; i < input.Length; i++)
            {
                // возьмём начальный символ строки
                char ch = input[i];

                if (char.IsLetter(ch))
                {
                    int begin = i + 1;

                    while (begin < input.Length && char.IsDigit(input[begin]))
                    {
                        begin++;
                    }

                    if (begin > i + 1)
                    {
                        int count = int.Parse(input.Substring(i + 1, begin - i - 1));
                        sb.Append(ch, count);
                        i = begin - 1;
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
