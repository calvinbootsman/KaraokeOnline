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

        public void GenerateCDG()
        {
            CDGExtended CDGCommands = new CDGExtended();
            List<byte[]> cdg = new List<byte[]>();
            //Clear screen.
            cdg.AddRange(CDGCommands.CleanScreen());

            /*  1: Split the encoded lyrincs into lines 
             *  2: When making the pages of the encoded lyrics, first check where endTime != startTime of the next one.
             *     This means that there should be a page break. 
                3: Create the pages containing at most 4 - 6 lines (t.b.d.)
                4: Create the timings for all the pages
             */

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
