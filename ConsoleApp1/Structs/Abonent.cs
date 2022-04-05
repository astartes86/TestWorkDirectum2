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
            //mName = name;
            NameAbonent = name;
            //TODO: проверка на то что это именно номер телефона.
            //mPhoneNumber = phoneNumber;
            PhoneNumber = phoneNumber;
        }
        public string NameAbonent { get; set; }//{ get { return mName; } set { mName = value; } }

        public string PhoneNumber { get; set; }//{ get { return mPhoneNumber; } set { mPhoneNumber = value; } }

        //private string mName;
        //private string mPhoneNumber;   
    }
}
