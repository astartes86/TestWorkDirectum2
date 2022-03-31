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
            bool same = false;
            foreach (var ph in RegisteredPhones) //проверили имеющийся список на повторения
                if (ph == phone) same = true;
            if (!same)
            {
                RegisteredPhones.Add(phone);
                Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции.");
            }
            else
            {
                Console.WriteLine($"Станция: Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' УЖЕ зарегистрирован на станции. Повторная регистрация не требуется.");
            }
        }

        //функция обрабатывает исходящие вызовы для зарегистрированных
        //на станции естетственно зарегистрированных уже много и потому среди них ищем тот кто звонит
        //ввиду того что при тесте руками регистрируем то телефон всегда будет в списке и условие никогда не выполниться
        //или всеж выполниться? можно как то задать?
        //up:выполнится когда телефон зарегался на 3g станции и происходит звонок. т.к. телефоны 3g одинаковы с простыми ибо полностью наследуются
        public virtual bool ProcessCall(IPhone phone)     // true - зареган, false - нет зареган
        {
            if (!RegisteredPhones.Contains(phone))
            {
                Console.WriteLine($"Станция: Номер '{phone.SimNumber}' НЕ зарегистрирован на станции!");
                return false;   //выход из функции со значением
            }
            return true; 
        }
    }
}
