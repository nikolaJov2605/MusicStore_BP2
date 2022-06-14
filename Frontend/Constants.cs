using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public static class Constants
    {
        public static List<string> InstrumentTypes = new List<string>() { "Gitara", "Klavir", "Klavijatura", "Bubanj" };
        public static List<string> GuitarTypes = new List<string>() { "Klasična", "Akustična", "Električna", "Bas" };
        public static List<string> PianoTypes = new List<string>() { "Električni", "Pianino", "Koncertni" };
        public static List<string> KeyboardTypes = new List<string>() { "Školska", "Aranžerska" };
        public static List<string> DrumTypes = new List<string>() { "Akustični", "Elektronski" };


        public static List<string> WorkerPositions = new List<string>() { "Prodavac", "Tehničar", "Full" };
    }
}
