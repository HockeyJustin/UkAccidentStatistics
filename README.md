# Uk Accident Statistics

## UK Accident Statistics From Open Source Data at https://data.gov.uk/dataset/road-accidents-safety-data

## What is it?

Using .NET Core, it take the 2015 UK Road Accident statistics and enables you to learn about the accidents on roads of interest to you.

I created it, as my journey to work can take anything from 25 minutes to 1.5 hrs and I wanted to know why.

Though the stats include both carriageways, a crash on the opposite carriageways regularly causes a tailback on my side due to rubber-neckers:

Here are the sort of stats gained for a commute along the A3 (roughly Waterlooville to Hindhead).

- Between 7-9 AM, there is a 4.74% chance of an accident!
- Between 4-6 PM, there is a 3.16% chance of an accident.
- The most likely day for an accident is Thursay.
- The most likely day for an accident during commuter hours is Friday.
- Between 7-9 AM in Autumn, there is a 7.69% chance of an accident!
- Between 7-9 AM in Winter, there is a 6.45% chance of an accident (there are more accidents outside commuter hours in winter)!
- 20.37% of accidents are in adverse conditions.
- Most impacts are to the front of the car.
- The average age of the first driver involved is 44.6.
- 31.48% of accidents involve only 1 vehicle! (the code saves intermediate data, so we can see this is often avoiding something, then collliding with a central reservation (or something) and/or overturning)
- 92.59% of accidents involve a car.
- 9.26% of accidents involve a van.
- The months with the most accidents were January, February and June.


## How do I run it.

1. Clone the repository.
2. Open it in Visual Studio Community Edition (free). (You may need to install .NET Core separately)
3. Hit Run.


## How do I get my own stats?

1. Note the road numbers of your journey (in many cases, this should save you needing multiple boxes).
2. Go to google maps. 
3. Imagine a square or rectangular box (or boxes) around the roads you want data for.
4. For each box, click on the map to get the South West coordinates and again to get the North East coordinates.

* single box example *
![alt tag](https://github.com/HockeyJustin/UkAccidentStatistics/blob/master/src/AccidentProcessor/Resources/Reference/_area_of_investigation_single_box.PNG?raw=true)

* multi box example (not actually needed for this example)*
![alt tag](https://github.com/HockeyJustin/UkAccidentStatistics/blob/master/src/AccidentProcessor/Resources/Reference/_area_of_investigation_multi_box.PNG)

5. Remove my coordinates and add your coordinates to the ICoordinates array
6. Remove my road numbers and add the relevant road numbers to the roadNumbers array.
7. Run the console.

8. Read the output stats.

Results will be output to the 'Results' folder and will overwrite old data.

Intermediate data will be output to files in the 'Intermediate' folder for visual analysis.

I have made some assumptions (for example - I have only looked at the first two vehicles involved in the accidents and haven't checked bank holidays.)

There is a file with some Constants that you can tweak if you are not happy with my assumptions.

Happy Statting :)







