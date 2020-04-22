# UK Road Accident Statistics Generator

## UK Road Accident Statistics From the [Governments Open Source Accident Data](https://data.gov.uk/dataset/road-accidents-safety-data).

## What's the point of it?

Does it feel like you're often held up by an accident? I wanted to know what the chances are of a long journey.

I've made it so you can get the information for your UK road journeys too.


## What data can I get?

The official data lags a bit - for example, 2018 data was added Sept 2019, so the current dataset is 2018. We use the 'Road Safety Data - Vehicles YYYY' and 'Road Safety Data - Accidents YYYY', renaming the files and putting them in the 'Resources' folder.

Here are the sort of stats gained for my commute along the A3 (using the original 2015 dataset):

- Commuting between 7-9 AM, there is a 4.74% chance of an accident.
- Commuting between 4-6 PM, there is a 3.16% chance of an accident.
- The most likely day for an accident is Thursay.
- The most likely day for an accident during commuter hours is Friday.

- Commuting between 7-9 AM in Autumn, there is a 7.69% chance of an accident.
- Commuting between 7-9 AM in Winter, there is a 6.45% chance of an accident (winter has more accidents, but most of those are outside commuter hours.)
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
- It uses full year 2018 data by default (but you can change it when new data comes out).


## How do I run it?

1. Clone the repository.
2. Open it in Visual Studio Community Edition (free). You may need to install [.NET Core](https://www.microsoft.com/net/core#windows) separately.
3. Hit Run.

Alternatively you can run it from the command line.


## How do I get my own stats?

### Worked example (South Newbury to Maidenhead).
1. Go to google maps. 
2. Note the road number(s) of your journey (in many cases, this should save you needing multiple boxes). E.g. For this commute, we travel on the A339, A34, M4 and the A308(M). 
3. Imagine a square or rectangular box (you can have multiple boxes) that includes all parts of the roads you want data for (see image below).
4. For each box, click on the map in the South West point to get the first coordinates (latitude,longitude) and do the same for the North East coordinates (see image below).
Usually you will only need one box, but you can have more than one.

*Example*
![alt tag](https://github.com/HockeyJustin/UkAccidentStatistics/blob/master/src/AccidentProcessor/Resources/Reference/_area_Newbury_To_Maidenhead_A339_A34_M4_A308M.png?raw=true)

### To run your journey details.
1. In Program.cs, remove my coordinates.
2. Add your box(es) coordinates to the IRoadsAndCoordinates array and add your road numbers without spaces as a string array. e.g. "A339", "A34", "M4" and the "A308(M)". Make sure this variable is used in the `arrayOfAreas`.
3. Run the console.
4. Your statistics will be output to `UkAccidentStatistics\src\AccidentProcessor\Resources\Results`.

The code affected will look like:

`IRoadsAndCoordinates newburyToMaidenhead = new SwNeSquareCoordinatesAndRoads(51.3995, -1.331433, 51.506467, -0.712058, new string[] { "A339", "A34", "M4", "A308(M)" });`

`IRoadsAndCoordinates[] arrayOfAreas = new IRoadsAndCoordinates[] { newburyToMaidenhead };`

`analysisRunner.RunAnalysis(true, arrayOfAreas);`

## Unit Tests

[XUnit](https://xunit.github.io/#documentation) was used to create around 50 unit tests, which can be run from the command line or `Visual Studio Test Runner`.

Obviously I should have written more tests, though I believe the data to be about right :)


## Notes

Results will be output to the `UkAccidentStatistics\src\AccidentProcessor\Resources\Results` folder and will overwrite old data.

Intermediate data will be output to files in `UkAccidentStatistics\src\AccidentProcessor\Resources\Intermediate` folder for visual analysis.

I have made some assumptions and generalisations. For example:
- I have only looked at the first two vehicles involved in the accidents assuming these to be the initial cause.
- I haven't excluded bank holidays from IsDateTimeInCommuterHours() checks to ensure checking other years will be consistent (no accidental bug generation). 
- The stats include both carriageways. Couldn't find a heading, though a crash on the opposite carriageway regularly causes a tailback on my side due to rubber-neckers, so would still lead to a slightly longer commute.
- Have taken 'Commuter Hours' to be 6-9AM and 4-7PM.

There is a file with some 'Constants' that you can tweak if you are not happy with my assumptions.

If you like it, feel free to contact me here, or on [twitter](https://twitter.com/JsAndDotNet).








