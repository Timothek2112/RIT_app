using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Utils
{
    internal class WrongGpggaDataException : Exception
    {
        public WrongGpggaDataException() : base("Данные, полученные с приемника не содержат GPGGA строку") { }
    }
}
