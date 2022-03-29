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

        public override void RegisterPhone(IPhone phone)
        {
            //TODO! в условиях сказано
            //Базовая станция 3G:
            //Специальным образом регистрирует 3G - телефоны.
            //В данном случае этого не реализовано, т.к. сейчас 3G станция регистрирует все станции одинаково.
            //Идея с оверрайд методом правильная, но надо допилить.
            if (phone is Phones.Phone3G)
            {
                RegisteredPhones3g.Add(phone);
                Console.WriteLine($"3G абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
            }
            else
            {
                RegisteredPhones.Add(phone);
                Console.WriteLine($"Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
            }
        }
    }
}
