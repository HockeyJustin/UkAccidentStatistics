using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
  public interface IMakeDictionaryFromClass
  {
    Dictionary<string, string> GetPropertyNameAndValueFromClass(object classInstance);
  }
}
