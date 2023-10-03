using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public class ColorMarkersPair
    {
        public GMarkerGoogleType type { get; set; }
        public string name { get; set; }

        public ColorMarkersPair(GMarkerGoogleType type, string name)
        {
            this.type = type;
            this.name = name;
        }
    }

    public static class MarkerColors
    {
        public static List<ColorMarkersPair> colors = new List<ColorMarkersPair>()
            {
                new ColorMarkersPair(GMarkerGoogleType.blue, "Синий"),
                new ColorMarkersPair(GMarkerGoogleType.lightblue, "Голубой"),
                new ColorMarkersPair(GMarkerGoogleType.green, "Зеленый"),
                new ColorMarkersPair(GMarkerGoogleType.orange, "Оранжевый"),
                new ColorMarkersPair(GMarkerGoogleType.pink, "Розовый"),
                new ColorMarkersPair(GMarkerGoogleType.purple, "Фиолетовый"),
                new ColorMarkersPair(GMarkerGoogleType.red, "Красный"),

            };
    }
}
