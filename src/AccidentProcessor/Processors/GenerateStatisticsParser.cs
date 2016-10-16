using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AccidentProcessor.Processors
{
  public class DictionaryFromClassParser : IMakeDictionaryFromClass
  {

    public Dictionary<string, string> GetPropertyNameAndValueFromClass(object classInstance)
    {
      Dictionary<string, string> returnValues = new Dictionary<string, string>();


      //Use reflection to get the properties, then loop through them all and get what we want.
      System.Reflection.PropertyInfo[] propertiesInClass = classInstance.GetType().GetProperties();

      foreach (System.Reflection.PropertyInfo info in propertiesInClass)
      {
        try
        {
          if (info.CanRead)
          {
            string nameOfProperty = info.Name;
            object value = info.GetValue(classInstance, null);

            if (nameOfProperty.ToLower().Contains("percent"))
            {
              value = FormatTo2Dp((decimal)value) + "%";
            }

            string outputValue = (value == null) ? "" : value.ToString();
            string details = $"{nameOfProperty} = {outputValue}";
            Console.WriteLine(details);

            returnValues.Add(nameOfProperty, outputValue);
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine("Data output error:" + ex.ToString());

        }
      }

      return returnValues;
    }


    private string FormatTo2Dp(decimal myNumber)
    {
      // Use schoolboy rounding, not bankers.
      myNumber = Math.Round(myNumber, 2, MidpointRounding.AwayFromZero);

      return string.Format("{0:0.00}", myNumber);
    }

  }
}
