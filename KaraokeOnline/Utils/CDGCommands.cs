using System;

public class CDGCommands
{
    public byte[] MemoryPreset(byte color, byte repeat)
    {
        byte[] cdgData = new byte[16];
        cdgData[0] = color;
        cdgData[1] = repeat;
        return CreateInstruction(1, cdgData);
    }

    public byte[] BorderPreset(byte color)
    {
        byte[] cdgData = new byte[16];
        cdgData[0] = color;
        return CreateInstruction(2, cdgData);
    }

    public byte[] TileBlockNormal(CDG_Tile tile)
    {
        byte[] cdgData = new byte[16];

        cdgData[0] = tile.color0;
        cdgData[1] = tile.color1;
        cdgData[2] = tile.row;
        cdgData[3] = tile.column;

        for (int i = 0; i < 12; i++)
        {
            cdgData[i + 4] = tile.tilePixels[i];
        }

        return CreateInstruction(6, cdgData);
    }

    public byte[] ScrollPreset(CDG_Scroll scroll)
    {
        byte[] cdgData = new byte[16];

        cdgData[0] = scroll.color;
        cdgData[1] = scroll.hScroll;
        cdgData[2] = scroll.vScroll;
        return CreateInstruction(20, cdgData);
    }

    public byte[] ScrollCopy(CDG_Scroll scroll)
    {
        byte[] cdgData = new byte[16];
        cdgData[0] = scroll.color;
        cdgData[1] = scroll.hScroll;
        cdgData[2] = scroll.vScroll;
        return CreateInstruction(24, cdgData);
    }

    public byte[] DefineTransparentColor()
    {
        byte[] cdgData = new byte[16];
        cdgData[0] = 28;
        // Add any additional data related to defining transparent color, if needed.
        return cdgData;
    }

    public byte[] LoadColorTableLow(ushort[] colorTable)
    {
        byte[] cdgData = new byte[16];
        ushort mask = 0x3F3F;
        for (int i = 0 ; i < colorTable.Length; i++)        
        { 
            colorTable[i] = (ushort)(colorTable[i] & mask);
        }

        Buffer.BlockCopy(colorTable, 0, cdgData, 0, cdgData.Length);

        return CreateInstruction(30, cdgData);
    }

    public byte[] LoadColorTableHigh(ushort[] colorTable)
    {
        byte[] cdgData = new byte[16];
        ushort mask = 0x3F3F;
        for (int i = 0; i < colorTable.Length; i++)
        {
            colorTable[i] = (ushort)(colorTable[i] & mask);
        }

        Buffer.BlockCopy(colorTable,0, cdgData, 0, cdgData.Length);

        return CreateInstruction(31, cdgData);
    }

    public byte[] TileBlockXOR(CDG_Tile tile)
    {
        byte[] cdgData = new byte[16];
    
        cdgData[0] = tile.color0;
        cdgData[1] = tile.color1;
        cdgData[2] = tile.row;
        cdgData[3] = tile.column;

        for (int i = 0; i < 12; i++)
        {
            cdgData[i + 4] = tile.tilePixels[i];
        }

        return CreateInstruction(38, cdgData);
    }

    private byte[] CreateInstruction(byte instruction, byte[] data)
    {
        byte[] value = new byte[24];
        value[0] = 0x09;
        value[1] = instruction;
        value[2] = 0;
        value[3] = 0;
        for (int i = 0; i < data.Length; i++)
        {
            value[4 + i] = data[i];
        }
        for (int i = 4 + data.Length; i < 24; i ++)
        {
            value[i] = 0;
        }

        return value;
    }
    // Define the structures for CD+G instructions
    public byte[] CreateScreen()
    {
        List<byte[]> data = new List<byte[]>()
        {
            LoadColorTableLow(new ushort[] {0x30,0,0,0,0,0,0,0}),
            LoadColorTableHigh(new ushort[] {0,0,0,0,0,0,0,0}),
            MemoryPreset(0,0),
            MemoryPreset(0,1),
            MemoryPreset(0,2),
            MemoryPreset(0,3),
            MemoryPreset(0,4),
            MemoryPreset(0,5),
            MemoryPreset(0,6),
            MemoryPreset(0,7),
            MemoryPreset(0,8),
            MemoryPreset(0,9),
            MemoryPreset(0,10),
            MemoryPreset(0,11),
            MemoryPreset(0,12),
            MemoryPreset(0,13),

            TileBlockNormal(new CDG_Tile{color0 = 0, color1 = 1, row=0, column=0, tilePixels = new byte[] {255,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF}})
        };

        for (byte row = 0; row < 18; row++) {
            for (byte col = 0; col < 50; col++)
            {
                data.Add(TileBlockNormal(new CDG_Tile { color0 = 0, color1 = 1, row = row, column = col, tilePixels = new byte[] { 255, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } }));
            }
        }
        foreach (byte[] value in data)
        {            
            foreach(byte b in value)
            {
                Console.Write($"0x{b} ");
            }
        }

        return data.SelectMany(b => b).ToArray();
    }

    public void LogFile(int maxInstructions)
    {
        string path = "C:\\Users\\CalvinBootsman\\Downloads\\Katy Perry - Dark Horse.cdg";
        byte[] data = File.ReadAllBytes(path);

        int i = 0;
        int max = maxInstructions * 24;
        foreach (byte value in data)
        {
            Console.Write($"0x{value} ");
            i++;
            if (i == max) { return; }
        }

    }

    public byte[] GetFileBytes(int maxInstructions)
    {
        string basePath = AppContext.BaseDirectory;

        // Combine the base path with the relative path to the file
        string path = Path.Combine(basePath, "wwwroot", "cdg", "private_eyes.cdg");

        byte[] data = File.ReadAllBytes(path);

        int max = maxInstructions * 24;

        if (data.Length > max) { 
            return data[0..max];
        }

        return new byte[1];
        
    }
    public struct CDG_Tile
    {
        public byte color0;
        public byte color1;
        public byte row;
        public byte column;
        public byte[] tilePixels;
    }

    public struct CDG_Scroll
    {
        public byte color;
        public byte hScroll;
        public byte vScroll;
    }

    public struct CDG_LoadCLUT
    {
        public short[] colorSpec;
    }
}