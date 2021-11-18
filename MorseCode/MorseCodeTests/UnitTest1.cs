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

    [Test]
    public void Decoder_WhenContainsSingleMorseLetter_ReturnsSingleAlphabetLetter(
      [Values(".-", "-...", "-.-.")] string input)
    {
      // Is this proper test?
      // Since I dont want to duplicate code for morse code table. If anyone can comment; please do
      var tableMorseValue = "";
      var morseTable = MorseCodeDecoder.GetMorseCodeTable();
      if (morseTable.ContainsKey(input))
      {
        tableMorseValue = morseTable[input];
      }

      var outputValue = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(outputValue, tableMorseValue);
    }

    [Test]
    public void Decoder_WhenTwoMorseLetterAA_ReturnStringAA()
    {
      var input = ".- .-";

      var outputValue = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(outputValue, "AA");
    }

    [Test]
    public void Decoder_WhenTwoMorseLetterBB_ReturnStringBB()
    {
      var input = "-... -...";

      var outputValue = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(outputValue, "BB");
    }

    [Test]
    public void Decoder_WhenTwoMorseLetterCC_ReturnStringCC()
    {
      var input = "-.-. -.-.";

      var outputValue = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(outputValue, "CC");
    }

    [Test]
    public void Decoder_WhenTwoMorseLetterAC_ReturnStringAC()
    {
      var input = ".- -.-.";

      var outputValue = MorseCodeDecoder.Decode(input);

      Assert.AreEqual(outputValue, "AC");
    }

    // testing single dot?
    // testing single dash?
  }
}