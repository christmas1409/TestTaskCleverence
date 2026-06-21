using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskCleverence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Принимаем на входе строку 
            string inputLine = Console.ReadLine();
            string compressData = Compressor.Compress(inputLine);
            string deCompressData = Decompressor.Decompress(compressData);
            
            Console.WriteLine($"Входная строка: {inputLine}");
            Console.WriteLine($"Результат компрессии: {compressData}");
            Console.WriteLine($"Результат декомпрессии: {deCompressData}");


        }
    }
}
