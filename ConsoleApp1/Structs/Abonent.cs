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
            mName = name;

            //TODO: проверка на то что это именно номер телефона.
            mPhoneNumber = phoneNumber;
        }
        public string NameAbonent { get { return mName; } set { mName = value; } }

        public string PhoneNumber { get { return mPhoneNumber; } set { mPhoneNumber = value; } }

        private string mName;
        private string mPhoneNumber;   
    }
}
