using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
	/// <summary>
	/// This will contain a set of coordinates that will make a square 
	/// area to check if a test coord set lies within.
	/// </summary>
	public class SwNeSquareCoordinates : ICoordinates
	{
		public SwNeSquareCoordinates(double southWestLatitude, double southWestLongitude, double northEastLatitude, double northEastLongitude)
		{
			SouthWestLongitude = southWestLongitude;
			SouthWestLatitude =	 southWestLatitude;

			NorthEastLongitude = northEastLongitude;
			NorthEastLatitude =  northEastLatitude;
		}


		double SouthWestLongitude { get; set; }
		double SouthWestLatitude { get; set; }

		double NorthEastLongitude { get; set; }
		double NorthEastLatitude { get; set; }


		/// <summary
		/// Determine whether a test data point is within the bounds set by this class.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		/// <returns></returns>
		public bool IsLocationWithinCoordinates(double latitude, double longitude)
		{
			//NOTE: Assuming a square, so keeping it simple here.
			//      This might need to be updated if crossing lines. Have not tested.
			return longitude > SouthWestLongitude && longitude < NorthEastLongitude
				&& latitude > SouthWestLatitude && latitude < NorthEastLatitude;
		}

	}
}
