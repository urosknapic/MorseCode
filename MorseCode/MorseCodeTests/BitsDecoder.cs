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
  }
}
