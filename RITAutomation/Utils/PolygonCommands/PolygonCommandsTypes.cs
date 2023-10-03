using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    public class CommandNamePair
    {
        public PolygonCommandEnum commandType { get; set; }
        public string name { get; set; }

        public CommandNamePair(PolygonCommandEnum type, string name)
        {
            this.commandType = type;
            this.name = name;
        }
    }

    public static class PolygonCommandsTypes
    {
        public static List<CommandNamePair> types = new List<CommandNamePair>()
            {
                new CommandNamePair(PolygonCommandEnum.ChangeColor, "Изменение цвета"),
                new CommandNamePair(PolygonCommandEnum.SendMessage, "Сообщение"),
                new CommandNamePair(PolygonCommandEnum.None, "Ничего"),
                new CommandNamePair(PolygonCommandEnum.RandomPositionOnScreen, "Случайная позиция в пределах экрана")
            };
    }
}
