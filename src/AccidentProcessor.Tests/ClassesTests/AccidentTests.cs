using AccidentProcessor.Classes;
using System;
using Xunit;

namespace AccidentProcessor.Tests.ClassesTests
{
  public class AccidentTests
  {
    Accident _accident1;
    Accident _accident2;

    /// <summary>
    /// xUnit doesn't have [Setup]. We should use the ctor
    /// https://xunit.github.io/docs/comparisons.html
    /// </summary>
    public AccidentTests()
    {
      _accident1 = Stubs.AccidentStubs.GetAccident1_5thNovember2015WeekdaySingleCarAccidentAt845am();
      _accident2 = Stubs.AccidentStubs.GetAccident2_12thDecember2015WeekendCarAndVanAccidentAt1810();
    }

    [Fact]
    public void Accident_OnWeekday_ExpectIsOnWeekday()
    {
      // Arrange (see ctor)
      // Act
      var isWeekDay = _accident1.IsAccidentOnAWeekDay();

      // Assert
      Assert.Equal(true, isWeekDay);
    }


    [Fact]
    public void Accident_OnWeekend_ExpectIsNotOnWeekday()
    {
      // Arrange (see ctor)
      // Act
      var isWeekDay = _accident2.IsAccidentOnAWeekDay();

      // Assert
      Assert.Equal(false, isWeekDay);
    }


    [Theory]
    [InlineData(false, "2016-10-8")]
    [InlineData(false, "2016-10-9")]
    [InlineData(true, "2016-10-10")]
    [InlineData(true, "2016-10-11")]
    [InlineData(true, "2016-10-12")]
    [InlineData(true, "2016-10-13")]
    [InlineData(true, "2016-10-14")]    
    public void AccidentDates_WithInputValues_ExpectResultMatch(bool expectedValue, string dateAsString)
    {
      // Arrange
      Accident accident = new Accident();
      accident.AccidentDateAndTime = DateTime.Parse(dateAsString);

      // Act
      bool isAWeekday = accident.IsAccidentOnAWeekDay();

      // Assert
      Assert.Equal(expectedValue, isAWeekday);
    }



    [Theory]
    // Weekend data - cannot commute.
    [InlineData(-1, false, "2016-10-8 05:59:00")]
    [InlineData(-1, false, "2016-10-8 06:00:00")]
    [InlineData(-1, false, "2016-10-8 07:00:00")]
    [InlineData(-1, false, "2016-10-8 08:59:00")]
    [InlineData(-1, false, "2016-10-8 09:00:00")]
    [InlineData(-1, false, "2016-10-8 15:59:00")]
    [InlineData(-1, false, "2016-10-8 16:00:00")]
    [InlineData(-1, false, "2016-10-8 17:00:00")]
    [InlineData(-1, false, "2016-10-8 18:59:00")]
    [InlineData(-1, false, "2016-10-8 19:00:00")]
    // Weekday
    [InlineData(-1, false, "2016-10-7 05:59:00")]
    [InlineData(-1, true, "2016-10-7 06:00:00")]
    [InlineData(-1, true, "2016-10-7 07:00:00")]
    [InlineData(-1, true, "2016-10-7 08:59:00")]
    [InlineData(-1, false, "2016-10-7 09:00:00")]
    [InlineData(-1, false, "2016-10-7 15:59:00")]
    [InlineData(-1, true, "2016-10-7 16:00:00")]
    [InlineData(-1, true, "2016-10-7 17:00:00")]
    [InlineData(-1, true, "2016-10-7 18:59:00")]
    [InlineData(-1, false, "2016-10-7 19:00:00")]
    // Hours
    [InlineData(7, true, "2016-10-8 07:00:00")]
    [InlineData(7, true, "2016-10-8 07:30:00")]
    [InlineData(7, false, "2016-10-8 08:00:00")]
    [InlineData(8, true, "2016-10-8 08:00:00")]
    [InlineData(8, true, "2016-10-8 08:30:00")]
    [InlineData(8, false, "2016-10-8 09:00:00")]
    [InlineData(16, true, "2016-10-8 16:00:00")]
    [InlineData(16, true, "2016-10-8 16:30:00")]
    [InlineData(16, false, "2016-10-8 17:00:00")]
    [InlineData(17, true, "2016-10-8 17:00:00")]
    [InlineData(17, true, "2016-10-8 17:30:00")]
    [InlineData(17, false, "2016-10-8 18:00:00")]
    public void IsDateTimeAsExpected__ExpectResultMatch(int startHour, bool expectedValue, string dateTimeAsString)
    {
      // Arrange
      Accident accident = new Accident();
      accident.AccidentDateAndTime = DateTime.Parse(dateTimeAsString);

      bool actualValue = false;

      // Act
      if(startHour == -1)
      {
        actualValue = accident.IsDateTimeInCommuterHours();
      }
      else if (startHour == 7)
      {
        actualValue = accident.IsDateTimeBetween7and8am();
      }
      else if (startHour == 8)
      {
        actualValue = accident.IsDateTimeBetween8and9am();
      }
      else if (startHour == 16)
      {
        actualValue = accident.IsDateTimeBetween4and5pm();
      }
      else if (startHour == 17)
      {
        actualValue = accident.IsDateTimeBetween5and6pm();
      }
      else
      {
        throw new InvalidOperationException("No method used.");
      }
        
      // Assert
      Assert.Equal(expectedValue, actualValue);

    }


    public void IsUkAutumn_WithAccidentInAutumn_ExpectTrue()
    {
      // Act
      var isAutumn = _accident1.IsUkAutumn();
      // Assert
      Assert.Equal(true, isAutumn);
    }

    public void IsUkAutumn_WithAccidentInWinter_ExpectFalse()
    {
      // Act
      var isAutumn = _accident2.IsUkAutumn();
      // Assert
      Assert.Equal(false, isAutumn);
    }

    public void IsUkWinter_WithAccidentInWinter_ExpectTrue()
    {
      // Act
      var isWinter = _accident2.IsUkWinter();
      // Assert
      Assert.Equal(true, isWinter);
    }

    public void IsUkWinter_WithAccidentInAutumn_ExpectFalse()
    {
      // Act
      var isWinter = _accident1.IsUkWinter();
      // Assert
      Assert.Equal(false, isWinter);
    }


    [Theory]
    [InlineData(false, Classes.RoadSurfaceConditions.Dry)]
    [InlineData(true, Classes.RoadSurfaceConditions.WetOrDamp)]
    [InlineData(true, Classes.RoadSurfaceConditions.Snow)]
    [InlineData(true, Classes.RoadSurfaceConditions.FrostOrIce)]
    [InlineData(true, Classes.RoadSurfaceConditions.FloodOver3cmDeep)]
    [InlineData(false, Classes.RoadSurfaceConditions.OilOrDiesel)]
    [InlineData(false, Classes.RoadSurfaceConditions.Mud)]
    [InlineData(false, Classes.RoadSurfaceConditions.DataMissing)]
    public void AreConditionsWetDampSnowOrIce_WithEnumValues_ExpectResultsMatch(bool expectedResult, Classes.RoadSurfaceConditions roadConditions)
    {
      // Arrange
      Accident accident = new Accident();
      accident.RoadSurfaceConditions = roadConditions;

      // Act
      bool isWetDampSnowOrIce = accident.AreConditionsWetDampSnowOrIce();

      // Assert
      Assert.Equal(expectedResult, isWetDampSnowOrIce);
    }


    // TODO: Add tests for these methods.
    // bool AreRoadConditionsKnown();
    // bool IsAccidentFatal();
    // bool IsAccidentSerious();
    // bool IsAccidentSeverityKnown();
    // bool IsVehicle1DriverAgeKnown();
    // bool IsVehicle2DriverAgeKnown();
    // int GetNumberOfVehiclesInvolvedInDataset();
    // bool IsOneVehicleOnlyInvolved();
    // bool IsABikeInvolved();
    // bool IsACarInvolved();
    // bool IsAVanInvolved();
    // bool IsAGoodsVehiclesInvolved();
  }
}



