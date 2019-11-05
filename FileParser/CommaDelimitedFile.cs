namespace FileParser
{
    public class CommaDelimitedFile : IDelimitedFile
    {

        private char COMMA = ',';
        private IParser _parser;

        public CommaDelimitedFile(IParser parser)
        {
            _parser = parser;
        }

        public CommaDelimitedFile() : this(new Parser())
        {

        }

        public void ParseFile(string filePath, byte numberOfFields)
        {
            _parser.Parse(filePath, COMMA, numberOfFields);
        }
    }


}


