using AccidentProcessor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
    public interface IStatisticsGenerator
    {
		OutputStatistics GetStatisticsFromRelevantData(List<Accident> relevantDataRows);
    }
}
