using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
        public class SourceTypeNamePair
        {
            public SourceTypeEnum type { get; set; }
            public string name { get; set; }

            public SourceTypeNamePair(SourceTypeEnum type, string name)
            {
                this.type = type;
                this.name = name;
            }
        }

        public static class SourceTypes
        {
            public static List<SourceTypeNamePair> types = new List<SourceTypeNamePair>()
            {
                new SourceTypeNamePair(SourceTypeEnum.UDP, "UDP"),
                new SourceTypeNamePair(SourceTypeEnum.COM, "COM порт"),
                new SourceTypeNamePair(SourceTypeEnum.FILE, "Файл"),

            };
        }

}
