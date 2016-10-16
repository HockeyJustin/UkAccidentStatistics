using Xunit;

namespace AccidentProcessor.Tests.ClassesTests
{
  public class SwNeSquareCoordinatesTests
  {
    [Fact]
    public void SwNeSquareCoordinates_WithCoordsInBox_ExpectTrue()
    {
      //Arrange
      AccidentProcessor.Classes.SwNeSquareCoordinates sw = new AccidentProcessor.Classes.SwNeSquareCoordinates(50.876343, -1.0169207, 51.11028, -0.7232787);

      //Act - These are the coords for Petersfield McDonalds, which are in bounds :)
      bool isInBounds = sw.IsLocationWithinCoordinates(51.008803, -0.955021);

      //Assert
      Assert.Equal(true, isInBounds);
    }



    [Fact]
    public void SwNeSquareCoordinates_WithCoordsOutsideBox_ExpectFalse()
    {
      //Arrange
      AccidentProcessor.Classes.SwNeSquareCoordinates sw = new AccidentProcessor.Classes.SwNeSquareCoordinates(50.876343, -1.0169207, 51.11028, -0.7232787);

      //Act - These are the coords for Havant McDonalds, which should be out of bounds :)
      bool isInBounds = sw.IsLocationWithinCoordinates(50.864016, -1.013415);

      //Assert
      Assert.Equal(false, isInBounds);
    }
  }
}
