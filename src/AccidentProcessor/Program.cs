using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentProcessor.Classes;
using AccidentProcessor.Interfaces;
using System.Reflection;
using System.Text.RegularExpressions;
using AccidentProcessor.Processors;

namespace AccidentProcessor
{
  /// <summary>
  /// Source data - https://data.gov.uk/dataset/road-accidents-safety-data
  /// </summary>
  public class Program
  {

    // We could make the road classification/numbers inputs? (would have to get round co-ords, so maybe just do whole roads if input coords?

    public static void Main(string[] args)
    {
      // NOTE: Could get this working from args, or a question to start in console.

      // How it works.
      // 1. Go to google maps. 
      // 2. Note the road numbers of your journey (in many cases, this should save you needing multiple boxes).
      // 3. Imagine a box (or boxes) around the roads you want data for.
      // 4. For each box, click on the map to get the SW coordinates and the NE coordinates.

      // 5. Remove my coordinates and add your coordinates to the ICoordinates array
      // 6. Add the relevant road numbers to the roadNumbers array.
      // 7. Run the console.
      //
      // 8. Read the output stats.
      //
      //    Results will be output to the 'Results' folder and will overwrite old data.
      //    Intermediate data will be output to files in the 'Intermediate' folder for visual analysis.
      //
      //    Happy Statting :)
      //      

      IStatisticsGenerator statisticsGenerator = new GenerateStatistics();
      IIdentifyRelevantsAccidents relevantAccidentRowsIdentifier = new IdentifyRelevantAccidents();
      IFillAccidents accidentDataFiller = new FillAccidentDetails(relevantAccidentRowsIdentifier);
      IMakeDictionaryFromClass statsParser = new DictionaryFromClassParser();
      ICsvParser csvParser = new CsvParser();
      IRunAnalysis analysisRunner = new Main(statisticsGenerator, relevantAccidentRowsIdentifier, accidentDataFiller, statsParser, csvParser);

      try
      {
        ICoordinates waterloovilleToHindheadTunnel = new SwNeSquareCoordinates(50.876343, -1.0169207, 51.11028, -0.7232787);
        int[] roadNumbers = new int[] { 3 };

        ICoordinates[] arrayOfAreas = new ICoordinates[] { waterloovilleToHindheadTunnel };

        analysisRunner.RunAnalysis(true, arrayOfAreas, roadNumbers);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();

      }

      Console.WriteLine("End");
      Console.ReadLine();
    }



  }
}


// To investigate trickier areas - use multi-box e.g.
// This shouldn't be needed for many scenarios (for example, this below could be covered with one big box, due to naming the road(s) ).
//ICoordinates waterloovilleToPetersfield = new SwNeSquareCoordinates(50.870000, -1.021764, 51.870000, -0.9379087);
//ICoordinates petersfieldToRakeIsh = new SwNeSquareCoordinates(51.008137, -1.00000005, 51.060000, -0.8500000);
//ICoordinates rakeIshToHindheadTunnel = new SwNeSquareCoordinates(51.060000, -0.9100000, 51.120000, -0.7000000);