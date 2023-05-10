namespace KaraokeOnline.Models
{
    public class LyricsSyncModel
    {
        public LyricsSyncModel() { }
        public List<LyricsEncoding> GetEncodedLyrics() { return new List<LyricsEncoding>(); }

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
    }

    public class LyricsEncoding
    {
        public LyricsEncoding(int startTime, int endTime, string characters)
        {
            StartTime = startTime;
            EndTime = endTime;
            Characters = characters;
        }
        public int StartTime { get; }
        public int EndTime { get; }
        public string Characters { get; }
    }
}
