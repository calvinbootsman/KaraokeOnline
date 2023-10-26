using KaraokeOnline.Models;
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

        private LyricsSyncModel syncModel = new LyricsSyncModel();
        public int? OnKeyAction(KeyboardEventArgs e, double currentTime, int currentLocation)
        {
            if (e.Type == "keydown")
            {
                // Shift key can only set the start time when there are not other keys pressed. 
                // Control has to be pressed first, before the space bar has been pressed. (DONE)
                // Space can only trigger when it's the only key pressed, or the control key has been pressed. (DONE)
                // We register all the key down/ups (DONE)
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

                int? newLocation = currentLocation;
                bool newLocationCheck = true;
                switch (Combination)
                {
                    case "Shift ":  // set the lastEndTime to current time
                                    // this can be used in case there's a long pause in the audio.
                                    // might have to be replaced with something else. 
                        newLocationCheck = false;
                        break;
                    case " ": // move a word forward
                        newLocation = GetNextWordPosition(currentLocation);
                        break;
                    case "Control ": // move a single character forward
                        newLocation = GetNextAlphabetCharacterPosition(currentLocation);
                        break;
                    default: break;
                }
                // error checking
                if (newLocation == null) return null;
                if (newLocationCheck == true){
                    if (newLocation <= currentLocation) return null;
                }

                string substring = "";
                if (newLocationCheck == true)
                {
                    substring = lyrics.Substring(currentLocation, (int)(newLocation - currentLocation));
                }
                
                double lastEndTime = 0;

                if (syncModel.GetEncodedLyrics().Count() != 0)
                {
                    lastEndTime = syncModel.GetEncodedLyrics().Last().EndTime;
                }

                // TODO: maybe only check if any of them are 0, otherwise currentTime has to be larger than lastEndTime?
                if (currentTime >= lastEndTime)
                {
                    LyricsEncoding encoding = new LyricsEncoding(lastEndTime, currentTime, substring);
                    syncModel.AddEncodedLyrics(encoding);
                    return newLocation;
                }
            }
            else
            {
                if (pressedKeys.Contains(e.Key) is true)
                {
                    pressedKeys.Remove(e.Key);
                }                
            }

            return null;
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
                    s += "<span style=\"background:red; -webkit-background-clip: text;\">";
                    s += line;
                    s += "</span>";
                }
                else if (indexLocation < location)
                {
                    // we can partially color the line
                    s += "<span style=\"background:red; -webkit-background-clip: text;\">";
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
                if (line != "\r")
                {
                    markedUpLyrics.Add(new MarkupString(s));

                }

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
