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

    private static string GetMorseCodeTranslation(string morseStringCode)
    {
      string fourSpaces = "    ";
      string singleSpace = " ";
      StringBuilder stringBuilder = new StringBuilder();

      var splitbyWords = morseStringCode.Split(fourSpaces);
      foreach (var word in splitbyWords)
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

    public static Dictionary<string, string> MorseCodeToAlphabetTable()
    {
      string dot = ".";
      string dash = "-";
      // International morse code
      return new Dictionary<string, string>() {
        { string.Concat(dot, dash), "A" },
        { string.Concat(dash, dot, dot, dot), "B" },
        { string.Concat(dash, dot, dash, dot), "C" },

        { string.Concat(dash, dot, dot), "D" },
        { dot, "E" },
        { string.Concat(dot, dot, dash, dot), "F" },
        { string.Concat(dash, dash, dot), "G" },
        { string.Concat(dot, dot, dot, dot), "H" },
        { string.Concat(dot, dot), "I" },
        { string.Concat(dot, dash, dash, dash), "J" },
        { string.Concat(dash, dot, dash), "K" },
        { string.Concat(dot, dash, dot, dot), "L" },
        { string.Concat(dash, dash), "M" },
        { string.Concat(dash, dot), "N" },
        { string.Concat(dash, dash, dash), "O" },
        { string.Concat(dot, dash, dash, dot), "P" },
        { string.Concat(dash, dash, dot, dash), "Q" },
        { string.Concat(dot, dash, dot), "R" },
        { string.Concat(dot, dot, dot), "S" },
        { dash, "T" },
        { string.Concat(dot, dot, dash), "U" },
        { string.Concat(dot, dot, dot, dash), "V" },
        { string.Concat(dot, dash, dash), "W" },
        { string.Concat(dash, dot, dot, dash), "X" },
        { string.Concat(dash, dot, dash, dash), "Y" },
        { string.Concat(dash, dash, dot, dot), "Z" },
        { string.Concat(dash,dash,dash,dash,dash), "0" },
        { string.Concat(dot, dash,dash,dash,dash), "1" },
        { string.Concat(dot, dot, dash,dash,dash), "2" },
        { string.Concat(dot, dot, dot,dash,dash), "3" },
        { string.Concat(dot, dot, dot,dot,dash), "4" },
        { string.Concat(dot, dot, dot,dot,dot), "5" },
        { string.Concat(dash, dot, dot,dot,dot), "6" },
        { string.Concat(dash, dash, dot,dot,dot), "7" },
        { string.Concat(dash, dash, dash,dot,dot), "8" },
        { string.Concat(dash, dash, dash,dash,dot), "9" }
      };
    }

    private static string GetSingleCharacter(string morseCharacter)
    {
      var morseTable = MorseCodeToAlphabetTable();

      if (morseTable.ContainsKey(morseCharacter))
      {
        return morseTable[morseCharacter];
      }

      return string.Empty;
    }
  }
}
