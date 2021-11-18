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

      return GetMorseCodeTranslation(input);
    }

    public static Dictionary<string, string> GetMorseCodeTable()
    {
      return new Dictionary<string, string>() {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" }
      };
    }

    private static string GetMorseCodeTranslation(string morseStringCode)
    {
      string fourSpaces = "    ";
      string singleSpace = " ";
      StringBuilder stringBuilder = new StringBuilder();

      var splitbyWords = morseStringCode.Split(fourSpaces);
      foreach(var word in splitbyWords)
      {
        var splitedByMorseLetters = word.Split(singleSpace);

        foreach (var morseCharacter in splitedByMorseLetters)
        {
          stringBuilder.Append(GetSingleCharacter(morseCharacter));
        }

        stringBuilder.Append(singleSpace);
      }

      return stringBuilder.ToString().Trim();
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
