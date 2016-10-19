using AccidentProcessor.Classes;
using Xunit;

namespace AccidentProcessor.Tests.ClassesTests
{
  public class SwNeSquareCoordinatesTests
  {
    [Fact]
    public void SwNeSquareCoordinates_WithCoordsInBoxAndCorrectRoad_ExpectTrue()
    {
      //Arrange
      AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads sw = new AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads(50.876343, -1.0169207, 51.11028, -0.7232787, new string[] { "A3" });

      //Act - These are the coords for Petersfield McDonalds, which are in bounds :)
      bool isInBounds = sw.IsLocationAndRoadARoadAndCoordinatesMatch(51.008803, -0.955021, (RoadClass)3, 3);

      //Assert
      Assert.Equal(true, isInBounds);
    }


		[Fact]
		public void SwNeSquareCoordinates_WithCoordsInBoxAndWrongRoad_ExpectFalse()
		{
			//Arrange
			AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads sw = new AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads(50.876343, -1.0169207, 51.11028, -0.7232787, new string[] { "A3" });

			//Act - These are the coords for Petersfield McDonalds, which are in bounds, but on on the A3(M)
			bool isInBounds = sw.IsLocationAndRoadARoadAndCoordinatesMatch(51.008803, -0.955021, (RoadClass)2, 3);

			//Assert
			Assert.Equal(false, isInBounds);
		}


		[Fact]
    public void SwNeSquareCoordinates_WithCoordsOutsideBoxAndCorrectRoad_ExpectFalse()
    {
      //Arrange
      AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads sw = new AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads(50.876343, -1.0169207, 51.11028, -0.7232787, new string[] { "A3" });

      //Act - These are the coords for Havant McDonalds, which should be out of bounds :)
      bool isInBounds = sw.IsLocationAndRoadARoadAndCoordinatesMatch(50.864016, -1.013415, (RoadClass)3, 3);

      //Assert
      Assert.Equal(false, isInBounds);
    }


		[Fact]
		public void SwNeSquareCoordinates_WithCoordsOutsideBoxAndWrongRoad_ExpectFalse()
		{
			//Arrange
			AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads sw = new AccidentProcessor.Classes.SwNeSquareCoordinatesAndRoads(50.876343, -1.0169207, 51.11028, -0.7232787, new string[] { "A3" });

			//Act - These are the coords for Havant McDonalds, which should be out of bounds :)
			bool isInBounds = sw.IsLocationAndRoadARoadAndCoordinatesMatch(50.864016, -1.013415, (RoadClass)2, 3);

			//Assert
			Assert.Equal(false, isInBounds);
		}
	}
}
