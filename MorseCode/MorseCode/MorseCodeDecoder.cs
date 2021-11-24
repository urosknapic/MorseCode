using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MorseCode
{
  public static class MorseCodeDecoder
  {
    public static string Decode(string input)
    {
      if (string.IsNullOrEmpty(input.Trim()))
      {
        return string.Empty;
      }

      if (!IsValidMorseCode(input))
      {
        throw new ArgumentException("Input is not a morse code!");
      }

      return GetMorseCodeTranslation(input);
    }

    public static string BitsDecoder(string bitsInput)
    {
      /*
       decode this:
      1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011

      should be decoded to

      ···· · −·−−   ·−−− ··− −·· ·

      which means 
      
      HEY JUDE
       */
      if (string.IsNullOrEmpty(bitsInput))
      {
        return string.Empty;
      }
      
      if (!IsValidBitsString(bitsInput))
      {
        throw new ArgumentException("Invalid input! String input contains other values than just bit(s) values! Input should contain only 0s and 1s!", bitsInput);
      }

      if (bitsInput.Equals("11"))
      {
        return ".";
      }

      if (bitsInput.Equals("00"))
      {
        return "";
      }
      return "-";
    }

    private static bool IsValidBitsString(string bitsInput)
    {
      Regex rx = new Regex("^[0,1]+$");
      return rx.IsMatch(bitsInput);
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

    private static bool IsValidMorseCode(string morseCode)
    {
      Regex r = new Regex("^[-. ]+$");
      return r.IsMatch(morseCode);
    }

    private static string GetMorseCodeTranslation(string morseCode)
    {
      return string.Join(" ", GetSplitByWords(morseCode).Select(word => GetMorseWordTranslation(word))).ToString().Trim();
    }

    private static string GetMorseWordTranslation(string morseWordCode)
    {
      return string.Join("", SplitByCharacters(morseWordCode).Select(w => GetSingleCharacter(w)));
    }

    private static string[] SplitByCharacters(string morseStringWord)
    {
      // 1 space in morse separate character
      return morseStringWord.Split(" ");
    }

    private static string[] GetSplitByWords(string morseStringCode)
    {
      // 3 spaces in morse separate words
      return morseStringCode.Split("   ");
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
