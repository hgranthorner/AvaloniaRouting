using System.Collections.Generic;
using System.IO;

namespace Parse
{
    public interface IParserService
    {
        IEnumerable<string> ParseData(string filePath);
    }

    public class ParserService : IParserService
    {
        public IEnumerable<string> ParseData(string filePath)
        {
            return File.ReadLines(filePath);
        }
    }
}