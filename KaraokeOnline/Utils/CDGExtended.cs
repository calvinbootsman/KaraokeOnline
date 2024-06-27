using static CDGCommands;

namespace KaraokeOnline.Utils
{
    public class CDGExtended : CDGCommands
    {
        //  public SetScreen(
        /*    This file is used to create a screen from the timing files?
         *    There needs to be a file where we can create a font 
         *  https://fonts.google.com/specimen/VT323?preview.text=HIJKLMNOPQRSTUVWXYZ&preview.size=113&preview.text_type=custom&category=Monospace&classification=Monospace
         */
        public List<byte[]> CleanScreen()
        {
            List<byte[]> output = new List<byte[]>();
            for (byte i = 0; i < 8; i++)
            {
                output.Add(MemoryPreset(0, i));   
            }

            return output;
        }
        public List<byte[]> LetterA(byte row, byte column)
        {
            return new List<byte[]> {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row=row, column=column, tilePixels = new byte[] {0,0,0,3,3,3,7,7,7,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {24,24,24,24,31,31,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,32,32,32,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {24,24,24,24,56,56,12,12,12,12,12,12}})
            };
        }

        public List<byte[]> LetterB(byte row, byte column)
        {
            return new List<byte[]> {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,63,63,63}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,56,56,56,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {56,56,56,12,12,12,12,12,12,56,56,56}})
            };
        }

        public List<byte[]> LetterC(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,24,24,24,15,15,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,24,24,24,48,48,48}})
            };
        }

        public List<byte[]> LetterD(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,48,48,48,63,63,63}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,12,24,24,24,48,48,48}})
            };
        }

        public List<byte[]> LetterE(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,63,63,63}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,60,60,60,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {32,32,32,0,0,0,0,0,0,60,60,60}}),
            };
        }

        public List<byte[]> LetterF(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,60,60,60,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {32,32,32,0,0,0,0,0,0,0,0,0}}),
            };
        }

        public List<byte[]> LetterG(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,24,24,24,15,15,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,60,60,60,12,12,12,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {60,60,60,12,12,12,12,12,12,56,56,56}}),
            };
        }

        public List<byte[]> LetterH(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,12,12,12,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {60,60,60,12,12,12,12,12,12,12,12,12}}),
            };
        }

        public List<byte[]> LetterI(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,3,3,3,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {3,3,3,3,3,3,3,3,3,15,15,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,48,48,48}}),
            };
        }

        public List<byte[]> LetterJ(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,3,3,3,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {3,3,3,3,3,3,51,51,51,30,30,30}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,0,0,0}}),
            };
        }

        public List<byte[]> LetterK(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,48,48,48,49,49,49,51,51}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {51,62,62,51,51,51,49,49,49,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,48,48,48,32,32,32,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,32,32,32,48,48,48}}),
            };
        }

        public List<byte[]> LetterL(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,48,48,48,48,63,63}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,0,60,60}}),
            };
        }

        public List<byte[]> LetterM(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,56,56,60,52,52,55,51,51}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {51,48,48,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,28,28,60,44,44,44,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,12,12,12,12,12,12,12}}),
            };
        }

        public List<byte[]> LetterN(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,56,56,56,60,60,60,54,54}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {54,51,51,51,49,49,49,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,12,12,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,44,44,44,60,60,60,12,12}}),
            };
        }

        public List<byte[]> LetterO(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,24,24,24,15,15,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,12,24,24,24,48,48,48}}),
            };
        }

        public List<byte[]> LetterP(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,56,56,56,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {56,56,56,0,0,0,0,0,0,0,0,0}}),
            };
        }

        public List<byte[]> LetterQ(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,15,15,15,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,51,49,25,24,24,15,15,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,44,56,24,24,56,60,52}}),
            };
        }

        public List<byte[]> LetterR(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {63,63,63,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,56,56,56,12,12,12,24,24,24}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {32,32,32,48,48,48,24,24,24,12,12,12}}),
            };
        }

        public List<byte[]> LetterS(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,31,31,31,48,48,48,48,48,48,31}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {31,31,0,0,0,0,48,48,48,31,31,31}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,56,56,56,12,12,12,0,0,0,56}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {56,56,12,12,12,12,12,12,12,56,56,56}}),
            };
        }

        public List<byte[]> LetterT(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,63,63,63,3,3,3,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {3,3,3,3,3,3,3,3,3,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,60,60,60,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,0,0,0}}),
            };
        }

        public List<byte[]> LetterU(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,48,48,48,48,48,56,63,31,15}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,12,12,12,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,12,12,12,28,60,56,48}}),
            };
        }
        public List<byte[]> LetterV(byte row, byte column)
        {
            return new List<byte[]> {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {24,24,24,12,12,12,7,7,7,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,12,12,12,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {24,24,24,48,48,48,32,32,32,0,0,0}}),
            };
        }

        public List<byte[]> LetterW(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,48,48,48,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {48,48,48,51,51,27,31,31,31,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,12,12,12,12,12,12,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {12,12,12,12,12,24,56,56,56,48,48,48}}),
            };
        }

        public List<byte[]> LetterX(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row,column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {7,7,7,12,12,12,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,12,12,12,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {32,32,32,48,48,48,24,24,24,12,12,12}}),
            };
        }

        public List<byte[]> LetterY(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,48,48,48,24,24,24,12,12,12}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {7,7,7,3,3,3,3,3,3,3,3,3}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,12,12,12,24,24,24,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {32,32,32,0,0,0,0,0,0,0,0,0}}),
            };
        }

        public List<byte[]> LetterZ(byte row, byte column)
        {
            return new List<byte[]>
            {
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,63,63,63,0,0,0,0,0,0}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {3,3,3,12,12,12,48,48,48,63,63,63}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,60,60,60,12,12,12,48,48,48}}),
                TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row = row, column = column, tilePixels = new byte[] {0,0,0,0,0,0,0,0,0,60,60,60}}),
            };
        }
    }
}