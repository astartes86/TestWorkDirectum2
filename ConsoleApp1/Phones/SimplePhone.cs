using TestWorkDirectum.Interfaces;
using TestWorkDirectum.Structs;

namespace TestWorkDirectum.Phones
{
    internal class SimplePhone : IPhone
    {
        private string imei;
        private string simNumber;
        private IStation baseStation;
        public SimplePhone(string codeImei, string sim)
        {
            Imei = codeImei;

            //TODO: проверка на то что это именно номер телефона.
            SimNumber = sim;
        }

        //описываем имей
        public string Imei
        {
            get
            {
                return imei;
            }

            set
            {
                if (value == "")
                    Console.WriteLine("IMEI не может быть пустым");
                else if (imei != null)
                    Console.WriteLine("IMEI уже введен");
                else
                    imei = value;
            }
        }
        //описываем номер сим = номер телефона
        public string SimNumber
        {
            get
            {
                return simNumber;
            }

            set
            {
                if (value == "")
                    Console.WriteLine("SIM номер телефона не может быть пустым");
                else if (simNumber != null)
                    Console.WriteLine("SIM номер телефона уже введен");
                else
                    simNumber = value;
            }
        }
        //описываем станцию
        public IStation BaseStation
        {
            get
            {
                return baseStation;
            }

            set
            {
                baseStation = value;
            }
        }

        //описываем зарег телефоны

        private List<Abonent> abonents = new List<Abonent>();
        public List<Abonent> Abonents
        {
            get
            {
                return abonents;
            }

            set
            {
                abonents = value;
            }
        }

        //функция коннектит имей к станции
        public void ConnectToBase(IStation station)
        {
            //получаем рандомную станцию из созданных ранее
            BaseStation = station;
            station.RegisterPhone(this);
        }
        public void Call(string contactNumber)
        {
            //TODO: Перед звонком сделать проверку что телефон законнекчен к станции.
            Console.WriteLine($"Абонент '{this.SimNumber}' пытается вызвать абонента '{contactNumber}'");
            var result = BaseStation?.ProcessCall(this, contactNumber);

            if (result.Equals(true))
            {
                Console.WriteLine("Звонок прошел успешно.");
            }
            else
            {
                Console.WriteLine("Не удалось совершить звонок.");
            }
        }
        public void Call(Abonent abonent)
        {
           Call(abonent.PhoneNumber);
        }
    }
}
