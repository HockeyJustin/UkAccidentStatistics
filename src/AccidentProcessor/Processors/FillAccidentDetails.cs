using AccidentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccidentProcessor.Classes;

namespace AccidentProcessor.Processors
{
	public class FillAccidentDetails : IFillAccidents
	{
		IIdentifyRelevantsAccidents _relevantAccidentIdentifier;

		public FillAccidentDetails(IIdentifyRelevantsAccidents relevantAccidentIdentifier)
		{
			_relevantAccidentIdentifier = relevantAccidentIdentifier;
		}


		public List<Accident> FillAccidentData(string[] relevantAccidentRows, string[] relevantVehicleRows)
		{
			List<Accident> accidentList = new List<Accident>();

			foreach (var accidentRow in relevantAccidentRows)
			{
				try
				{
					var accidentSplit = accidentRow.Split(new string[] { "," }, StringSplitOptions.None);

					Accident accident = new Accident();
					accident.AccidentReferenceNumber = accidentSplit[0];
					accident.AccidentLatitude = double.Parse(accidentSplit[4]);
					accident.AccidentLongitude = double.Parse(accidentSplit[3]);
					accident.AccidentSeverity = (AccidentSeverity)int.Parse(accidentSplit[6]);
					var dateAndTimeString = accidentSplit[9] + " " + accidentSplit[11];
					accident.AccidentDateAndTime = DateTime.Parse(dateAndTimeString);
          // The day of week in the csv does not match RResources\Reference\Road-Accident-Safety-Data-Guide.xls, so we will take it from the date.
          
					accident.Road1Number = int.Parse(accidentSplit[15]);
					accident.LightConditions = (LightConditions)int.Parse(accidentSplit[24]);
					accident.Weather = (Weather)int.Parse(accidentSplit[25]);
					accident.RoadSurfaceConditions = (RoadSurfaceConditions)int.Parse(accidentSplit[26]);


					// Fill in the vehicle info.

					var relatedVehicleRows = _relevantAccidentIdentifier.GetMatchingVehicleRowsFromAccidentData(relevantAccidents: new string[] { accident.AccidentReferenceNumber },
																												fullVehiclesList: relevantVehicleRows);

					if (relevantVehicleRows == null || !relatedVehicleRows.Any())
					{
						throw new InvalidOperationException($"No vehicle data for {accident.AccidentReferenceNumber}");
					}

					// Flatten out the vehicle data to one row.

					foreach (var vehicleRow in relatedVehicleRows)
					{
						var vehicleSplit = vehicleRow.Split(new string[] { "," }, StringSplitOptions.None);

						int vehicleReference = int.Parse(vehicleSplit[1]);

						if (vehicleReference == 1)
						{
							accident.Vehicle1Type = (VehicleType)int.Parse(vehicleSplit[2]);
							accident.Vehicle1Manoeuvre = (VehicleManoeuvre)int.Parse(vehicleSplit[4]);
							accident.Vehicle1JunctionLocation = (JunctionLocation)int.Parse(vehicleSplit[6]);
							accident.Vehicle1FirstPointOfImpact = (PointOfImpact)int.Parse(vehicleSplit[11]);
							accident.Vehicle1JourneyPurpose = (JourneyPurpose)int.Parse(vehicleSplit[13]);
							accident.Vehicle1DriverGender = (Gender)int.Parse(vehicleSplit[14]);
							accident.Vehicle1DriverAge = int.Parse(vehicleSplit[15]); // WARNING FOR CALCS. THIS CAN BE -1 if unknown
							accident.Vehicle1AgeOfVehicle = int.Parse(vehicleSplit[19]); // WARNING FOR CALCS. THIS CAN BE -1 if unknown
						}
						else if (vehicleReference == 2)
						{
              accident.HasSecondVehicle = true;
							accident.Vehicle2Type = (VehicleType)int.Parse(vehicleSplit[2]);
							accident.Vehicle2Manoeuvre = (VehicleManoeuvre)int.Parse(vehicleSplit[4]);
							accident.Vehicle2JunctionLocation = (JunctionLocation)int.Parse(vehicleSplit[6]);
							accident.Vehicle2FirstPointOfImpact = (PointOfImpact)int.Parse(vehicleSplit[11]);
							accident.Vehicle2JourneyPurpose = (JourneyPurpose)int.Parse(vehicleSplit[13]);
							accident.Vehicle2DriverGender = (Gender)int.Parse(vehicleSplit[14]);
							accident.Vehicle2DriverAge = int.Parse(vehicleSplit[15]); // WARNING FOR CALCS. THIS CAN BE -1 if unknown
							accident.Vehicle2AgeOfVehicle = int.Parse(vehicleSplit[19]); // WARNING FOR CALCS. THIS CAN BE -1 if unknown
						}
					}

					accidentList.Add(accident);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
          // Stop so we see the error.
          Console.WriteLine("Press enter to continue");
          Console.ReadLine();
				}

			}

			return accidentList;
		}

	}
}
