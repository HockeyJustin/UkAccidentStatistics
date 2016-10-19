using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
	/// <summary>
	/// This will contain a set of coordinates that will make a square or rectangular
	/// area to check if a test coordinate set lies within.
	/// </summary>
	public class SwNeSquareCoordinatesAndRoads : IRoadsAndCoordinates
	{
		public SwNeSquareCoordinatesAndRoads(double southWestLatitude, double southWestLongitude, double northEastLatitude, double northEastLongitude, string[] roads)
		{
			SouthWestLongitude = southWestLongitude;
			SouthWestLatitude =	 southWestLatitude;

			NorthEastLongitude = northEastLongitude;
			NorthEastLatitude =  northEastLatitude;

			// make sure we don't have a case mismatch.
			for(int i=0; i < roads.Count();i++)
			{
				roads[i] = roads[i].Replace(" ", "").Trim().ToUpper();
			}

			Roads = roads;
		}


		double SouthWestLongitude { get; set; }
		double SouthWestLatitude { get; set; }

		double NorthEastLongitude { get; set; }
		double NorthEastLatitude { get; set; }

		/// <summary>
		/// A string of the roads to look at in the area (e.g. M25, A3, A3(M), B10)...
		/// </summary>
		string[] Roads { get; set; }

		/// <summary>
		/// Determine whether a test data point is within the bounds set by this class.
		/// </summary>
		/// <param name="latitude">The latitude coordinate to check if it's within bounds</param>
		/// <param name="longitude">The longitude coordinate to check if it's within bounds</param>
		/// <param name="roadClass">The road class (numbers will match the RoadClass enum)</param>
		/// <param name="roadNumber">The number of the road. E.g. 25 for M25.</param>
		/// <returns></returns>
		public bool IsLocationAndRoadARoadAndCoordinatesMatch(double latitude, double longitude, RoadClass roadClass, int roadNumber)
		{
			var testRoadNumber = BuildRoadNumber(roadClass, roadNumber);

			//NOTE: Assuming a square, so keeping it simple here.
			//      This might need to be updated if crossing lines. Have not tested.
			return Roads.Contains(testRoadNumber) && longitude > SouthWestLongitude && longitude < NorthEastLongitude
				&& latitude > SouthWestLatitude && latitude < NorthEastLatitude;
		}



		private string BuildRoadNumber(RoadClass roadClass, int roadNumber)
		{
			string returnValue = "unknown";

			switch (roadClass)
			{
				case RoadClass.Motorway:
					returnValue = "M";
					break;
				case RoadClass.AM:
					returnValue = "A#(M)";
					break;
				case RoadClass.A:
					returnValue = "A";
					break;
				case RoadClass.B:
					returnValue = "B";
					break;
				case RoadClass.C:
					returnValue = "C";
					break;
			}

			if (roadClass == RoadClass.AM)
			{
				returnValue = returnValue.Replace("#", roadNumber.ToString());
			}
			else
			{
				returnValue = returnValue + roadNumber;
			}

			return returnValue;
		}

	}
}
