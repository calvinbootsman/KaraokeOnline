using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
            int outputLocation = startLocation;
            string remainingLyrics = lyrics.Substring(startLocation);
            remainingLyrics.TrimStart();

            bool foundFirstCharacter = true;

            for (int i = 0; i < remainingLyrics.Length; i++)
            {
                if (foundFirstCharacter == false)
                {
                    if (Regex.IsMatch(remainingLyrics[i].ToString(), @"^[a-zA-Z]+$"))
                    {
                        foundFirstCharacter = true;
                    }
                }
                if (foundFirstCharacter == true)
                {
                    /* what to do here?
                     * what should the function return?
                     * make this class stateless?
                     * maybe return the location
                     * 
                     * */

                    switch (remainingLyrics[i])
                    {
                        case ' ': continue; 
                        case '\n': continue;
                        case '\r': continue;
                        default:  /* found a character*/
                            return (startLocation + i);
                            break;
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
                        if ((indexLocation + i) == location)
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
                indexLocation += line.Length;
            }

            return markedUpLyrics;
        }
        /*        public MarkupString FormattedLyrics()
                {

                } */
    }

}
