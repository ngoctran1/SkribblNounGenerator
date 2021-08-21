using System;
using System.Collections.Generic;
using System.IO;

namespace Skirbbl
{
    class Program
    {
        private const int MAX_OUTPUT_WORDS = 1000;

        static void Main(string[] args)
        {
            var filePath = @"nounlist.txt"; // Insert path to noun list (one word per line, no comma) 
            var outFilePath = @"nounlistOut.txt"; // Output path list

            var file = new StreamReader(File.Open(filePath, FileMode.Open));

            var words = new List<string>();
            var chosenWords = new HashSet<string>();

            while(!file.EndOfStream)
            {
                var word = file.ReadLine();
                words.Add(word.Trim());
            }

            var rand = new Random((int)DateTime.UtcNow.Ticks);

            for (var i = 0; i < MAX_OUTPUT_WORDS; i++)
            {
                var num = rand.Next(0, words.Count);
                chosenWords.Add(words[num]);
            }

            var outFile = new StreamWriter(File.Create(outFilePath));

            outFile.WriteLine(string.Join(',', chosenWords));
        }
    }
}
