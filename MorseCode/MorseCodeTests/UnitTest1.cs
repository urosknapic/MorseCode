using MorseCode;
using NUnit.Framework;
using System;

namespace MorseCodeTests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Decoder_WhenEmpty_ReturnEmpty()
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
    public void Decoder_WhenEmptyWithSpaces_ReturnEmpty([Values(" ", "  ", "   ", "    ")] string input)
    {
      var output = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(output, "");
    }

    [Test]
    public void Decoder_WhenContainsOtherCharacter_ThrowException()
    {
      var input = "asdsad -.-. asdas";

      Assert.Throws(typeof(ArgumentException), () => MorseCodeDecoder.Decode(input));
    }

    //[Test]
    //public void Decoder_WhenStringContainsMorseCode_()
    //{
    //  var input = "asdsad -.-. asdas";

    //  Assert.Throws<Exception>(() => MorseCodeDecoder.Decode(input));
    //}
  }
}