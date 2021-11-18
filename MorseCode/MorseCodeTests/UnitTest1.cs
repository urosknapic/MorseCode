using MorseCode;
using NUnit.Framework;

namespace MorseCodeTests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WhenStringEmpty_ReturnEmptyString()
    {
      // Red - Green - Refactor
      // just enough code to pass the test

      // Arrange
      string input = "";

      // Act
      var output = MorseCodeDecoder.Decode(input);
      
      // Assert 
      Assert.AreEqual(output, "");
    }

    [Test]
    public void WhenStringEmptyWithSpaces_ReturnEmptyString(
      [Values(" ", "  ", "   ", "    ")] string input
      )
    {
      var output = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(output, "");
    }
  }
}