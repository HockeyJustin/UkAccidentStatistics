using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
  public class OutputStatistics
  {

    #region "General"

    /// <summary>
    /// The total number of accidents in the dataset processed (relevant accidents)
    /// </summary>
    public int TotalAccidentsPerYear { get; set; }

    /// <summary>
    /// Total number of accidents on a weekday.
    /// </summary>
    public int TotalAccidentsOnAWeekday { get; set; }

    /// <summary>
    /// Total number of accidents on a weekend.
    /// </summary>
    public int TotalAccidentsOnAWeekend { get; set; }

    /// <summary>
    /// If i am travelling on a weekday, what is the % chance of an accident (rough).
    /// </summary>
    public decimal AccidentsOnAWeekdayPercentageChance_All_Year { get; set; }

    /// <summary>
    /// If I am travelling on a weekend, what is the % chance of an accident (rough).
    /// </summary>
    public decimal AccidentsOnAWeekendPercentageChance_All_Year { get; set; }

    #endregion


    #region "Commute Hours Stats"

    /// <summary>
    /// Number of accidents between 7am and 8am
    /// </summary>
    public int Accidents7To8AmWeekday { get; set; }

    /// <summary>
    /// Number of accidents between 8am and 9am
    /// </summary>
    public int Accidents8To9AmWeekday { get; set; }

    /// <summary>
    /// 7-8 , what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents7AmTo8AmAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// 8-9 , what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents8AmTo9AmAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// Adding 7-8 and 8-9, what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents7AmTo9AmAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// Number of accidents between 4pm and 5pm
    /// </summary>
    public int Accidents4To5PmWeekday { get; set; }

    /// <summary>
    /// Number of accidents between 5pm and 6pm
    /// </summary>
    public int Accidents5To6PmWeekday { get; set; }

    /// <summary>
    /// 4-5pm what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents4pmTo5PmAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// 5-6pm what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents5pmTo6PmAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// Adding 4-5pm and 5-6pm, what's the percentage chance of there being an accident on the way to work.
    /// </summary>
    public decimal Accidents4pmTo6PmAsPercentageOfCommuterDays { get; set; }


    /// <summary>
    /// Number of accidents during standard commuter hours (see times set in constants - they might not match 7-9,4-6!).
    /// </summary>
    public int AccidentsInWeekdayCommuterHours { get; set; }

    /// <summary>
    /// If i am commuting, what is the percentage chance there will be an accident.
    /// </summary>
    public decimal AccidentsInWeekdayCommuterHoursAsPercentageOfCommuterDays { get; set; }

    /// <summary>
    /// What day are the most accidents?
    /// </summary>
    public DayOfWeek? MostLikelyDayForAnAccident { get; set; }

    /// <summary>
    /// What day are the most accidents in commuter hours?
    /// </summary>
    public DayOfWeek? MostLikelyDayForAnAccidentInWeekdayCommuterHours { get; set; }

    #endregion


    #region "Commute Hours Stats - Autumn"

    // *** The UK meteorological autumn began on 01 September 2015 and ends on 30 November 2015.

    /// <summary>
    /// Number of accidents in Autumn
    /// </summary>
    public int AccidentsTotal_Autumn { get; set; }

    /// <summary>
    /// Percent chance of there being an accident on a day in autumn
    /// </summary>
    public decimal Accidents_PercentageChanceVsDays_Autumn { get; set; }


    /// <summary>
    /// Accidents between 7am-8am in autumn
    /// </summary>
    public int Accidents7To8AmWeekday_Autumn { get; set; }

    /// <summary>
    /// Number of accidents between 4pm and 5pm
    /// </summary>
    public int Accidents8To9AmWeekday_Autumn { get; set; }

    /// <summary>
    /// what's the percentage chance of there being an accident on the way to work between these times in autumn
    /// </summary>
    public decimal Accidents7To8AmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }

    /// <summary>
    /// what's the percentage chance of there being an accident on the way to work between these times in autumn
    /// </summary>
    public decimal Accidents8To9AmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }

    /// <summary>
    /// what's the percentage chance of there being an accident on the way to work between these times in autumn
    /// </summary>
    public decimal Accidents7To9AmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }


    public int Accidents4To5PmWeekday_Autumn { get; set; }
    public int Accidents5To6PmWeekday_Autumn { get; set; }

    public decimal Accidents4To5PmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }

    public decimal Accidents5To6PmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }

    public decimal Accidents4To6PmWeekday_PercentageChanceVsCommuterDays_Autumn { get; set; }

    /// <summary>
    /// Number of commuter accidents in autumn
    /// </summary>
    public int AccidentsWeekdayAllCommuterHours_Autumn { get; set; }

    /// <summary>
    /// If i am commuting in autumn, what is the percentage chance there will be an accident.
    /// </summary>
    public decimal AccidentsWeekdayAllCommuterHours_PercentageChanceVsCommuterDays_Autumn { get; set; }


    #endregion


    #region "Commute Hours Stats - Winter"

    // *** The UK meteorological Winter began on 01 December 2015 and we loop use the beginning of year winter (Jan 1st to 28 February 2015).

    /// <summary>
    /// Number of accidents in Winter
    /// </summary>
    public int AccidentsTotal_Winter { get; set; }

    /// <summary>
    /// Percent chance of there being an accident on a day in Winter
    /// </summary>
    public decimal Accidents_PercentageChanceVsDays_Winter { get; set; }

    /// <summary>
    /// See autumn equivalent
    /// </summary>
    public int Accidents7To8AmWeekday_Winter { get; set; }
    public int Accidents8To9AmWeekday_Winter { get; set; }


    public decimal Accidents7To8AmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }

    public decimal Accidents8To9AmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }

    public decimal Accidents7To9AmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }


    public int Accidents4To5PmWeekday_Winter { get; set; }
    public int Accidents5To6PmWeekday_Winter { get; set; }

    public decimal Accidents4To5PmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }

    public decimal Accidents5To6PmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }

    public decimal Accidents4To6PmWeekday_PercentageChanceVsCommuterDays_Winter { get; set; }


    public int AccidentsWeekdayAllCommuterHours_Winter { get; set; }
    public decimal AccidentsWeekdayAllCommuterHours_PercentageChanceVsCommuterDays_Winter { get; set; }


    #endregion


    #region "Adverse Conditions"

    /// <summary>
    /// Not all accidents have the conditions recorded, so count the ones that are
    /// we'll ignore accidents without conditions for this section of data.
    /// </summary>
    public int TotalAccidentsWhereConditionsAreKnown { get; set; }

    /// <summary>
    /// Count of accidents with adverse conditions.
    /// </summary>
    public int TotalAccidentsInWetDampSnowOrFrostAll { get; set; }

    /// <summary>
    /// % of accidents in adverse conditions.
    /// </summary>
    public decimal AccidentsInWetDampSnowOrFrostAsPercentageOfAllAccidentsWhereConditionsKnown { get; set; }


    /// <summary>
    /// Not all commuter accidents have the conditions recorded, so count the ones that are
    /// we'll ignore accidents without conditions for this section of data.
    /// </summary>
    public int CommuterHoursAccidentsWhereConditionsAreKnown { get; set; }

    /// <summary>
    /// Count of commuter accidents with adverse conditions.
    /// </summary>
    public int CommuterHoursAccidentsInWetDampSnowOrFrost { get; set; }

    /// <summary>
    /// % of commuter accidents in adverse conditions.
    /// </summary>
    public decimal CommuterHoursAccidentsInWetDampSnowOrFrostAsPercentageOfAllCommuterHoursAccidents { get; set; }

    #endregion


    #region "Vehicle Movement In Accident"

    /// <summary>
    /// Of all the movements driver 1 could be doing when he/she crashes,
    /// what is the most common?
    /// </summary>
    public VehicleManoeuvre MostCommonVehicle1MovementInAccidents { get; set; }

    public VehicleManoeuvre MostCommonVehicle1MovementInCommuterAccidents { get; set; }

    /// <summary>
    /// Of all the movements driver 2 could be doing when he/she crashes,
    /// what is the most common?
    /// We ignore incidents after vehicle 2, considering the first two cars to be the cause.
    /// </summary>
    public VehicleManoeuvre MostCommonVehicle2MovementInAccidents { get; set; }

    public VehicleManoeuvre MostCommonVehicle2MovementInCommuterAccidents { get; set; }

    #endregion


    #region "Points Of Impact"

    /// <summary>
    /// Of all the points of the car driver 1 could imapact when he/she crashes,
    /// what is the most common?
    /// </summary>
    public PointOfImpact MostCommonVehicle1PoIInAccidents { get; set; }

    public PointOfImpact MostCommonVehicle1PoIInCommuterAccidents { get; set; }


    public PointOfImpact MostCommonVehicle2PoIInAccidents { get; set; }

    public PointOfImpact MostCommonVehicle2PoIInCommuterAccidents { get; set; }

    #endregion


    #region "Relation to Junctions"

    /// <summary>
    /// What is the most common location when the driver crashes 
    /// e.g. near a junction?
    /// </summary>
    public JunctionLocation MostCommonVehicle1JunctionLocInAccidents { get; set; }

    public JunctionLocation MostCommonVehicle1JunctionLocInCommuterAccidents { get; set; }


    public JunctionLocation MostCommonVehicle2JunctionLocInAccidents { get; set; }

    public JunctionLocation MostCommonVehicle2JunctionLocInCommuterAccidents { get; set; }

    #endregion


    #region "Journey Purpose"

    /// <summary>
    /// What is the most common reason for travel
    /// </summary>
    public JourneyPurpose MostCommonVehicle1JourneyPurposeInAccidents { get; set; }

    public JourneyPurpose MostCommonVehicle1JourneyPurposeInCommuterAccidents { get; set; }


    public JourneyPurpose MostCommonVehicle2JourneyPurposeInAccidents { get; set; }

    public JourneyPurpose MostCommonVehicle2JourneyPurposeInCommuterAccidents { get; set; }

    #endregion


    #region "Severity"

    public int TotalNumberOfCommuterHoursAccidentsWhereSeverityKnown { get; set; }


    public int TotalSeriousAccidentsPerYear { get; set; }

    public int TotalSeriousAccidentsPerYearCommuterHours { get; set; }


    public decimal PercentageOfAllAccidentsThatAreSerious { get; set; }

    public decimal PercentageOfCommuterHoursAccidentsThatAreSerious { get; set; }



    public int TotalFatalAccidentsPerYear { get; set; }

    public int TotalFatalAccidentsPerYearCommuterHours { get; set; }

    public decimal PercentageOfAllAccidentsThatAreFatal { get; set; }

    public decimal PercentageOfCommuterHoursAccidentsThatAreFatal { get; set; }


    #endregion


    #region Age

    public int TotalVehicle1DriverAges_Commuter { get; set; }
    public int TotalNumberOfVehicle1DriverAges_Commuter { get; set; }

    public decimal AverageAgeVehicle1Driver_Commuter { get; set; }

    public int TotalVehicle2DriverAges_Commuter { get; set; }
    public int TotalNumberOfVehicle2DriverAges_Commuter { get; set; }

    public decimal AverageAgeVehicle2Driver_Commuter { get; set; }

    #endregion


    #region "Vehicles"

    /// <summary>
    /// Not all accidents are collisions!
    /// This is a count of accidents involving only 1 vehicle
    /// </summary>
    public int TotalNumberOfAccidentsWithOnly1Vehicle { get; set; }

    /// <summary>
    /// Count of accidents where one of the vehicles is a bike.
    /// </summary>
    public int TotalNumberOfAccidentsInvolvingABike { get; set; }

    /// <summary>
    /// Count of accidents where one of the vehicles is a car.
    /// </summary>
    public int TotalNumberOfAccidentsInvolvingACar { get; set; }

    /// <summary>
    /// Count of accidents where one of the vehicles is a van.
    /// </summary>
    public int TotalNumberOfAccidentsInvolvingAVan { get; set; }

    /// <summary>
    /// Count of accidents where one of the vehicles is a goods vehicle.
    /// </summary>
    public int TotalNumberOfAccidentsInvolvingGoodsVehicles { get; set; }


    /// <summary>
    /// Of all the accidents, what percentage involve only 1 vehicle
    /// </summary>
    public decimal PercentageOfAccidentsInvolving1Vehicle { get; set; }

    /// <summary>
    /// Of all the accidents, what percentage involve at least 1 bike
    /// </summary>
    public decimal PercentageOfAccidentsInvolvingABike { get; set; }

    /// <summary>
    /// Of all the accidents, what percentage involve at least 1 car
    /// </summary>
    public decimal PercentageOfAccidentsInvolvingACar { get; set; }

    /// <summary>
    /// Of all the accidents, what percentage involve at least 1 van
    /// </summary>
    public decimal PercentageOfAccidentsInvolvingAVan { get; set; }

    /// <summary>
    /// Of all the accidents, what percentage involve at least 1 goods vehicle
    /// </summary>
    public decimal PercentageOfAccidentsInvolvingAGoodsVehicle { get; set; }

    #endregion


    #region "Accidents By Month"

    public int NumberOfAccidentsInJanuary { get; set; }
    public int NumberOfAccidentsInFebruary { get; set; }
    public int NumberOfAccidentsInMarch { get; set; }
    public int NumberOfAccidentsInApril { get; set; }
    public int NumberOfAccidentsInMay { get; set; }
    public int NumberOfAccidentsInJune { get; set; }
    public int NumberOfAccidentsInJuly { get; set; }
    public int NumberOfAccidentsInAugust { get; set; }
    public int NumberOfAccidentsInSeptember { get; set; }
    public int NumberOfAccidentsInOctober { get; set; }
    public int NumberOfAccidentsInNovember { get; set; }
    public int NumberOfAccidentsInDecember { get; set; }

    #endregion

  }
}
