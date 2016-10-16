using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Interfaces
{
  public interface IAccident
  {

    bool IsAccidentOnAWeekDay();

    bool IsDateTimeBetween7and8am();

    bool IsDateTimeBetween8and9am();

    bool IsDateTimeBetween4and5pm();

    bool IsDateTimeBetween5and6pm();

    bool IsDateTimeWithinCommuterHours();

    bool IsUkAutumn();

    bool IsUkWinter();

    bool AreConditionsWetDampSnowOrIce();

    bool AreRoadConditionsKnown();

    bool IsAccidentFatal();

    bool IsAccidentSerious();

    bool IsAccidentSeverityKnown();

    bool IsVehicle1DriverAgeKnown();

    bool IsVehicle2DriverAgeKnown();

    /// <summary>
    /// This will return 1 or 2. The dataset is our dataset, not the original source.
    /// </summary>
    /// <returns></returns>
    int GetNumberOfVehiclesInvolvedInDataset();

    bool IsOneVehicleOnlyInvolved();

    bool IsABikeInvolved();

    bool IsACarInvolved();

    bool IsAVanInvolved();

    bool IsAGoodsVehiclesInvolved();

  }
}
