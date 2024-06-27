using KaraokeOnline.Utils;

namespace KaraokeOnline.Models
{
    public class LyricsSyncModel
    {
        public LyricsSyncModel() { }
        public LyricsSyncModel(string data)
        {
            List<LyricsEncoding>? lyricsData = System.Text.Json.JsonSerializer.Deserialize<List<LyricsEncoding>>(data);
            if (lyricsData is null) return;

            foreach (LyricsEncoding lyrics in lyricsData)
            {
                lyricsEncodingList.Add(lyrics);
                encodedLength += lyrics.Characters.Length;
            }
        }
        public List<LyricsEncoding> GetEncodedLyrics() { return lyricsEncodingList; }

        private int encodedLength = 0;
        public void AddEncodedLyrics(int startTime, int endTime, string characters)
        {
            lyricsEncodingList.Add(new LyricsEncoding(startTime, endTime, characters));
            encodedLength += characters.Length;
        }
        public void AddEncodedLyrics(LyricsEncoding encodedLyrics)
        {
            lyricsEncodingList.Add((LyricsEncoding) encodedLyrics);
            encodedLength += encodedLyrics.Characters.Length;
        }
        public int GetEncodedLength() { return encodedLength; }

        private List<LyricsEncoding> lyricsEncodingList = new List<LyricsEncoding>();

        public List<byte[]> GenerateCDG()
        {
            CDGExtended CDGCommands = new CDGExtended();
            List<byte[]> cdg = new List<byte[]>();
            //Clear screen.
            cdg.Add(CDGCommands.GetFileBytes(100));
            return cdg;
            /*
            cdg.Add(CDGCommands.LoadColorTableLow(new ushort[] { 0x30, 0, 0, 0, 0, 0, 0, 0 }));
            cdg.Add(CDGCommands.LoadColorTableHigh(new ushort[] { 0, 0, 0, 0, 0, 0, 0, 0 }));
            cdg.Add(CDGCommands.MemoryPreset(0, 0));
            cdg.Add(CDGCommands.MemoryPreset(0, 1));
            cdg.Add(CDGCommands.MemoryPreset(0, 2));
            cdg.Add(CDGCommands.MemoryPreset(0, 3));
            cdg.Add(CDGCommands.MemoryPreset(0, 4));
            cdg.Add(CDGCommands.MemoryPreset(0, 5));
            cdg.Add(CDGCommands.MemoryPreset(0, 6));
            cdg.Add(CDGCommands.MemoryPreset(0, 7));
            cdg.Add(CDGCommands.MemoryPreset(0, 8));
            cdg.Add(CDGCommands.MemoryPreset(0, 9));
            cdg.Add(CDGCommands.MemoryPreset(0, 10));
            cdg.Add(CDGCommands.MemoryPreset(0, 11));
            cdg.Add(CDGCommands.MemoryPreset(0, 12));
            cdg.Add(CDGCommands.MemoryPreset(0, 13));
            */
            // Split the encoded lyrics into lines.
            List<List<LyricsEncoding>> encodedLyricsLines = new List<List<LyricsEncoding>>();

            /*  1: Split the encoded lyrics into lines 
             *  2: 4 - 6 lines per page
             *  3: When a line is "done", and the next line has started, 
             *     it will be removed and replaced by a new line.
             */
            int lineCount = 0;

            // 1: Split the encoded lyrics into lines.
            for (int i = 0; i < lyricsEncodingList.Count; i++)
            {
                LyricsEncoding sublyrics = lyricsEncodingList[i];
                encodedLyricsLines.Add(new List<LyricsEncoding>());
                encodedLyricsLines[i].Add(sublyrics);

                // Check for end of line
                if (!sublyrics.Characters.EndsWith('\n') && !sublyrics.Characters.EndsWith("\r"))
                {
                    lineCount++;
                }
            }
            if (encodedLyricsLines.Count > 0)
            {
                var firstLine = encodedLyricsLines[0];
                string line = "";
                foreach (var sub in firstLine)
                {
                    line += sub.Characters;
                }
            }

            cdg.AddRange(CDGCommands.LetterA(0, 0));
            cdg.AddRange(CDGCommands.LetterB(0, 1));
            cdg.AddRange(CDGCommands.LetterC(0, 2));

            return cdg;
            // 2: 4-6 lines per page.
           
            
        }
    }

    public class LyricsEncoding
    {
        public LyricsEncoding(double startTime, double endTime, string characters)
        {
            StartTime = startTime;
            EndTime = endTime;
            Characters = characters;
        }
        public double StartTime { get; }
        public double EndTime { get; }
        public string Characters { get; }
    }

}
