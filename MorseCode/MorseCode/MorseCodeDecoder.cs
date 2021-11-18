using System;
using System.Text.RegularExpressions;

namespace MorseCode
{
  public static class MorseCodeDecoder
  {
    public static string Decode(string input)
    {
      if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim()))
      {
        return "";
      }

      Regex r = new Regex("^[-. ]+$");
      var validMorseCode = r.IsMatch(input);

      if (!validMorseCode)
      {
        throw new ArgumentException("Input is not a morse code!");
      }

      return "";
    }
  }
}
