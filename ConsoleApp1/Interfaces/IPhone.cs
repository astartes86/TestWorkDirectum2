using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkDirectum.Structs;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Interfaces
{
    internal interface IPhone
    {
        public string Imei { get; set; }

        public string SimNumber { get; set; }

        public void Registration(IStation station);

        public void Call(string contactNumber);

        public void Call(Abonent abonent);

        public List<Abonent> Abonents { get; }

        protected IStation BaseStation { get; }

        public void CollectNumber(Abonent abonent);
    }
}
