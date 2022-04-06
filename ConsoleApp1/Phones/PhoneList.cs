using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Phones
{
    internal class PhoneList : List<IPhone>
    {
        public void Add(string codeImei, string sim)
        {
            if (codeImei != "")
            this.Add(new SimplePhone(codeImei, sim));
            else
                Console.WriteLine("IMEI не может быть пустым. Телефон не создан");
        }
    }
}