using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
    // NOTE:  I appreciate it's not good form to create one file for enums,
    //        but there's loads of them, and I couldn't be faffed to create new files :)

    /// <summary>
    /// WARNING: THIS IS DIFFERENT FROM THE MICROSOFT ENUMERATION, SO DONT GET CONFUSED!
    /// NOTE: The data in the csv did not match the day with the day of the week, so 
    ///       we are going to use the date only.
    /// </summary>
    [Obsolete("Uk Accident Data has proven unreliable for this field - Use Microsofts DayOfWeek", true)]
    public enum DayOfWeekUk
	{
		Sunday = 1,
		Monday = 2,
		Tuesday = 3,
		Wednesday = 4,
		Thursday = 5,
		Friday = 6,
		Saturday = 7,
		Unknown = -1

	}

	public enum RoadClass
	{
		Motorway = 1,
		AM = 2,
		A = 3,
		B = 4,
		C = 5,
		Unclassified = 6,
	}

	public enum AccidentSeverity
	{
		Fatal = 1,
		Serious = 2,
		Slight = 3,
		Unknown = -1,
	}

	public enum LightConditions
	{
		Daylight = 1,
		DarknessLightsLit = 4,
		DarknessLightsUnlit = 5,
		DarknessNoLighting = 6,
		DarknessLightingUnknown = 7,
		DataMissing = -1,
	}

	public enum Weather
	{
		FineNoHighWinds = 1,
		RainingNoHighWinds = 2,
		SnowingNoHighWinds = 3,
		FineHighWinds = 4,
		RainingHighWinds = 5,
		SnowingHighWindss = 6,
		FogOrMist = 7,
		Other = 8,
		Unknown = 9,
		DataMissing = -1
	}

	public enum RoadSurfaceConditions
	{
		Dry = 1,
		WetOrDamp = 2,
		Snow = 3,
		FrostOrIce = 4,
		FloodOver3cmDeep = 5,
		OilOrDiesel = 6,
		Mud = 7,
		DataMissing = -1

	}

	public enum VehicleType
	{
		PedalCycle = 1,
		Motorcycle50ccAndUnder = 2,
		Motorcycle125ccAndUnder = 3,
		MotorcycleOver125ccAndUpTo500cc = 4,
		MotorcycleOver500cc = 5,
		TaxiOrPrivateHireCar = 8,
		Car = 9,
		Minibus_8_16PassengerSeats = 10,
		BusOrCoach17OrMorePassSeats = 11,
		RiddenHorse = 16,
		AgriculturalVehicle = 17,
		Tram = 18,
		VanGGoods3Point5TonnesMgwOrUnder = 19,
		GoodsOver3Point5tAndUnder7Point5t = 20,
		Goods7Point5TonnesMgwAndOver = 21,
		MobilityScooter = 22,
		ElectricMotorcycle = 23,
		OtherVehicle = 90,
		MotorcycleUnknownCc = 97,
		GoodsVehicleUnknownWeight = 98,
		DataMissing = -1,
	}

	public enum VehicleManoeuvre
	{
		Reversing = 1,
		Parked = 2,
		WaitingToGoHeldUp = 3,
		SlowingOrStopping = 4,
		MovingOff = 5,
		UTurn = 6,
		TurningLeft = 7,
		WaitingToTurnLeft = 8,
		TurningRight = 9,
		WaitingToTurnRight = 10,
		ChangingLaneToLeft = 11,
		ChangingLaneToRight = 12,
		OvertakingMovingVehicleOffside = 13,
		OvertakingStaticVehicleOffside = 14,
		OvertakingNearside = 15,
		GoingAheadLeftHandBend = 16,
		GoingAheadRightHandBend = 17,
		//other - .i.e. on a straight?
		GoingAheadOther = 18,
		DataMissing = -1
	}

	public enum JunctionLocation
	{
		NotAtOrWithin20MetresOfJunction = 0,
		ApproachingJunctionOrWaitingParkedAtJunctionApproach = 1,
		ClearedJunctionOrWaitingParkedAtJunctionExit = 2,
		LeavingRoundabout = 3,
		EnteringRoundabout = 4,
		LeavingMainRoad = 5,
		EnteringMainRoad = 6,
		EnteringFromSlipRoad = 7,
		MidJunctionOnRoundaboutOrOnMainRoad = 8,
		DataMissing = -1,
	}

	public enum PointOfImpact
	{
		DidNotImpact = 0,
		Front = 1,
		Back = 2,
		Offside = 3,
		Nearside = 4,
		DataMissing = -1,
	}

	public enum JourneyPurpose
	{
		JourneyAsPartOfWork = 1,
		CommutingToFromWork = 2,
		TakingPupilToFromSchool = 3,
		PupilRidingToFromSchool = 4,
		Other = 5,
		NotKnown = 6,
		OtherNotKnown_2005_10 = 15,
		DataMissing = -1,
	}

	public enum Gender
	{
		Male = 1,
		Female = 2,
		NotKnown = 3,
		DataMissing = -1,
	}
}
