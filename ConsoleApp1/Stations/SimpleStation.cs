using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Stations
{
    internal class SimpleStation : IStation
    {
        public SimpleStation()
        {

        }
        //описываем зарег телефоны

        private List<IPhone> registeredPhones = new List<IPhone>();
        public List<IPhone> RegisteredPhones
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

        //функция регистрирует 
        public virtual void RegisterPhone(IPhone phone)
        {
            RegisteredPhones.Add(phone);
            Console.WriteLine($"Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции с номером.");
        }

        //функция обрабатывает исходящие вызовы для зарегистрированных
        //на станции естетственно зарегистрированных уже много и потому среди них ищем тот кто звонит
        //ввиду того что при тесте руками регистрируем то телефон всегда будет в списке и условие никогда не выполниться
        //или всеж выполниться? можно как то задать?
        public bool ProcessCall(IPhone phone, string contactNumber)     // true - зареган, false - нет зареган
        {
            if (!RegisteredPhones.Contains(phone))
            {
                Console.WriteLine($"Станция: Номер '{phone.SimNumber}' НЕ зарегистрирован на станции!");
                return false;
            }
            return true; 
        }
    }
}
