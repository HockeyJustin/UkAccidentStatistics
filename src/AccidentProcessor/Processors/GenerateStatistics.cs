using AccidentProcessor.Classes;
using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Processors
{
  public class GenerateStatistics : IStatisticsGenerator
  {
    public GenerateStatistics()
    {
    }

    public OutputStatistics GetStatisticsFromRelevantData(List<Accident> relevantDataRows)
    {
      OutputStatistics stats = new OutputStatistics();

      // loop through that relevant Data rows
      // set flags for the accident so we can tally conditions
      // add to each variable that meets a criteria.			

      List<Accident> commuterAccidents = new List<Accident>();

      int rowProcessingCount = 0;

      foreach (var dataRow in relevantDataRows)
      {
        Console.WriteLine($"Stats Row: {rowProcessingCount++}");
        bool isAWeekDay = dataRow.IsAccidentOnAWeekDay();
        bool isAWeekend = !dataRow.IsAccidentOnAWeekDay();
        bool is7to8am = dataRow.IsDateTimeBetween7and8am();
        bool is8to9am = dataRow.IsDateTimeBetween8and9am();
        bool is4to5pm = dataRow.IsDateTimeBetween4and5pm();
        bool is5to6pm = dataRow.IsDateTimeBetween5and6pm();
        bool isCommuterTime = dataRow.IsDateTimeInCommuterHours();
        bool isAutumn = dataRow.IsUkAutumn();
        bool isWinter = dataRow.IsUkWinter();
        bool isRoadWetDampSnowFrost = dataRow.AreConditionsWetDampSnowOrIce();
        bool isRoadConditionKnown = dataRow.AreRoadConditionsKnown();
        bool isAccidentSeverityKnown = dataRow.IsAccidentSeverityKnown();
        bool isAccidentSerious = dataRow.IsAccidentSerious();
        bool isAccidentFatal = dataRow.IsAccidentFatal();
        bool isVehicle1DriverAgeKnown = dataRow.IsVehicle1DriverAgeKnown();
        bool isVehicle2DriverAgeKnown = dataRow.IsVehicle2DriverAgeKnown();
        bool isOneVehicleOnlyInvolved = dataRow.IsOneVehicleOnlyInvolved();
        bool isABikeInvolved = dataRow.IsABikeInvolved();
        bool isACarInvovled = dataRow.IsACarInvolved();
        bool isAVanInvolved = dataRow.IsAVanInvolved();
        bool isAGoodsVehicleInvolved = dataRow.IsAGoodsVehiclesInvolved();



        if (isCommuterTime)
        {
          commuterAccidents.Add(dataRow);
        }

        stats.TotalAccidentsPerYear++;
        stats.TotalAccidentsOnAWeekday = (isAWeekDay) ? stats.TotalAccidentsOnAWeekday + 1 : stats.TotalAccidentsOnAWeekday;
        stats.TotalAccidentsOnAWeekend = (isAWeekend) ? stats.TotalAccidentsOnAWeekend + 1 : stats.TotalAccidentsOnAWeekend;

        stats.Accidents7To8AmWeekday = (is7to8am) ? stats.Accidents7To8AmWeekday + 1 : stats.Accidents7To8AmWeekday;
        stats.Accidents8To9AmWeekday = (is8to9am) ? stats.Accidents8To9AmWeekday + 1 : stats.Accidents8To9AmWeekday;
        stats.Accidents4To5PmWeekday = (is4to5pm) ? stats.Accidents4To5PmWeekday + 1 : stats.Accidents4To5PmWeekday;
        stats.Accidents5To6PmWeekday = (is5to6pm) ? stats.Accidents5To6PmWeekday + 1 : stats.Accidents5To6PmWeekday;
        stats.AccidentsInWeekdayCommuterHours = (isCommuterTime) ? stats.AccidentsInWeekdayCommuterHours + 1 : stats.AccidentsInWeekdayCommuterHours;

        stats.AccidentsTotal_Autumn = isAutumn ? stats.AccidentsTotal_Autumn + 1 : stats.AccidentsTotal_Autumn;
        stats.Accidents7To8AmWeekday_Autumn = (isCommuterTime && isAutumn && is7to8am) ? stats.Accidents7To8AmWeekday_Autumn + 1 : stats.Accidents7To8AmWeekday_Autumn;
        stats.Accidents8To9AmWeekday_Autumn = (isCommuterTime && isAutumn && is8to9am) ? stats.Accidents8To9AmWeekday_Autumn + 1 : stats.Accidents8To9AmWeekday_Autumn;
        stats.Accidents4To5PmWeekday_Autumn = (isCommuterTime && isAutumn && is4to5pm) ? stats.Accidents4To5PmWeekday_Autumn + 1 : stats.Accidents4To5PmWeekday_Autumn;
        stats.Accidents5To6PmWeekday_Autumn = (isCommuterTime && isAutumn && is5to6pm) ? stats.Accidents5To6PmWeekday_Autumn + 1 : stats.Accidents5To6PmWeekday_Autumn;
        stats.AccidentsWeekdayAllCommuterHours_Autumn = (isCommuterTime && isAutumn) ? stats.AccidentsWeekdayAllCommuterHours_Autumn + 1 : stats.AccidentsWeekdayAllCommuterHours_Autumn;

        stats.AccidentsTotal_Winter = isWinter ? stats.AccidentsTotal_Winter + 1 : stats.AccidentsTotal_Winter;
        stats.Accidents7To8AmWeekday_Winter = (isCommuterTime && isWinter && is7to8am) ? stats.Accidents7To8AmWeekday_Winter + 1 : stats.Accidents7To8AmWeekday_Winter;
        stats.Accidents8To9AmWeekday_Winter = (isCommuterTime && isWinter && is8to9am) ? stats.Accidents8To9AmWeekday_Winter + 1 : stats.Accidents8To9AmWeekday_Winter;
        stats.Accidents4To5PmWeekday_Winter = (isCommuterTime && isWinter && is4to5pm) ? stats.Accidents4To5PmWeekday_Winter + 1 : stats.Accidents4To5PmWeekday_Winter;
        stats.Accidents5To6PmWeekday_Winter = (isCommuterTime && isWinter && is5to6pm) ? stats.Accidents5To6PmWeekday_Winter + 1 : stats.Accidents5To6PmWeekday_Winter;
        stats.AccidentsWeekdayAllCommuterHours_Winter = (isCommuterTime && isWinter) ? stats.AccidentsWeekdayAllCommuterHours_Winter + 1 : stats.AccidentsWeekdayAllCommuterHours_Winter;


        stats.TotalAccidentsWhereConditionsAreKnown = (isRoadConditionKnown) ? stats.TotalAccidentsWhereConditionsAreKnown + 1 : stats.TotalAccidentsWhereConditionsAreKnown;
        stats.TotalAccidentsInWetDampSnowOrFrostAll = (isRoadWetDampSnowFrost) ? stats.TotalAccidentsInWetDampSnowOrFrostAll + 1 : stats.TotalAccidentsInWetDampSnowOrFrostAll;
        stats.CommuterHoursAccidentsWhereConditionsAreKnown = (isCommuterTime && isRoadConditionKnown) ? stats.CommuterHoursAccidentsWhereConditionsAreKnown + 1 : stats.CommuterHoursAccidentsWhereConditionsAreKnown;
        stats.CommuterHoursAccidentsInWetDampSnowOrFrost = (isCommuterTime && isRoadWetDampSnowFrost) ? stats.CommuterHoursAccidentsInWetDampSnowOrFrost + 1 : stats.CommuterHoursAccidentsInWetDampSnowOrFrost;


        stats.TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown = (isCommuterTime && isAccidentSeverityKnown) ? stats.TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown + 1 : stats.TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown;
        stats.TotalSeriousAccidentsPerYear = (isAccidentSerious) ? stats.TotalSeriousAccidentsPerYear + 1 : stats.TotalSeriousAccidentsPerYear;
        stats.TotalSeriousAccidentsPerYearCommuterHours = (isCommuterTime && isAccidentSerious) ? stats.TotalSeriousAccidentsPerYearCommuterHours + 1 : stats.TotalSeriousAccidentsPerYearCommuterHours;
        stats.TotalFatalAccidentsPerYear = (isAccidentFatal) ? stats.TotalFatalAccidentsPerYear + 1 : stats.TotalFatalAccidentsPerYear;
        stats.TotalFatalAccidentsPerYearCommuterHours = (isCommuterTime && isAccidentFatal) ? stats.TotalFatalAccidentsPerYearCommuterHours + 1 : stats.TotalFatalAccidentsPerYearCommuterHours;

        if (isCommuterTime && isVehicle1DriverAgeKnown)
        {
          stats.TotalVehicle1DriverAges_Commuter = stats.TotalVehicle1DriverAges_Commuter + dataRow.Vehicle1DriverAge;
          stats.TotalNumberOfVehicle1DriverAges_Commuter = stats.TotalNumberOfVehicle1DriverAges_Commuter + 1;
        }

        if (isCommuterTime && isVehicle2DriverAgeKnown)
        {
          stats.TotalVehicle2DriverAges_Commuter = stats.TotalVehicle2DriverAges_Commuter + dataRow.Vehicle2DriverAge;
          stats.TotalNumberOfVehicle2DriverAges_Commuter = stats.TotalNumberOfVehicle2DriverAges_Commuter + 1;
        }

        stats.TotalNumberOfAccidentsWithOnly1Vehicle = isOneVehicleOnlyInvolved ? stats.TotalNumberOfAccidentsWithOnly1Vehicle + 1 : stats.TotalNumberOfAccidentsWithOnly1Vehicle;
        stats.TotalNumberOfAccidentsInvolvingABike = isABikeInvolved ? stats.TotalNumberOfAccidentsInvolvingABike + 1 : stats.TotalNumberOfAccidentsInvolvingABike;
        stats.TotalNumberOfAccidentsInvolvingACar = isACarInvovled ? stats.TotalNumberOfAccidentsInvolvingACar + 1 : stats.TotalNumberOfAccidentsInvolvingACar;
        stats.TotalNumberOfAccidentsInvolvingAVan = isAVanInvolved ? stats.TotalNumberOfAccidentsInvolvingAVan + 1 : stats.TotalNumberOfAccidentsInvolvingAVan;
        stats.TotalNumberOfAccidentsInvolvingGoodsVehicles = isAGoodsVehicleInvolved ? stats.TotalNumberOfAccidentsInvolvingGoodsVehicles + 1 : stats.TotalNumberOfAccidentsInvolvingGoodsVehicles;


        stats.NumberOfAccidentsInJanuary = dataRow.AccidentDateAndTime.Month == 1 ? stats.NumberOfAccidentsInJanuary + 1 : stats.NumberOfAccidentsInJanuary;
        stats.NumberOfAccidentsInFebruary = dataRow.AccidentDateAndTime.Month == 2 ? stats.NumberOfAccidentsInFebruary + 1 : stats.NumberOfAccidentsInFebruary;
        stats.NumberOfAccidentsInMarch = dataRow.AccidentDateAndTime.Month == 3 ? stats.NumberOfAccidentsInMarch + 1 : stats.NumberOfAccidentsInMarch;
        stats.NumberOfAccidentsInApril = dataRow.AccidentDateAndTime.Month == 4 ? stats.NumberOfAccidentsInApril + 1 : stats.NumberOfAccidentsInApril;
        stats.NumberOfAccidentsInMay = dataRow.AccidentDateAndTime.Month == 5 ? stats.NumberOfAccidentsInMay + 1 : stats.NumberOfAccidentsInMay;
        stats.NumberOfAccidentsInJune = dataRow.AccidentDateAndTime.Month == 6 ? stats.NumberOfAccidentsInJune + 1 : stats.NumberOfAccidentsInJune;
        stats.NumberOfAccidentsInJuly = dataRow.AccidentDateAndTime.Month == 7 ? stats.NumberOfAccidentsInJuly + 1 : stats.NumberOfAccidentsInJuly;
        stats.NumberOfAccidentsInAugust = dataRow.AccidentDateAndTime.Month == 8 ? stats.NumberOfAccidentsInAugust + 1 : stats.NumberOfAccidentsInAugust;
        stats.NumberOfAccidentsInSeptember = dataRow.AccidentDateAndTime.Month == 9 ? stats.NumberOfAccidentsInSeptember + 1 : stats.NumberOfAccidentsInSeptember;
        stats.NumberOfAccidentsInOctober = dataRow.AccidentDateAndTime.Month == 10 ? stats.NumberOfAccidentsInOctober + 1 : stats.NumberOfAccidentsInOctober;
        stats.NumberOfAccidentsInNovember = dataRow.AccidentDateAndTime.Month == 11 ? stats.NumberOfAccidentsInNovember + 1 : stats.NumberOfAccidentsInNovember;
        stats.NumberOfAccidentsInDecember = dataRow.AccidentDateAndTime.Month == 12 ? stats.NumberOfAccidentsInDecember + 1 : stats.NumberOfAccidentsInDecember;


      } //End loop


      Console.WriteLine($"Just working out some percentages.....");

      // The work out the percentage stats and specials

      stats.AccidentsOnAWeekdayPercentageChance_All_Year = SafePercentage((decimal)stats.TotalAccidentsOnAWeekday, (decimal)Constants.NumberOfDaysInTheYear);
      stats.AccidentsOnAWeekendPercentageChance_All_Year = SafePercentage((decimal)stats.TotalAccidentsOnAWeekend, (decimal)Constants.NumberOfDaysInTheYear);

      stats.Accidents7AmTo8AmAsPercentageOfCommuterDays = SafePercentage((decimal)stats.Accidents7To8AmWeekday, (decimal)Constants.NumberOfWorkDays);
      stats.Accidents8AmTo9AmAsPercentageOfCommuterDays = SafePercentage((decimal)stats.Accidents8To9AmWeekday, (decimal)Constants.NumberOfWorkDays);
      stats.Accidents7AmTo9AmAsPercentageOfCommuterDays = SafePercentage(((decimal)stats.Accidents7To8AmWeekday + (decimal)stats.Accidents8To9AmWeekday), (decimal)Constants.NumberOfWorkDays);

      stats.Accidents4pmTo5PmAsPercentageOfCommuterDays = SafePercentage((decimal)stats.Accidents4To5PmWeekday, (decimal)Constants.NumberOfWorkDays);
      stats.Accidents5pmTo6PmAsPercentageOfCommuterDays = SafePercentage((decimal)stats.Accidents5To6PmWeekday, (decimal)Constants.NumberOfWorkDays);
      stats.Accidents4pmTo6PmAsPercentageOfCommuterDays = SafePercentage(((decimal)stats.Accidents4To5PmWeekday + (decimal)stats.Accidents5To6PmWeekday), (decimal)Constants.NumberOfWorkDays);
      stats.AccidentsInWeekdayCommuterHoursAsPercentageOfCommuterDays = SafePercentage((decimal)stats.AccidentsInWeekdayCommuterHours, (decimal)Constants.NumberOfWorkDays);

      var mostLikelyDayForAnAccident = relevantDataRows.GroupBy(d => d.DayOfWeek).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostLikelyDayForAnAccident = (mostLikelyDayForAnAccident != null) ? (DayOfWeek)mostLikelyDayForAnAccident.First().DayOfWeek : (DayOfWeek?)null;

      var mostLikelyDayCommuterAccident = commuterAccidents.GroupBy(d => d.DayOfWeek).OrderBy(gp => gp.Count()).FirstOrDefault();
      stats.MostLikelyDayForAnAccidentInWeekdayCommuterHours = (mostLikelyDayCommuterAccident != null) ? (DayOfWeek)mostLikelyDayCommuterAccident.First()?.DayOfWeek : (DayOfWeek?)null;
      // ---

      stats.Accidents_PercentageChanceVsDays_Autumn = SafePercentage((decimal)stats.AccidentsTotal_Autumn, (decimal)Constants.NumberOfDaysAutumn);
      stats.Accidents7To8AmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage((decimal)stats.Accidents7To8AmWeekday_Autumn, (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.Accidents8To9AmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage((decimal)stats.Accidents8To9AmWeekday_Autumn, (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.Accidents7To9AmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage(((decimal)stats.Accidents7To8AmWeekday_Autumn + (decimal)stats.Accidents8To9AmWeekday_Autumn), (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.Accidents4To5PmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage((decimal)stats.Accidents4To5PmWeekday_Autumn, (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.Accidents5To6PmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage((decimal)stats.Accidents5To6PmWeekday_Autumn, (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.Accidents4To6PmWeekday_PercentageChanceVsCommuterDays_Autumn = SafePercentage(((decimal)stats.Accidents4To5PmWeekday_Autumn + (decimal)stats.Accidents5To6PmWeekday_Autumn), (decimal)Constants.NumberOfWorkDaysAutumn);
      stats.AccidentsWeekdayAllCommuterHours_PercentageChanceVsCommuterDays_Autumn = SafePercentage((decimal)stats.AccidentsWeekdayAllCommuterHours_Autumn, (decimal)Constants.NumberOfWorkDaysAutumn);


      stats.Accidents_PercentageChanceVsDays_Winter = SafePercentage((decimal)stats.AccidentsTotal_Winter, (decimal)Constants.NumberOfDaysWinter);
      stats.Accidents7To8AmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage((decimal)stats.Accidents7To8AmWeekday_Winter, (decimal)Constants.NumberOfWorkDaysWinter);
      stats.Accidents8To9AmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage((decimal)stats.Accidents8To9AmWeekday_Winter, (decimal)Constants.NumberOfWorkDaysWinter);
      stats.Accidents7To9AmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage(((decimal)stats.Accidents7To8AmWeekday_Winter + (decimal)stats.Accidents8To9AmWeekday_Winter), (decimal)Constants.NumberOfWorkDaysWinter);
      stats.Accidents4To5PmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage((decimal)stats.Accidents4To5PmWeekday_Winter, (decimal)Constants.NumberOfWorkDaysWinter);
      stats.Accidents5To6PmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage((decimal)stats.Accidents5To6PmWeekday_Winter, (decimal)Constants.NumberOfWorkDaysWinter);
      stats.Accidents4To6PmWeekday_PercentageChanceVsCommuterDays_Winter = SafePercentage(((decimal)stats.Accidents4To5PmWeekday_Winter + (decimal)stats.Accidents5To6PmWeekday_Winter), (decimal)Constants.NumberOfWorkDaysWinter);
      stats.AccidentsWeekdayAllCommuterHours_PercentageChanceVsCommuterDays_Winter = SafePercentage((decimal)stats.AccidentsWeekdayAllCommuterHours_Winter, (decimal)Constants.NumberOfWorkDaysWinter);

      stats.AccidentsInWetDampSnowOrFrostAsPercentageOfAllAccidentsWhereConditionsKnown = SafePercentage((decimal)stats.TotalAccidentsInWetDampSnowOrFrostAll, (decimal)stats.TotalAccidentsWhereConditionsAreKnown);
      stats.CommuterHoursAccidentsInWetDampSnowOrFrostAsPercentageOfAllCommuterHoursAccidents = SafePercentage((decimal)stats.CommuterHoursAccidentsInWetDampSnowOrFrost, (decimal)stats.CommuterHoursAccidentsWhereConditionsAreKnown);

      // Movement
      var mostCommonV1Movement = relevantDataRows.GroupBy(d => d.Vehicle1Manoeuvre).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1MovementInAccidents = (mostCommonV1Movement != null) ? (VehicleManoeuvre)mostCommonV1Movement.First()?.Vehicle1Manoeuvre : VehicleManoeuvre.DataMissing;

      var mostCommonV1MovementCommuter = commuterAccidents.GroupBy(d => d.Vehicle1Manoeuvre).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1MovementInCommuterAccidents = (mostCommonV1MovementCommuter != null) ? (VehicleManoeuvre)mostCommonV1MovementCommuter.First()?.Vehicle1Manoeuvre : VehicleManoeuvre.DataMissing;

      var mostCommonV2Movement = relevantDataRows.GroupBy(d => d.Vehicle2Manoeuvre).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2MovementInAccidents = (mostCommonV2Movement != null) ? (VehicleManoeuvre)mostCommonV2Movement.First()?.Vehicle2Manoeuvre : VehicleManoeuvre.DataMissing;

      var mostCommonV2MovementCommuter = commuterAccidents.GroupBy(d => d.Vehicle2Manoeuvre).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2MovementInCommuterAccidents = (mostCommonV2MovementCommuter != null) ? (VehicleManoeuvre)mostCommonV2MovementCommuter.First()?.Vehicle2Manoeuvre : VehicleManoeuvre.DataMissing;

      // Point of Impact
      var mostCommonV1PoI = relevantDataRows.GroupBy(d => d.Vehicle1FirstPointOfImpact).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1PoIInAccidents = (mostCommonV1PoI != null) ? (PointOfImpact)mostCommonV1PoI.First()?.Vehicle1FirstPointOfImpact : PointOfImpact.DataMissing;

      var mostCommonV1PoICommuter = commuterAccidents.GroupBy(d => d.Vehicle1FirstPointOfImpact).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1PoIInCommuterAccidents = (mostCommonV1PoICommuter != null) ? (PointOfImpact)mostCommonV1PoICommuter.First()?.Vehicle1FirstPointOfImpact : PointOfImpact.DataMissing;

      var mostCommonV2PoI = relevantDataRows.GroupBy(d => d.Vehicle1FirstPointOfImpact).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2PoIInAccidents = (mostCommonV2PoI != null) ? (PointOfImpact)mostCommonV2PoI.First()?.Vehicle1FirstPointOfImpact : PointOfImpact.DataMissing;

      var mostCommonV2PoICommuter = commuterAccidents.GroupBy(d => d.Vehicle1FirstPointOfImpact).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2PoIInCommuterAccidents = (mostCommonV2PoICommuter != null) ? (PointOfImpact)mostCommonV2PoICommuter.First()?.Vehicle1FirstPointOfImpact : PointOfImpact.DataMissing;

      // Junction Location
      var mostCommonV1JunctionLoc = relevantDataRows.GroupBy(d => d.Vehicle1JunctionLocation).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1JunctionLocInAccidents = (mostCommonV1JunctionLoc != null) ? (JunctionLocation)mostCommonV1JunctionLoc.First()?.Vehicle1JunctionLocation : JunctionLocation.DataMissing;

      var mostCommonV1JunctionLocCommuter = commuterAccidents.GroupBy(d => d.Vehicle1JunctionLocation).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1JunctionLocInCommuterAccidents = (mostCommonV1JunctionLocCommuter != null) ? (JunctionLocation)mostCommonV1JunctionLocCommuter.First()?.Vehicle1JunctionLocation : JunctionLocation.DataMissing;

      var mostCommonV2JunctionLoc = relevantDataRows.GroupBy(d => d.Vehicle1JunctionLocation).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2JunctionLocInAccidents = (mostCommonV2JunctionLoc != null) ? (JunctionLocation)mostCommonV2JunctionLoc.First()?.Vehicle1JunctionLocation : JunctionLocation.DataMissing;

      var mostCommonV2JunctionLocCommuter = commuterAccidents.GroupBy(d => d.Vehicle1JunctionLocation).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2JunctionLocInCommuterAccidents = (mostCommonV2JunctionLocCommuter != null) ? (JunctionLocation)mostCommonV2JunctionLocCommuter.First()?.Vehicle1JunctionLocation : JunctionLocation.DataMissing;


      //Journey Purpose
      var mostCommonV1JourneyPurpose = relevantDataRows.GroupBy(d => d.Vehicle1JourneyPurpose).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1JourneyPurposeInAccidents = (mostCommonV1JourneyPurpose != null) ? (JourneyPurpose)mostCommonV1JourneyPurpose.First()?.Vehicle1JourneyPurpose : JourneyPurpose.DataMissing;

      var mostCommonV1JourneyPurposeCommuter = commuterAccidents.GroupBy(d => d.Vehicle1JourneyPurpose).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle1JourneyPurposeInCommuterAccidents = (mostCommonV1JourneyPurposeCommuter != null) ? (JourneyPurpose)mostCommonV1JourneyPurposeCommuter.First()?.Vehicle1JourneyPurpose : JourneyPurpose.DataMissing;

      var mostCommonV2JourneyPurpose = relevantDataRows.GroupBy(d => d.Vehicle1JourneyPurpose).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2JourneyPurposeInAccidents = (mostCommonV2JourneyPurpose != null) ? (JourneyPurpose)mostCommonV2JourneyPurpose.First()?.Vehicle1JourneyPurpose : JourneyPurpose.DataMissing;

      var mostCommonV2JourneyPurposeCommuter = commuterAccidents.GroupBy(d => d.Vehicle1JourneyPurpose).OrderByDescending(gp => gp.Count()).FirstOrDefault();
      stats.MostCommonVehicle2JourneyPurposeInCommuterAccidents = (mostCommonV2JourneyPurposeCommuter != null) ? (JourneyPurpose)mostCommonV2JourneyPurposeCommuter.First()?.Vehicle1JourneyPurpose : JourneyPurpose.DataMissing;



      // severity
      stats.PercentageOfAllAccidentsThatAreSerious = SafePercentage((decimal)stats.TotalSeriousAccidentsPerYear, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfCommuterHoursAccidentsThatAreSerious = SafePercentage((decimal)stats.TotalSeriousAccidentsPerYearCommuterHours, (decimal)stats.TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown);
      stats.PercentageOfAllAccidentsThatAreFatal = SafePercentage((decimal)stats.TotalFatalAccidentsPerYear, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfCommuterHoursAccidentsThatAreFatal = SafePercentage((decimal)stats.TotalFatalAccidentsPerYearCommuterHours, (decimal)stats.TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown);

      // age
      stats.AverageAgeVehicle1Driver_Commuter = SafeDivision((decimal)stats.TotalVehicle1DriverAges_Commuter, (decimal)stats.TotalNumberOfVehicle1DriverAges_Commuter);
      stats.AverageAgeVehicle2Driver_Commuter = SafeDivision((decimal)stats.TotalVehicle2DriverAges_Commuter, (decimal)stats.TotalNumberOfVehicle2DriverAges_Commuter);

      // vehicles
      stats.PercentageOfAccidentsInvolving1Vehicle = SafePercentage((decimal)stats.TotalNumberOfAccidentsWithOnly1Vehicle, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfAccidentsInvolvingABike = SafePercentage((decimal)stats.TotalNumberOfAccidentsInvolvingABike, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfAccidentsInvolvingACar = SafePercentage((decimal)stats.TotalNumberOfAccidentsInvolvingACar, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfAccidentsInvolvingAVan = SafePercentage((decimal)stats.TotalNumberOfAccidentsInvolvingAVan, (decimal)stats.TotalAccidentsPerYear);
      stats.PercentageOfAccidentsInvolvingAGoodsVehicle = SafePercentage((decimal)stats.TotalNumberOfAccidentsInvolvingGoodsVehicles, (decimal)stats.TotalAccidentsPerYear);

      return stats;
    }


    private decimal SafePercentage(decimal numerator, decimal denominator)
    {
      return SafeDivision(numerator, denominator) * 100;
    }

    private decimal SafeDivision(decimal numerator, decimal denominator)
    {
      return (denominator == 0) ? 0 : numerator / denominator;
    }
  }
}
