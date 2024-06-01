using KaraokeOnline.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging.Abstractions;
using System.ComponentModel;
using System.Diagnostics;
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

        private LyricsSyncModel syncModel = new LyricsSyncModel("[{\"StartTime\":0,\"EndTime\":0.02322,\"Characters\":\"I\\u0027m \"},{\"StartTime\":0.02322,\"EndTime\":0.167337,\"Characters\":\"hurting, \"},{\"StartTime\":0.167337,\"EndTime\":0.333321,\"Characters\":\"baby, \"},{\"StartTime\":0.333321,\"EndTime\":0.504802,\"Characters\":\"I\\u0027m \"},{\"StartTime\":0.504802,\"EndTime\":0.697218,\"Characters\":\"broken \"},{\"StartTime\":0.697218,\"EndTime\":0.882519,\"Characters\":\"down\\r\\n\"},{\"StartTime\":0.882519,\"EndTime\":1.242423,\"Characters\":\"I \"},{\"StartTime\":1.242423,\"EndTime\":1.525475,\"Characters\":\"need \"},{\"StartTime\":1.525475,\"EndTime\":1.693108,\"Characters\":\"your \"},{\"StartTime\":1.693108,\"EndTime\":2.488091,\"Characters\":\"loving, \"},{\"StartTime\":2.488091,\"EndTime\":2.857064,\"Characters\":\"loving\\r\\n\"},{\"StartTime\":2.857064,\"EndTime\":3.352362,\"Characters\":\"I \"},{\"StartTime\":3.352362,\"EndTime\":3.803773,\"Characters\":\"need \"},{\"StartTime\":3.803773,\"EndTime\":4.015081,\"Characters\":\"it \"},{\"StartTime\":4.015081,\"EndTime\":4.194483,\"Characters\":\"now\\r\\n\"},{\"StartTime\":4.194483,\"EndTime\":4.392535,\"Characters\":\"When \"},{\"StartTime\":4.392535,\"EndTime\":4.595682,\"Characters\":\"I\\u0027m \"},{\"StartTime\":4.595682,\"EndTime\":4.819489,\"Characters\":\"without \"},{\"StartTime\":4.819489,\"EndTime\":5.008402,\"Characters\":\"you\\r\\n\"},{\"StartTime\":5.008402,\"EndTime\":5.453322,\"Characters\":\"I\\u0027m \"},{\"StartTime\":5.453322,\"EndTime\":5.640479,\"Characters\":\"something \"},{\"StartTime\":5.640479,\"EndTime\":5.871666,\"Characters\":\"weak\\r\\n\"},{\"StartTime\":5.871666,\"EndTime\":6.052179,\"Characters\":\"You \"},{\"StartTime\":6.052179,\"EndTime\":6.255516,\"Characters\":\"got \"},{\"StartTime\":6.255516,\"EndTime\":6.463116,\"Characters\":\"me \"},{\"StartTime\":6.463116,\"EndTime\":6.671137,\"Characters\":\"begging, \"},{\"StartTime\":6.671137,\"EndTime\":6.881581,\"Characters\":\"begging\\r\\n\"},{\"StartTime\":6.881581,\"EndTime\":7.092183,\"Characters\":\"I\\u0027m \"},{\"StartTime\":7.092183,\"EndTime\":7.317681,\"Characters\":\"on \"},{\"StartTime\":7.317681,\"EndTime\":7.476717,\"Characters\":\"my \"},{\"StartTime\":7.476717,\"EndTime\":7.673499,\"Characters\":\"knees\\r\\n\\r\\n\"},{\"StartTime\":7.673499,\"EndTime\":8.084736,\"Characters\":\"I \"},{\"StartTime\":8.084736,\"EndTime\":8.284902,\"Characters\":\"don\\u0027t \"},{\"StartTime\":8.284902,\"EndTime\":8.491297,\"Characters\":\"wanna \"},{\"StartTime\":8.491297,\"EndTime\":8.685828,\"Characters\":\"be \"},{\"StartTime\":8.685828,\"EndTime\":8.915855,\"Characters\":\"needing \"},{\"StartTime\":8.915855,\"EndTime\":9.102569,\"Characters\":\"your \"},{\"StartTime\":9.102569,\"EndTime\":9.328107,\"Characters\":\"love\\r\\n\"},{\"StartTime\":9.328107,\"EndTime\":9.52661,\"Characters\":\"I \"},{\"StartTime\":9.52661,\"EndTime\":9.742016,\"Characters\":\"just \"},{\"StartTime\":9.742016,\"EndTime\":9.949139,\"Characters\":\"wanna \"},{\"StartTime\":9.949139,\"EndTime\":10.162128,\"Characters\":\"be \"},{\"StartTime\":10.162128,\"EndTime\":10.37024,\"Characters\":\"deep \"},{\"StartTime\":10.37024,\"EndTime\":10.57989,\"Characters\":\"in \"},{\"StartTime\":10.57989,\"EndTime\":10.892449,\"Characters\":\"your \"},{\"StartTime\":10.892449,\"EndTime\":11.166543,\"Characters\":\"love\\r\\n\"},{\"StartTime\":11.166543,\"EndTime\":11.474055,\"Characters\":\"And \"},{\"StartTime\":11.474055,\"EndTime\":11.746206,\"Characters\":\"it\\u0027s \"},{\"StartTime\":11.746206,\"EndTime\":11.971848,\"Characters\":\"killing \"},{\"StartTime\":11.971848,\"EndTime\":12.18108,\"Characters\":\"me \"},{\"StartTime\":12.18108,\"EndTime\":12.396998,\"Characters\":\"when \"},{\"StartTime\":12.396998,\"EndTime\":12.605179,\"Characters\":\"you\\u0027re \"},{\"StartTime\":12.605179,\"EndTime\":12.819227,\"Characters\":\"away, \"},{\"StartTime\":12.819227,\"EndTime\":13.01319,\"Characters\":\"ooh, \"},{\"StartTime\":13.01319,\"EndTime\":13.36781,\"Characters\":\"baby\\r\\n\\u0027\"},{\"StartTime\":13.36781,\"EndTime\":13.743467,\"Characters\":\"Cause \"},{\"StartTime\":13.743467,\"EndTime\":14.070767,\"Characters\":\"I \"},{\"StartTime\":14.070767,\"EndTime\":14.507253,\"Characters\":\"really \"},{\"StartTime\":14.507253,\"EndTime\":14.807864,\"Characters\":\"don\\u0027t \"},{\"StartTime\":14.807864,\"EndTime\":15.193503,\"Characters\":\"care \"}]");
        private int counter = 0;
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
                    counter++;

                    if (counter == 60)
                    {
                        var test = System.Text.Json.JsonSerializer.Serialize(syncModel.GetEncodedLyrics());
                         Debug.WriteLine(test);
                    }
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
