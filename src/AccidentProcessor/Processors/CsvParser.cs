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
        Regex regex = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        StringBuilder sb = new StringBuilder();
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

        foreach (var line in fileContentLines)
        {
          var lineLocal = line;

          Console.WriteLine($"{consoleRef} Line: {rowCount++}");
          string[] fields = regex.Split(lineLocal);
          string streamLineOut = String.Join(",", fields);

          var trimmedLine = streamLineOut.Replace("\"", "");
          sb.AppendLine(trimmedLine);
        }
        var result = sb.ToString();

        returnRows = result.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        return returnRows;


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
