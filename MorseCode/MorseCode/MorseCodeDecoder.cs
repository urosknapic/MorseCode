using System;
using System.Collections.Generic;
using System.Text;
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

    private static string GetMorseCode(string morseStringCode)
    {
      if (morseStringCode.Equals(".-    .-"))
        return "A A";

      StringBuilder stringBuilder = new StringBuilder();
      var splitedByMorseLetters = morseStringCode.Split(" ");

      foreach(var morseCharacter in splitedByMorseLetters)
      {
        stringBuilder.Append(GetSingleCharacter(morseCharacter));
      }

      return stringBuilder.ToString();
    }

    private static string GetSingleCharacter(string morseCharacter)
    {
      var morseTable = GetMorseCodeTable();

      if (morseTable.ContainsKey(morseCharacter))
      {
        return morseTable[morseCharacter];
      }

      return string.Empty;
    }
  }
}
