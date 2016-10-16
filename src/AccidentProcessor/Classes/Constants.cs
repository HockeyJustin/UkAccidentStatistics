using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccidentProcessor.Classes
{
    public class Constants
    {
		public static int MorningCommuteHourStart = 6;
		public static int MorningCommuteHoursEnd = 9;

		public static int EveningCommuteHourStart = 16;
		public static int EveningCommuteHoursEnd = 19;

    // *** The UK meteorological autumn begins on 01 September 2016 and ends on 30 November 2016.
    // *** The UK meteorological Winter begins on 01 December 2016 to the end of the year and from Jan 1st to 28 February 2016.
    // www.work-day.co.uk/workingdays_holidays_2015.htm -> 253 work days
    public static int NumberOfDaysInTheYear = 365; //ish!
    public static int NumberOfDaysAutumn = 90;
    public static int NumberOfDaysWinter = 88;
    public static int NumberOfWorkDays = 253;
		public static int NumberOfWorkDaysAutumn = 65;
		public static int NumberOfWorkDaysWinter = 62;

		public static int UkAutumnStartMonth = 9;
		public static int UkAutumnEndMonthInclusive = 11;

		public static int UkWinterStartMonth = 12;
		public static int UkWinterEndMonthInclusive = 2;

	}
}
