using System.Text;
using TestWorkDirectum.Interfaces;
using System.IO;

namespace TestWorkDirectum.Stations
{
    internal class Station3G : SimpleStation    //наследуем от класса SimpleStation, который в свою очередь реализует интерфейс IStation
    {
        public Station3G(int id) : base(id)       //наследуем все методы
        {
        }

        public override void Mess_st()
        {
            Console.WriteLine($"И была создана станция 3g с номером: '{Id}' ");
        }

        public override void RegisterPhone(IPhone phone)
        {
            List<string> myText = new List<string>();
            bool same = false;
            //myText.Add("New phone registrations:");
            foreach (var ph in RegisteredPhones) //проверили имеющийся список на повторения
                if (ph == phone) same = true;
            if (!same)
            {
                RegisteredPhones.Add(phone);
                Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
                myText.Add("PHONE :: SIM: " + phone.SimNumber + " IMEI: " + phone.Imei + " Number of staion: " + Convert.ToString(Id));
                //Log_write(phone.SimNumber, phone.Imei, St_id);
            }
            else
            {
                Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' УЖЕ зарегистрирован на станции 3G. Повторная регистрация не требуется.");
            }
            File.AppendAllLines("D:\\log.txt", myText);
        }

        public override bool ProcessCall(IPhone phone)      // true - зареган, false - нет зареган
        {
            if (!RegisteredPhones.Contains(phone))        //не найден в обоих списках
            {
                Console.WriteLine($"Станция: Номер '{phone.SimNumber}' НЕ зарегистрирован на станции 3G!");
                return false;
            }
            return true;
        }
    }
}
