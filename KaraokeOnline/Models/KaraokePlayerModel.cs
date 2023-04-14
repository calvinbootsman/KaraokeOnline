using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace KaraokeOnline.Models
{
    public class KaraokePlayerModel
    {
        public KaraokePlayerModel() { }
        public KaraokePlayerModel(string cdgFileLocation, string mp3FileLocation) {
            AutoLoadCdgPlayer = true;
            CDGFileLocation = cdgFileLocation;
            Mp3FileLocation = mp3FileLocation;
        }

        public KaraokePlayerModel(InputFile audioFile, InputFile cdgFile)
        {
            AutoLoadCdgPlayer = true;
            AudioFile = audioFile;
            CDGFile = cdgFile;
        }
        public bool UseDebugValue { get; } = false;
        public string CDGFileLocation { get; } = "";
        public string Mp3FileLocation { get; } = "";
        public bool AutoLoadCdgPlayer { get; } = false;
        public InputFile? AudioFile { get; }
        public InputFile? CDGFile { get;  }
    }
}
