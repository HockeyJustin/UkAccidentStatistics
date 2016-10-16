using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
  public interface ICsvParser
  {
    string[] ReadCsvFromFile(string consoleRef, string fileName);

    void OutputCsvResults(Dictionary<string, string> results, string outputFilePath);
  }
}
