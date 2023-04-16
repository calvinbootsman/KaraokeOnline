using Microsoft.AspNetCore.Components.Forms;

namespace KaraokeOnline.Controller
{
    public class KaraokeFilesController
    {
        public static bool ValidAudioFile(InputFile inputFile)
        {
            if (inputFile == null)
            {
                return false;
            }

            return true;
        }

        public static bool ValidCDGFile(InputFile inputFile)
        {
            if (inputFile == null)
            {
                return false;
            }
            return true;
        }
    }
}
