using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace KaraokeOnline.Controller
{
    public class LyricsSyncController
    {
        private List<string> pressedKeys = new List<string>();
        private string lyrics = "";
        private int startTime = 0;
        private int lyricsLocation = 0;
        private List<MarkupString> lyricsMarkup = new List<MarkupString>();
        public void AddLyrics(string input)
        {
            lyrics = input;
        }

        public int? OnKeyAction(KeyboardEventArgs e, int currentTime, int currentLocation)
        {
            if (e.Type == "keydown")
            {
                // Shift key can only set the start time when there are not other keys pressed.
                // Control has to be pressed first, before the space bar has been pressed.
                // Space can only trigger when it's the only key pressed, or the control key has been pressed.
                // We register all the key down/ups
                // Add/remove the from a list of strings
                // Then we see what the list holds to see what to do.
                if (pressedKeys.Contains(e.Key) is true) return null;

                pressedKeys.Add(e.Key);

                if (pressedKeys.Count() == 1)
                {
                    if (e.Key == "Shift")
                    {
                        return null;
                    }
                }

                if (e.Key != " ") return null;
                string Combination = "";
                foreach (string key in pressedKeys)
                {
                    Combination += key;
                }

                switch (Combination)
                {
                    case "Shift ": // start time of encoded lyric
                        break;
                    case " ": // move a word forward
                        return GetNextWordPosition(currentLocation);
                        break;
                    case "Control ": // move a single character forward
                        int? test = GetNextAlphabetCharacterPosition(currentLocation);
                        if (test == null) return null;
                        return test;
                        break;
                    default: break;
                }

                return null;
            }
            else
            {
                if (pressedKeys.Contains(e.Key) is true)
                {
                    pressedKeys.Remove(e.Key);
                }
                return null;
            }
        }

        private int? GetNextAlphabetCharacterPosition(int startLocation)
        {
            string remainingLyrics = lyrics.Substring(startLocation);
            remainingLyrics.TrimStart();

            for (int i = 0; i < remainingLyrics.Length; i++)
            {
                if (Char.IsLetter(remainingLyrics[i]))
                {
                    return (startLocation + i + 1);
                }
            }

            return null;
        }

        private int? GetNextWordPosition(int startLocation)
        {            
            int? output = null;
            bool foundWhiteSpace = false;

            // First go the first next chararcter position
            // Because that's whehre the next word starts.
            // This makes you skip the additional whitespace characters, like \r \n
            int? newStartLocation = GetNextAlphabetCharacterPosition(startLocation);
            if (newStartLocation is null) return null;

            string remainingLyrics = lyrics.Substring((int)newStartLocation);
            remainingLyrics.TrimStart();

            for (int i = 0; i < remainingLyrics.Length; i++)
            {
                if (Char.IsWhiteSpace(remainingLyrics[i]))
                {
                    if (foundWhiteSpace)
                    {
                        // We found a witespace already
                        // And now we found another white space
                        // For example at \r \n
                        // We can skip until we found the next alphabetic character
                        // Except we get the next alphabetic character position + 1
                        // So we subtract 1
                        output = GetNextAlphabetCharacterPosition((int)newStartLocation + i) - 1;
                    }
                    else
                    {
                        // We found the end of the word
                        // But we want to skip the next comning whitespaces as well.
                        // That's why we don't return yet.
                        foundWhiteSpace = true;
                        output = ((int)newStartLocation + i + 1);
                    }                    
                }
                else
                {
                    if (foundWhiteSpace == true)
                    {
                        return output;
                    }
                }
            }

            return null;
        }
        public MarkupString MoveToNextCharacter(MarkupString currentText)
        {
            return new MarkupString("");
        }

        public List<MarkupString> MarkupTheLyrics(string lyrics, int location)
        {
            List<MarkupString> markedUpLyrics = new List<MarkupString>();
            List<string> linesLyrics = lyrics.Split("\n").ToList();
            int indexLocation = 0;
            foreach (string line in linesLyrics)
            {
                string s = "";
                if ((line.Length + indexLocation) < location)
                {
                    // we may encapsulate the whole line in a red color!
                    s += "<span style=\"color:red;\">";
                    s += line;
                    s += "</span>";
                }
                else if (indexLocation < location)
                {
                    // we can partially color the line
                    s += "<span style=\"color:red;\">";
                    int length = line.Length;
                    for (int i = 0; i < length; i++)
                    {
                        s += line[i];
                        if ((indexLocation + i + 1) == location)
                        {
                            s += "</span>";
                        }
                    }
                }
                else
                {
                    // we dont have to color the line.
                    s = line;
                }
                markedUpLyrics.Add(new MarkupString(s));

                // We add 1 to include the removed \n
                indexLocation += line.Length + 1;
            }

            return markedUpLyrics;
        }
        /*        public MarkupString FormattedLyrics()
                {

                } */
    }

}
