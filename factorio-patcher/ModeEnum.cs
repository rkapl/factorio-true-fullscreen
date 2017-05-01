using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// http://stackoverflow.com/questions/744541/how-to-list-available-video-modes-using-c

namespace factorio_patcher
{
    public class Mode
    {
        public int W;
        public int H;
        public static List<Mode> ListModes()
        {
            DEVMODE mode = new DEVMODE();
            var modes = new List<Mode>();
            int i = 0;
            while (EnumDisplaySettings(null, i, ref mode))
            {
                if (mode.dmBitsPerPel == 32)
                {
                    var mm = new Mode()
                    {
                        W = mode.dmPelsWidth,
                        H = mode.dmPelsHeight
                    };
                    if (!modes.Contains(mm))
                        modes.Add(mm);
                }
                i++;
            }
            return modes;
        }
        
        public override string ToString()
        {
            return string.Format("{0}x{1}", W, H);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Mode))
                return false;
            var b = (Mode)obj;

            return b.W == W && b.H == H;
        }

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(
              string deviceName, int modeNum, ref DEVMODE devMode);
        const int ENUM_CURRENT_SETTINGS = -1;

        const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {

            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;

        }
    }
}
