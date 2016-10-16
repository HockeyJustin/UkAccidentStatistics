using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
  public interface IRunAnalysis
  {
    void RunAnalysis(bool runFullDataParse, ICoordinates[] arrayOfAreas, int[] roadNumbers);
  }
}
