using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Interfaces
{
    internal interface IStation
    {
         List<IPhone> RegisteredPhones { get; }

         void RegisterPhone(IPhone phone);

         bool ProcessCall(IPhone phone);
    }
}
