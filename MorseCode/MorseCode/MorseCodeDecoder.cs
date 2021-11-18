using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MorseCode
{
  public static class MorseCodeDecoder
  {
    public static string Decode(string input)
    {
      if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(input.Trim()))
      {
        return string.Empty;
      }

      Regex r = new Regex("^[-. ]+$");
      var validMorseCode = r.IsMatch(input);

      if (!validMorseCode)
      {
        throw new ArgumentException("Input is not a morse code!");
      }

      return GetMorseCode(input);
    }

    public static Dictionary<string, string> GetMorseCodeTable()
    {
      return new Dictionary<string, string>() {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" }
      };
    }

    private static string GetMorseCode(string character)
    {
      var morseTable = GetMorseCodeTable();

      if (morseTable.ContainsKey(character))
      {
        return morseTable[character];
      }

      return string.Empty;
    }
  }
}
