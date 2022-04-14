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
         string Imei { get; set; }

         string SimNumber { get; set; }

         void Registration(IStation station);

         void Call(string contactNumber);

         void Call(Abonent abonent);

         List<Abonent> Abonents { get; }

         IStation BaseStation { get; }

         void CollectNumber(Abonent abonent);
    }
}
