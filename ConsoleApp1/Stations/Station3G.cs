using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Stations
{
    internal class Station3G : SimpleStation
    {
        public Station3G() : base() { }
        public override void RegisterPhone(IPhone phone)
        {
            //TODO! в условиях сказано
            //Базовая станция 3G:
            //Специальным образом регистрирует 3G - телефоны.
            //В данном случае этого не реализовано, т.к. сейчас 3G станция регистрирует все станции одинаково.
            //Идея с оверрайд методом правильная, но надо допилить.
            RegisteredPhones.Add(phone);
            Console.WriteLine($"Абонент с номером: '{phone.SimNumber}' и IMEI '{phone.Imei}' был зарегистрирован на станции 3G.");
        }

    }

}
