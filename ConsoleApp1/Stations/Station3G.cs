using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Stations
{
    internal class Station3G : SimpleStation//наследуем от класса SimpleStation, который в свою очередь реализует интерфейс IStation
    {
        public Station3G() : base() { }//наследуем все методы

        private List<IPhone> registeredPhones = new List<IPhone>();
        public List<IPhone> RegisteredPhones3g
        {
            get
            {
                return registeredPhones;
            }

            set
            {
                registeredPhones = value;
            }
        }
        /*
        public override void RegisterPhone(IPhone phone)
        {
            //TODO! в условиях сказано
            //Базовая станция 3G:
            //Специальным образом регистрирует 3G - телефоны.
            //В данном случае этого не реализовано, т.к. сейчас 3G станция регистрирует все станции одинаково.
            //Идея с оверрайд методом правильная, но надо допилить.
            bool same = false;
                if (phone is Phones.Phone3G)
                {
                    foreach (var ph in RegisteredPhones3g) //проверили имеющийся список на повторения
                        if (ph == phone) same = true;
                    if (!same)
                    {
                        RegisteredPhones3g.Add(phone);
                        Console.WriteLine($"Станция: 3G абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
                    }
                    else
                    {
                        Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' УЖЕ зарегистрирован на станции. Повторная регистрация не требуется.");
                    }
                }
                else
                {
                    foreach (var ph in RegisteredPhones) //проверили имеющийся список на повторения
                        if (ph == phone) same = true;
                    if (!same)
                    {
                        RegisteredPhones.Add(phone);
                        Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
                    }
                    else
                    {
                        Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' УЖЕ зарегистрирован на станции. Повторная регистрация не требуется.");
                    }
                }
        }
        */

        //пришлось создать ибо 3g телефоны регаются в свой список и соответственно для 3g надо искать в обоих списках
        //
        public override bool ProcessCall(IPhone phone)      // true - зареган, false - нет зареган
        {
            if (!RegisteredPhones.Contains(phone) && !RegisteredPhones3g.Contains(phone))        //не найден в обоих списках
            {
                Console.WriteLine($"Станция: Номер '{phone.SimNumber}' НЕ зарегистрирован на станции 3G!");
                return false;
            }
            return true;
        }
    }
}
