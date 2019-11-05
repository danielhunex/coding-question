using System;
using System.IO;

namespace FileParser
{
    class Program
    {
        const string Csv = "csv";
        const string Tsv = "tsv";

        static void Main(string[] args)
        {
            IDelimitedFile delimitedFile;

            Console.WriteLine("Where is the file located ?");

            string fileLocation = Console.ReadLine();

            Console.WriteLine("Is the file format CSV(comma - separated values) or TSV(tab-separated values)?");

            string delimiter = Console.ReadLine();

            Console.WriteLine("How many fields should each record contain?");

            string fields = Console.ReadLine();

            if (!File.Exists(fileLocation))
            {
                Console.WriteLine($"File does not exist at file location: {fileLocation}");

                Console.ReadKey();
                return;
            }

            byte numberOfFields = 0;

            if(byte.TryParse(fields, out numberOfFields))
            {
                if (numberOfFields <= 0)
                {
                    Console.WriteLine("Number of fields should be greater than 0");
                    Console.ReadKey();
                    return;
                }
            }

            if (delimiter.Equals(Csv, StringComparison.OrdinalIgnoreCase))
            {
                delimitedFile = new CommaDelimitedFile();
                delimitedFile.ParseFile(fileLocation, numberOfFields);
            }
            else if (delimiter.Equals(Tsv, StringComparison.OrdinalIgnoreCase))
            {
                delimitedFile = new TabDelimitedFile();
                delimitedFile.ParseFile(fileLocation, numberOfFields);
            }
            else
            {
                Console.WriteLine("Invalid file format. File format should be CSV or TSV");
                Console.ReadKey();
               return;
            }


            Console.WriteLine("File successfully formatted");
            Console.ReadKey();


        }
    }

}


