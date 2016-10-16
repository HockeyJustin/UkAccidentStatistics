using AccidentProcessor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Tests.Stubs
{
  public class AccidentStubs
  {

    public static Accident GetAccident1_5thNovember2015WeekdaySingleCarAccidentAt845am()
    {
      Accident accident = new Accident();

      accident.AccidentReferenceNumber = "UnitTest 1";
      accident.AccidentLatitude = 51.089923;
      accident.AccidentLongitude = -0.777943;
      accident.AccidentSeverity = AccidentSeverity.Serious;
      accident.AccidentDateAndTime = new DateTime(2015, 11, 5, 8, 45, 00);

      accident.Road1Number = 3;
      accident.LightConditions = LightConditions.Daylight;
      accident.Weather = Weather.RainingNoHighWinds;
      accident.RoadSurfaceConditions = RoadSurfaceConditions.WetOrDamp;

      accident.Vehicle1Type = VehicleType.Car;
      accident.Vehicle1Manoeuvre = VehicleManoeuvre.GoingAheadOther;
      accident.Vehicle1JunctionLocation = JunctionLocation.NotAtOrWithin20MetresOfJunction;
      accident.Vehicle1FirstPointOfImpact = PointOfImpact.Front;
      accident.Vehicle1JourneyPurpose = JourneyPurpose.CommutingToFromWork;
      accident.Vehicle1DriverGender = Gender.Male;
      accident.Vehicle1DriverAge = 44;
      accident.Vehicle1AgeOfVehicle = 5;

      return accident;
    }

    public static Accident GetAccident2_12thDecember2015WeekendCarAndVanAccidentAt1810()
    {
      Accident accident = new Accident();

      accident.AccidentReferenceNumber = "UnitTest 2";
      accident.AccidentLatitude = 50.903994;
      accident.AccidentLongitude = -1.012061;
      accident.AccidentSeverity = AccidentSeverity.Slight;
      accident.AccidentDateAndTime = new DateTime(2015, 12, 12, 18, 10, 00);

      accident.Road1Number = 3;
      accident.LightConditions = LightConditions.Daylight;
      accident.Weather = Weather.FineNoHighWinds;
      accident.RoadSurfaceConditions = RoadSurfaceConditions.Dry;

      accident.Vehicle1Type = VehicleType.VanGGoods3Point5TonnesMgwOrUnder;
      accident.Vehicle1Manoeuvre = VehicleManoeuvre.ChangingLaneToRight;
      accident.Vehicle1JunctionLocation = JunctionLocation.NotAtOrWithin20MetresOfJunction;
      accident.Vehicle1FirstPointOfImpact = PointOfImpact.Front;
      accident.Vehicle1JourneyPurpose = JourneyPurpose.CommutingToFromWork;
      accident.Vehicle1DriverGender = Gender.Male;
      accident.Vehicle1DriverAge = 44;
      accident.Vehicle1AgeOfVehicle = 10;

      accident.HasSecondVehicle = true;
      accident.Vehicle2Type = VehicleType.Car;
      accident.Vehicle2Manoeuvre = VehicleManoeuvre.GoingAheadOther;
      accident.Vehicle2JunctionLocation = JunctionLocation.NotAtOrWithin20MetresOfJunction;
      accident.Vehicle2FirstPointOfImpact = PointOfImpact.Front;
      accident.Vehicle2JourneyPurpose = JourneyPurpose.NotKnown;
      accident.Vehicle2DriverGender = Gender.Male;
      accident.Vehicle2DriverAge = 53;
      accident.Vehicle2AgeOfVehicle = 2;

      return accident;
    }

  }
}




//accident.AccidentReferenceNumber = 
//accident.AccidentLatitude = 
//accident.AccidentLongitude = 
//accident.AccidentSeverity = 
//accident.AccidentDateAndTime = 

////DayOfWeek DayOfWeek
//accident.Road1Number = 
//accident.LightConditions = 
//accident.Weather = 
//accident.RoadSurfaceConditions = 

//accident.Vehicle1Type = 
//accident.Vehicle1Manoeuvre = 
//accident.Vehicle1JunctionLocation = 
//accident.Vehicle1FirstPointOfImpact = 
//accident.Vehicle1JourneyPurpose = 
//accident.Vehicle1DriverGender = 
//accident.Vehicle1DriverAge = 
//accident.Vehicle1AgeOfVehicle = 

//accident.HasSecondVehicle = 
//accident.Vehicle2Type = 
//accident.Vehicle2Manoeuvre = 
//accident.Vehicle2JunctionLocation = 
//accident.Vehicle2FirstPointOfImpact = 
//accident.Vehicle2JourneyPurpose = 
//accident.Vehicle2DriverGender = 
//accident.Vehicle2DriverAge = 
//accident.Vehicle2AgeOfVehicle = 
