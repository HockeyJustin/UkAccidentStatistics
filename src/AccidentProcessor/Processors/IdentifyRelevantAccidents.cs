using AccidentProcessor.Classes;
using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Processors
{
	/// <summary>
	/// This will take the raw accident row data and return only the rows that we are concerned about.
	/// </summary>
	public class IdentifyRelevantAccidents : IIdentifyRelevantsAccidents
	{
		/// <summary>
		/// Returns a list of rows within our set georaphical boundaries.
		/// </summary>
		/// <param name="arrayOfAreas">The boxes we have set for the road (i.e. you can look at part of a road (e.g. a3 around Petersfield)</param>
		/// <param name="rawData">All the accident data.</param>
		/// <param name="expectedRoadClassMinimum">//1 = Motorway, 2=A(M), 3=A, 4=B, 5=C, 6=Unclassified. (allow a range in the method as some are A/A(M))</param>
		/// <param name="expectedRoadClassMaximum">//1 = Motorway, 2=A(M), 3=A, 4=B, 5=C, 6=Unclassified. (allow a range in the method)</param>
		/// <param name="expectedRoadNumbers">The number of the road e.g. 3 for A3. An array to allow multiple numbers.</param>
		/// <returns></returns>
		public string[] GetRelevantRows(string[] rawData, ICoordinates[] arrayOfAreas, int[] expectedRoad1Numbers)
		{
			List<string> returnRows = new List<string>();

			bool isFirstRow = true;
			int rowCount = 0;

			// go through each row of data
			foreach (var row in rawData)
			{
				try
				{
					// The first row is just the header.
					if (isFirstRow)
					{
						isFirstRow = false;
						continue;
					}


					// get the coordinates
					var splitValues = row.Split(new string[] { "," }, StringSplitOptions.None);

					//3 long, 4 lat (would expect lat, long, but that's not the file format!)
					var longitude = double.Parse(splitValues[3]);
					var latitude = double.Parse(splitValues[4]);
					//var roadClass = int.Parse(splitValues[14]); (e.g. motorway, AM, A, B)
					var roadNumber = int.Parse(splitValues[15]);

					Console.WriteLine($"{rowCount++}: Checking {latitude}, {longitude}");

					// if the coords are within any of the areas, add it to the list.
					foreach (ICoordinates box in arrayOfAreas)
					{
						// Is it the a3, and is it within our region (i.e. waterlooville to hindhead)
						if (IsExpectedRoad(expectedRoad1Numbers, roadNumber) 
							&& box.IsLocationWithinCoordinates(latitude, longitude))
						{
							returnRows.Add(row);
							continue;
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"***{rowCount++}: Error parsing row {row}.....Ex: {ex.ToString()}");
				}
			}

			return returnRows.ToArray();
		}


		private bool IsExpectedRoad(int[] expectedRoad1Numbers, int actualRoadNumber)
		{
			return expectedRoad1Numbers.Contains(actualRoadNumber);
		}





		public string[] GetMatchingVehicleRowsFromAccidentData(string[] relevantAccidents, string[] fullVehiclesList)
		{
			List<string> relevantAccidentReferences = new List<string>();
			List<string> returnRows = new List<string>();

			// Get a lookup of the accident references for use later on.
			foreach (var accidentRow in relevantAccidents)
			{
				if(!String.IsNullOrWhiteSpace(accidentRow))
				{
					var splitValues = accidentRow.Split(new string[] { "," }, StringSplitOptions.None);
					relevantAccidentReferences.Add(splitValues[0]);
				}
			}

			// Identify rows in the vehicle data that match the accident reference.
			foreach (var vehicleRow in fullVehiclesList)
			{				
				var vehicleSplitValues = vehicleRow.Split(new string[] { "," }, StringSplitOptions.None);

				Console.WriteLine($"Checking {vehicleSplitValues[0]}");

				if (relevantAccidentReferences.Contains(vehicleSplitValues[0]))
				{
					returnRows.Add(vehicleRow);
				}
			}

			return returnRows.ToArray();
		}

	}
}
