using AccidentProcessor.Classes;
using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AccidentProcessor.Processors
{
  public class Main : IRunAnalysis
  {
    IStatisticsGenerator _statisticsGenerator;
    IIdentifyRelevantsAccidents _relevantAccidentRowsIdentifier;
    IFillAccidents _accidentDataFiller;
    IMakeDictionaryFromClass _statsParser;
    ICsvParser _csvParser;

    public Main(IStatisticsGenerator statisticsGenerator, IIdentifyRelevantsAccidents relevantAccidentRowsIdentifier, IFillAccidents accidentDataFiller,
                IMakeDictionaryFromClass statsParser, ICsvParser csvParser)
    {
      _statisticsGenerator = statisticsGenerator;
      _relevantAccidentRowsIdentifier = relevantAccidentRowsIdentifier;
      _accidentDataFiller = accidentDataFiller;
      _statsParser = statsParser;
      _csvParser = csvParser;
    }


    public void RunAnalysis(bool runFullDataParse, IRoadsAndCoordinates[] arrayOfAreas)
    {
      //var accidentsCsvLocation = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\TrainingSet_A3\Accidents_2015.csv";
      //var accidentVehiclesCsvLocation = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\TrainingSet_A3\Vehicles_2015.csv";
      var accidentsCsvLocation = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\Accidents_2015.csv";
      var accidentVehiclesCsvLocation = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\Vehicles_2015.csv";


      // A sneaky 'Person of Interest' reference to the "relevant list". No disrespect intended.
      var relevantAccidentsFile = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\Intermediate\Relevant_Accidents.csv";
      var relevantVehiclesFile = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\Intermediate\Relevant_Vehicles.csv";

      string statisticsFilePath = Regex.Split(Assembly.GetEntryAssembly().Location, "bin")[0] + @"Resources\Results\Results.csv";

      string[] relevantAccidentList = null;
      string[] relevantVehicleList = null;



      if (runFullDataParse)
      {
        // *STEP 1*: Get the accident data				
        var allAccidnetDataRows = _csvParser.ReadCsvFromFile("Ac", accidentsCsvLocation);

        // we will output the data with the headers to keep things relevant.
        List<string> relevantListWithHeader = new List<string>() { allAccidnetDataRows[0] };

        // *STEP 2*: Identify the rows that have accidents within our specified area/roads
        relevantAccidentList = _relevantAccidentRowsIdentifier.GetRelevantRows(allAccidnetDataRows, arrayOfAreas);
        relevantListWithHeader.AddRange(relevantAccidentList);

        // save the data out to save the time of parsing in future.
        System.IO.File.WriteAllLines(relevantAccidentsFile, relevantListWithHeader);


        // *STEP 3*: Get all the vehicle data.
        var allVehicleData = _csvParser.ReadCsvFromFile("Vh", accidentVehiclesCsvLocation);

        List<string> relevantVehiclesListWithHeader = new List<string>() { allVehicleData[0] };

        // *STEP 4*: reduce down to only have a list of vehicles that match our accident
        relevantVehicleList = _relevantAccidentRowsIdentifier.GetMatchingVehicleRowsFromAccidentData(relevantAccidents: relevantAccidentList, fullVehiclesList: allVehicleData);

        relevantVehiclesListWithHeader.AddRange(relevantVehicleList);

        // save the data out to save the time of parsing in future.
        System.IO.File.WriteAllLines(relevantVehiclesFile, relevantVehiclesListWithHeader);


        Console.WriteLine($"Relevants: {relevantAccidentList.Count()}");
        Console.WriteLine($"Vehicles: {relevantVehicleList.Count()}");
      }


      if (relevantAccidentList == null)
      {
        relevantAccidentList = _csvParser.ReadCsvFromFile("Rel Ac", relevantAccidentsFile);
        relevantAccidentList = relevantAccidentList.Skip(1).ToArray();
      }

      if (relevantVehicleList == null)
      {
        relevantVehicleList = _csvParser.ReadCsvFromFile("Rel Vh", relevantVehiclesFile);
        relevantVehicleList = relevantVehicleList.Skip(1).ToArray();
      }


      // *STEP 5*: Fill the accident data in a format we can easily make stats from
      List<Accident> relevantAccidentData = _accidentDataFiller.FillAccidentData(relevantAccidentList, relevantVehicleList);


      // *STEP 6*: Make the stats
      OutputStatistics relevantStats = _statisticsGenerator.GetStatisticsFromRelevantData(relevantAccidentData);

      // *STEP 7*: Make a list we can read
      var statsList = _statsParser.GetPropertyNameAndValueFromClass(relevantStats);

      // *STEP 8*: Output the results
      _csvParser.OutputCsvResults(statsList, statisticsFilePath);
    }

  }
}
