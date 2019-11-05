using System;
using System.Collections.Generic;
using System.IO;

namespace FileParser
{
    public class Parser : IParser
    {

        public void Parse(string filePath, char delimiter, byte numberOfFields)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("cannot be null or empty", "filePath");
            }
            if (numberOfFields <= 0)
            {
                throw new ArgumentException("cannot be zero or negative");
            }

            string[] data = File.ReadAllLines(filePath);

            if (data == null || data.Length <= 1)
            {
                throw new Exception("File is either empty, null or contains only single line");
            }

            var correctlyFormatted = new List<string>();
            var inCorrectlyFormatted = new List<string>();

            for (int i = 1; i < data.Length; i++)
            {
                Process(data[i], correctlyFormatted, inCorrectlyFormatted, numberOfFields, delimiter);
            }

            File.WriteAllLines($"{Directory.GetCurrentDirectory()}\\correct.txt", correctlyFormatted.ToArray());
            File.WriteAllLines($"{Directory.GetCurrentDirectory()}\\inCorrect.txt", inCorrectlyFormatted.ToArray());

        }

        private void Process(string row, List<string> correctlyFormatted, List<string> inCorrectlyFormatted, byte numberOfFields, char delimiter)
        {
            char Quote = '"';

            bool quoteOpened = false;
            int count = 0;

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == Quote)
                {
                    quoteOpened = !quoteOpened;
                }

                if (!quoteOpened)
                {
                    if (row[i] == delimiter)
                    {
                        count++;
                    }
                }
            }

            if (count == numberOfFields - 1)
            {
                correctlyFormatted.Add(row);
            }
            else
            {
                inCorrectlyFormatted.Add(row);
            }
        }
    }


}


