namespace FileParser
{
    public interface IParser
    {
        void Parse(string filePath, char delimiter, byte numberOfFields);
    }


}


