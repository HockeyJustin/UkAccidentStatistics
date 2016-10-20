using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
  public class Accident : IAccident
  {
    public string AccidentReferenceNumber { get; set; }

    public double AccidentLatitude { get; set; }

    public double AccidentLongitude { get; set; }

    public AccidentSeverity AccidentSeverity { get; set; }

    /// <summary>
    /// NOTE: This is 2 csv fields in one data row.
    /// </summary>
    public DateTime AccidentDateAndTime { get; set; }

    public DayOfWeek DayOfWeek
    {
      get { return AccidentDateAndTime.DayOfWeek; }
    }


    public int Road1Number { get; set; }

    //
    public LightConditions LightConditions { get; set; }

    public Weather Weather { get; set; }


    public RoadSurfaceConditions RoadSurfaceConditions { get; set; }


    // We are only going to look at the first 2 vehicles, assuming this is the first collision
    // Assume vehicles after 2 are running into an existing collision.
    // Vehicle 1 will have a Vehicle_Reference = 1 in the csv
    // Vehicle 2 will have a Vehicle_Reference = 2 in the csv
    #region "Vehicle Attrs"

    public VehicleType Vehicle1Type { get; set; }
    public VehicleManoeuvre Vehicle1Manoeuvre { get; set; }
    public JunctionLocation Vehicle1JunctionLocation { get; set; }
    public PointOfImpact Vehicle1FirstPointOfImpact { get; set; }
    public JourneyPurpose Vehicle1JourneyPurpose { get; set; }
    public Gender Vehicle1DriverGender { get; set; }
    public int Vehicle1DriverAge { get; set; }
    public int Vehicle1AgeOfVehicle { get; set; }


    public bool HasSecondVehicle { get; set; }
    public VehicleType Vehicle2Type { get; set; }
    public VehicleManoeuvre Vehicle2Manoeuvre { get; set; }
    public JunctionLocation Vehicle2JunctionLocation { get; set; }
    public PointOfImpact Vehicle2FirstPointOfImpact { get; set; }
    public JourneyPurpose Vehicle2JourneyPurpose { get; set; }
    public Gender Vehicle2DriverGender { get; set; }
    public int Vehicle2DriverAge { get; set; }
    public int Vehicle2AgeOfVehicle { get; set; }


    #endregion




    #region "Helper Methods"


    public bool IsAccidentOnAWeekDay()
    {
			// NOTE: We take the day of the week from the date as the csv had some errors in the 'Day of Week' field.
      if (this.DayOfWeek == DayOfWeek.Saturday || this.DayOfWeek == DayOfWeek.Sunday)
        return false;
      else
        return true;
    }

    public bool IsDateTimeBetween7and8am()
    {
      return this.AccidentDateAndTime.Hour == 7;
    }

    public bool IsDateTimeBetween8and9am()
    {
      return this.AccidentDateAndTime.Hour == 8;
    }

    public bool IsDateTimeBetween4and5pm()
    {
      return this.AccidentDateAndTime.Hour == 16;
    }

    public bool IsDateTimeBetween5and6pm()
    {
      return this.AccidentDateAndTime.Hour == 17;
    }

    public bool IsDateTimeWithinCommuterHours()
    {
      // We are not looking at bank holidays, so there is a small margin of error here.
      if (IsAccidentOnAWeekDay() && 
        ((this.AccidentDateAndTime.Hour >= Constants.MorningCommuteHourStart && this.AccidentDateAndTime.Hour < Constants.MorningCommuteHoursEnd)
        || (this.AccidentDateAndTime.Hour >= Constants.EveningCommuteHourStart && this.AccidentDateAndTime.Hour < Constants.EveningCommuteHoursEnd)))
      {
        return true;
      }
      else
      {
        return false;
      }
    }


    public bool IsUkAutumn()
    {
      return this.AccidentDateAndTime.Month >= Constants.UkAutumnStartMonth && this.AccidentDateAndTime.Month <= Constants.UkAutumnEndMonthInclusive;
    }

    public bool IsUkWinter()
    {
      // Note: the or is because these cross over December
      return this.AccidentDateAndTime.Month >= Constants.UkWinterStartMonth || this.AccidentDateAndTime.Month <= Constants.UkWinterEndMonthInclusive;
    }


    public bool AreConditionsWetDampSnowOrIce()
    {
      return this.RoadSurfaceConditions == RoadSurfaceConditions.WetOrDamp ||
        this.RoadSurfaceConditions == RoadSurfaceConditions.FloodOver3cmDeep ||
        this.RoadSurfaceConditions == RoadSurfaceConditions.Snow ||
        this.RoadSurfaceConditions == RoadSurfaceConditions.FrostOrIce;
    }

    public bool AreRoadConditionsKnown()
    {
      return this.RoadSurfaceConditions != RoadSurfaceConditions.DataMissing;
    }


    public bool IsAccidentFatal()
    {
      return this.AccidentSeverity == AccidentSeverity.Fatal;
    }

    public bool IsAccidentSerious()
    {
      return this.AccidentSeverity == AccidentSeverity.Serious;
    }

    public bool IsAccidentSeverityKnown()
    {
      return (int)this.AccidentSeverity > 0;
    }


    public bool IsVehicle1DriverAgeKnown()
    {
      return this.Vehicle1DriverAge > 16;
    }

    public bool IsVehicle2DriverAgeKnown()
    {
      return this.Vehicle2DriverAge > 16;
    }

		/// <summary>
		/// Get the number of vehicles we will look at. It will be 1 or 2.
		/// We only look at the first two cars in these stats.
		/// </summary>
		/// <returns>1 or 2</returns>
		public int GetNumberOfVehiclesInvolvedInDataset()
    {
      // NOTE: The maximum will be 2, as we are only looking at the initial collision
      return this.HasSecondVehicle == true ? 2 : 1;
    }

    public bool IsOneVehicleOnlyInvolved()
    {
      return this.GetNumberOfVehiclesInvolvedInDataset() == 1;
    }

    public bool IsABikeInvolved()
    {
      if (this.Vehicle1Type == VehicleType.PedalCycle || (this.HasSecondVehicle && this.Vehicle2Type == VehicleType.PedalCycle))
      {
        return true;
      }
      return false;
    }

    public bool IsACarInvolved()
    {
      if (this.Vehicle1Type == VehicleType.Car || (this.HasSecondVehicle && this.Vehicle2Type == VehicleType.Car))
      {
        return true;
      }
      return false;
    }

    public bool IsAVanInvolved()
    {
      if (this.Vehicle1Type == VehicleType.VanGGoods3Point5TonnesMgwOrUnder || (this.HasSecondVehicle
        && this.Vehicle2Type == VehicleType.VanGGoods3Point5TonnesMgwOrUnder))
      {
        return true;
      }
      return false;
    }

    public bool IsAGoodsVehiclesInvolved()
    {
      if (IsAGoodsVehicle(this.Vehicle1Type) || (this.HasSecondVehicle && IsAGoodsVehicle(this.Vehicle2Type)))
      {
        return true;
      }
      return false;
    }

    private bool IsAGoodsVehicle(VehicleType type)
    {
      if (type == VehicleType.GoodsVehicleUnknownWeight ||
        type == VehicleType.GoodsOver3Point5tAndUnder7Point5t ||
        type == VehicleType.Goods7Point5TonnesMgwAndOver)
      {
        return true;
      }

      return false;
    }



    #endregion

  }

}
