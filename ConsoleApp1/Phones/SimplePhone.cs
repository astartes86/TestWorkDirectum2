using TestWorkDirectum.Interfaces;
using TestWorkDirectum.Structs;

namespace TestWorkDirectum.Phones
{
    internal class SimplePhone : IPhone //класс реализует интерфейс, обязуется выполнить все методы интерфейса! через запятую можно выполнить другой интерфейс
    {
        //private string imei;
        //private string simNumber;
        //private IStation baseStation;
        public SimplePhone(string codeImei, string sim)
        {
            Imei = codeImei;

            //TODO: проверка на то что это именно номер телефона.
            SimNumber = sim;
        }

        //описываем имей
        public string Imei
        {
            get;
            //{
            //    return imei;
            //}

            set;
            //{
            //    if (value == "")
            //        Console.WriteLine("IMEI не может быть пустым");
            //    else if (imei != null)
            //        Console.WriteLine("IMEI уже введен");
            //    else
            //        imei = value;
            //}
        }

        //описываем номер сим = номер телефона
        public string SimNumber
        {
            get;
            //{
            //        return simNumber;
            //}

            set;
            //{
            //    if (value == "")
            //        Console.WriteLine("SIM номер телефона не может быть пустым");
            //    else if (simNumber != null)
            //        Console.WriteLine("SIM номер телефона уже введен");
            //    else
            //        simNumber = value;
            //}
        }

        //описываем станцию
        public IStation BaseStation
        {
            get;
            //{
            //    return baseStation;
            //}

            set;
            //{
            //    baseStation = value;
            //}
        }

        //описываем зарег телефоны
        //private List<Abonent> abonents = new List<Abonent>();
        public List<Abonent> Abonents
        {
            get;
            //{
            //    return abonents;
            //}

            set;
            //{
            //    abonents = value;
            //}
        }

        //функция коннектит имей к станции, то есть регистрирует
        public void ConnectToBase(IStation station)
        {
            BaseStation = station;      //создаем станцию через интерфейс - то есть она либо 3ж либо обычная - и привязываем ее к конкретно указанной руками при вызове
            station.RegisterPhone(this);//эта станция вносит телефон в список зареганых на этой станции
        }

        public void Call(string contactNumber)
        {
            //TODO: Перед звонком сделать проверку что телефон законнекчен к станции.
            //Console.WriteLine($"Абонент '{this.SimNumber}' пытается вызвать абонента '{contactNumber}'");
            var result = BaseStation?.ProcessCall(this, contactNumber); //зарегистрирован на станции? если базовая станция не создана - вызов не происходит

            if (result.Equals(true))
            {
                Console.WriteLine($"Обрабатываем исходящий вызов абонента'{this.SimNumber}', соединяем с абонентом '{contactNumber}'");
            }
            else
            {
                Console.WriteLine($"Абоненту '{this.SimNumber}' не удалось вызвать абонента '{contactNumber}' по причине отсутствия регистрации абонента на станции");
            }
        }

        public void Call(Abonent abonent)
        {
           Call(abonent.PhoneNumber);
        }
    }
}
