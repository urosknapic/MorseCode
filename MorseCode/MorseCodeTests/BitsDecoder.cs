using MorseCode;
using NUnit.Framework;
using System;

namespace MorseCodeTests
{
  public class BitsDecoder
  {
    
    [Test]
    public void WhenBitsInputIsEmpty_ReturnEmpty()
    {
      string input = string.Empty;

      var output = MorseCodeDecoder.BitsDecoder(input);

      Assert.AreEqual(output, string.Empty);
    }

    [Test]
    public void WhenInvalidBitsInput_ThrowInvalidArgumentException()
    {
      string input = "123";

      Assert.Throws<ArgumentException>(() => MorseCodeDecoder.BitsDecoder(input));
    }

    [Test]
    public void WhenValidBitsInput_Two1BitsForDot_ReturnDotString()
    {
      string input = "11";

      var output = MorseCodeDecoder.BitsDecoder(input);

      Assert.AreEqual(output, ".");
    }

    [Test]
    public void WhenValidBitsInput_Six1BitsForDash_ReturnDashString()
    {
      string input = "111111";

      var output = MorseCodeDecoder.BitsDecoder(input);

      Assert.AreEqual(output, "-");
    }

    [Test]
    public void When_Two0BitsForNoSpaceBetweenDotOrDash_ReturnEmptyString()
    {
      string input = "00";

      var output = MorseCodeDecoder.BitsDecoder(input);

      Assert.AreEqual(output, "");
    }

    [Test]
    public void When_BitsFor4Dots_Return4Dots()
    {
      string input = "11001100110011";

      var output = MorseCodeDecoder.BitsDecoder(input);

      Assert.AreEqual(output, "....");
    }
  }
}
