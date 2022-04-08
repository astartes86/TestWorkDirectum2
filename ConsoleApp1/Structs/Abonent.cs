using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkDirectum.Structs
{
    internal struct Abonent
    {
        public Abonent(string name, string phoneNumber)
        {
            NameAbonent = name;
            PhoneNumber = phoneNumber;
            //TODO: проверка на то что это именно номер телефона.
        }

        public string NameAbonent { get; set; }

        public string PhoneNumber { get; set; }
    }
}
