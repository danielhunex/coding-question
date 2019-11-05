namespace FileParser
{
    public class TabDelimitedFile : IDelimitedFile
    {
        private char TabDelimiter = '\t';
        private readonly IParser _parser;

        public TabDelimitedFile():this(new Parser())
        {
        }
        
        public TabDelimitedFile(IParser parser)
        {
            _parser = parser;
        }
        public void ParseFile(string filePath, byte numberOfFields)
        {
            _parser.Parse(filePath, TabDelimiter, numberOfFields);
        }
    }


}


