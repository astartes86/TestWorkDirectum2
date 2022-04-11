using System.Text;
using TestWorkDirectum.Interfaces;
using System.IO;
using TestWorkDirectum.Phones;

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
                {
                    if (!same)
                    {
                        RegisteredPhones.Add(phone);
                        if (phone is Phone3G)
                            myText.Add("Станция: Абонент 3g с номером SIM:" + phone.SimNumber + " и IMEI " + phone.Imei +
                                                                    " был зарегистрирован на станции 3G под номером " + Convert.ToString(Id));
                        else
                            myText.Add("Станция: Абонент с номером SIM:" + phone.SimNumber + " и IMEI " + phone.Imei +
                                                                    " был зарегистрирован на станции 3G под номером " + Convert.ToString(Id));
                    }
                    else
                    {
                        myText.Add("Станция: Абонент с номером SIM: " + phone.SimNumber + " и IMEI " + phone.Imei +
                                                                    " УЖЕ зарегистрирован на станции 3G. Повторная регистрация не требуется.");
                    }
                    Console.WriteLine(myText[0]);
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
