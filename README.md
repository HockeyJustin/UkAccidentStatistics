# UK Road Accident Statistics Generator

## UK Road Accident Statistics From the [Governments Open Source Accident Data](https://data.gov.uk/dataset/road-accidents-safety-data).

## What's the point of it?

My journey to work can take anything from 25 minutes to 1.5 hrs. I wanted to know what the chances are of a long journey.

I've made it so you can easily get the information for your UK road journeys too.


## What data can I get?

Here are the sort of stats gained for a commute along the A3 (roughly Waterlooville to Hindhead).

- Commuting between 7-9 AM, there is a 4.74% chance of an accident!
- Commuting between 4-6 PM, there is a 3.16% chance of an accident.
- The most likely day for an accident is Thursay.
- The most likely day for an accident during commuter hours is Friday.

- Commuting between 7-9 AM in Autumn, there is a 7.69% chance of an accident!
- Commuting between 7-9 AM in Winter, there is a 6.45% chance of an accident (there are more accidents outside commuter hours in winter)!
- 20.37% of accidents are in adverse conditions.
- Most impacts are to the front of the car.

- The mean average age of the first driver involved is 44.6.
- 31.48% of accidents involve only 1 vehicle! (the code saves intermediate data, so we can see this is often avoiding something, then collliding with a central reservation (or something else))
- 92.59% of accidents involve a car.
- 9.26% of accidents involve a van.

- The months with the most accidents were January, February and June.


## Tech Info
- .NET Core (multi-platform)
- XUnit
- It uses full year 2015 data by default (but you can change it when new data comes out).


## How do I run it?

1. Clone the repository.
2. Open it in Visual Studio Community Edition (free). You may need to install [.NET Core](https://www.microsoft.com/net/core#windows) separately.
3. Hit Run.

Alternatively you can run in from the command line.


## How do I get my own stats?

### To get your journey details.
1. Go to google maps. 
2. Note the road numbers of your journey (in many cases, this should save you needing multiple boxes).
3. Imagine a square or rectangular box (or boxes) around the roads you want data for.
4. For each box, click on the map to get the South West coordinates and again to get the North East coordinates.

*single box example*
![alt tag](https://github.com/HockeyJustin/UkAccidentStatistics/blob/master/src/AccidentProcessor/Resources/Reference/_area_of_investigation_single_box.PNG?raw=true)

*multi box example (not actually needed for this example)*
![alt tag](https://github.com/HockeyJustin/UkAccidentStatistics/blob/master/src/AccidentProcessor/Resources/Reference/_area_of_investigation_multi_box.PNG)

### To run your journey details.
1. In Program.cs, remove my coordinates and add your coordinates to the ICoordinates array.
2. In Program.cs, remove my road numbers and add the relevant road numbers to the roadNumbers array.
3. Run the console.
4. Your statistics will be output to `UkAccidentStatistics\src\AccidentProcessor\Resources\Results`.


## Unit Tests

[XUnit](https://xunit.github.io/#documentation) was used to create around 50 unit tests, which can be run from the command line or `Visual Studio Test Runner`.

Obviously I should have written more tests, though I believe the data to be about right :)


## Notes

Results will be output to the `UkAccidentStatistics\src\AccidentProcessor\Resources\Results` folder and will overwrite old data.

Intermediate data will be output to files in `UkAccidentStatistics\src\AccidentProcessor\Resources\Intermediate` folder for visual analysis.

I have made some assumptions and generalisations (for example - I have only looked at the first two vehicles involved in the accidents and haven't excluded bank holidays from IsDateTimeInCommuterHours() checks to ensure checking other years will be consisten). The stats include both carriageways, though a crash on the opposite carriageway regularly causes a tailback on my side due to rubber-neckers.

There is a file with some 'Constants' that you can tweak if you are not happy with my assumptions.

If you like it, feel free to contact me here, or on [twitter](https://twitter.com/HockeyJustin).








