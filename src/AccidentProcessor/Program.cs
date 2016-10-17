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

			// INSTRUCTIONS can be found in the README, or https://github.com/HockeyJustin/UkAccidentStatistics
  
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

				//ICoordinates newburyToMaidenhead = new SwNeSquareCoordinates(51.3995, -1.331433, 51.506467, -0.712058);
				//int[] roadNumbers = new int[] { 339, 34, 4, 308 };

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