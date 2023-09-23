using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public enum MarkerModeEnum
    {
        auto,
        manual
    }

    public class IdModeName
    {
        public MarkerModeEnum mode { get; set; }
        public string name { get; set; }

        public IdModeName(MarkerModeEnum mode, string name)
        {
            this.mode = mode;
            this.name = name;
        }
    }

    public static class MarkerMode
    {
        public static List<IdModeName> modes = new List<IdModeName>()
        {
            new IdModeName(MarkerModeEnum.auto, "Приемник"),
            new IdModeName(MarkerModeEnum.manual, "Вручную")
        };
    }
}
