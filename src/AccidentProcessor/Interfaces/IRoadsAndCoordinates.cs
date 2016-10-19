using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
	public interface IRoadsAndCoordinates
	{
		bool IsLocationAndRoadARoadAndCoordinatesMatch(double latitude, double longitude, Classes.RoadClass roadClass, int roadNumber);
	}
}
