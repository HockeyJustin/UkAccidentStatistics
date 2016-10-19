using AccidentProcessor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
	public interface IIdentifyRelevantsAccidents
	{
		string[] GetRelevantRows(string[] rawData, IRoadsAndCoordinates[] arrayOfAreas);


		string[] GetMatchingVehicleRowsFromAccidentData(string[] relevantAccidents, string[] fullVehiclesList);
	}
}
