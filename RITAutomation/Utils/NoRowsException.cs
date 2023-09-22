using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    internal class NoRowsException : Exception
    { 
        public NoRowsException() : base("В базе данных нет записей о транспорте!") { }
    }
}
