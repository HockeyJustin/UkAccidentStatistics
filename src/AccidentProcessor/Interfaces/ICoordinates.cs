using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
	public interface ICoordinates
	{
		bool IsLocationWithinCoordinates(double latitude, double longitude);
	}
}
