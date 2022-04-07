namespace TestWorkDirectum.Phones
{
    internal class Phone3G: SimplePhone //наследник : предок
    {
        public Phone3G( string codeImei, string sim) : base(codeImei, sim)                              //вызываем конструктор базового класса
        {
        }

        public override void mess_ph()
        {
            Console.WriteLine($"И создал Бог 3G телефон с номером SIM: '{SimNumber}' и IMEI '{Imei}'");
        }
    }
}
