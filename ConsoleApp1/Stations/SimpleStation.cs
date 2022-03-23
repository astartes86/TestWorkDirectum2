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
        } //TODO! Пробел между функциями.
        //функция регистрирует 
        public virtual void RegisterPhone(IPhone phone)
        {
            RegisteredPhones.Add(phone);
            Console.WriteLine($"Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции с номером.");
        }

        //функция обрабатывает исходящие вызовы для зарегистрированных
        public bool ProcessCall(IPhone phone, string contactNumber)
        {
            if (!RegisteredPhones.Contains(phone))
            {
                Console.WriteLine($"Номер '{phone.SimNumber}' НЕ зарегистрирован на станции!");
                return false;
            }
            return true; 

        }
    }
}
