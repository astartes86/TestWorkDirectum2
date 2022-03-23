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
        protected List<IPhone> RegisteredPhones { get; }

        public void RegisterPhone(IPhone phone);

        public bool ProcessCall(IPhone phone, string contactNumber);
    }
}
