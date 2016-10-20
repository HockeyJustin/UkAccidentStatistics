using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccidentProcessor.Processors
{
  public class CsvParser : ICsvParser
  {
    public string[] ReadCsvFromFile(string consoleRef, string fileName)
    {
      string[] returnRows = new string[0];

      int rowCount = 0;

      try
      {
        // NOTE: Doing a very quick get, with little checking here.
        string fileContents = "";

        // Get the contents from the file
        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
          using (var sr = new StreamReader(fs))
          {
            fileContents = sr.ReadToEnd();
          }
        }

        if (String.IsNullOrWhiteSpace(fileContents))
          return returnRows;

        string[] fileContentLines = fileContents.Split(System.Environment.NewLine.ToCharArray());

        if (fileContentLines == null || !fileContentLines.Any())
          return returnRows;

        return fileContentLines;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      return returnRows;
    }




    public void OutputCsvResults(Dictionary<string, string> results, string outputFilePath)
    {
      var csv = new StringBuilder(@"""Key"",""Result""");

      foreach (var result in results)
      {
        var line = String.Format(@"""{0}"",{1}",
               result.Key,
               result.Value);

        csv.AppendLine().Append(line);
      }

      System.IO.File.WriteAllText(outputFilePath, csv.ToString());
    }

  }
}
