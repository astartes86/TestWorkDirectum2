using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу тестового задания 'Cтанции и телефоны'.");
        Console.WriteLine("Для остановки Esc, для продолжния любой другой символ");
        Console.WriteLine();
        var stations = new List<IStation>();
        stations.Add(new SimpleStation());              //stations[0]
        stations.Add(new Station3G(stations.Count));                  //stations[1]
        //SimpleStation station1 = new ();  - пример одиночный
        //внутри:
        //создали station1.RegisteredPhone          - метод: регистрирует телефоны - если уже регался, то в список RegisteredPhones не добавляем
        //создали station1.RegisteredPhones         - список зарег. простых телефонов
        //создали station1.ProcessCall              - метод: смотрит RegisteredPhones - если есть то звони пожалуйста
        //Station3G station3g = new ();     - пример одиночный
        //внутри:
        //создали station3g.RegisteredPhone         - переопределеный метод: добавляет либо в список RegisteredPhones либо в список RegisteredPhones3g? реализовать второе осталось
        //создали station3g.RegisteredPhones        - --
        //создали station3g.RegisteredPhones3g      - список зарег. 3g телефонов
        //создали station3g.ProcessCall             - --
        //-------------------------------------------------------------------------------------------------
        var phones = new List<IPhone>();
        phones.Add(new SimplePhone("123412341234124", "+79828019000"));     //phones[0]
        phones.Add(new Phone3G("332412347688664", "+79828019001"));         //phones[1]
        phones.Add(new Phone3G("332412347688555", "+79828019002"));         //phones[2]
        //SimplePhone phone1 = new ("123412341234124", "+79828019521");         - пример одиночный
        //Phone3G phone3 = new("332412347688664", "+79828019523");              - пример одиночный
        //station1.RegisteredPhones.Add(phone1); - станция зарегала сама, а надо чтоб телефон сам при объявлении зарегался, для этого и создали функцию ConnectToBase - пример одиночный
        //public string Imei
        //public string SimNumber
        //public IStation BaseStation
        //public List<Abonent> Abonents
        //public void ConnectToBase(IStation station)
        //public void Call(string contactNumber)
        //public void Call(Abonent abonent)
        //-------------------------------------------------------------------------------------------------
//        phones[1].ConnectToBase(stations[1]);//при включении телефон послал запрос на регистрацию - пример одиночный
//        phones[1].Call("+79828019666");

        Random x = new Random();//рандом для постепенного создания подключений телефонов
        //Random y = new Random();//рандом для случайной станции

        for (; ; )
        {   

            int n = x.Next(100);
            if (n == 55)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine("Для разрегистрации случайного телефона на случайной станции нажмите d");
                Console.WriteLine("Для регистрации телефонов нажмите p");
                Console.WriteLine("Для выхода нажмите пробел");        //выходим из приложения
                Console.WriteLine();
                if (key == ConsoleKey.P)//наконец дождались что телефоны включились
                {
                    Console.WriteLine($"Регистрируем телефоны в сети. всего телефонов на данный момент - '{phones.Count}' станций - '{stations.Count}'");
                    foreach (var phone in phones)                           //все теелфоны коннектим к ближайшей(случайной) станции - при повторном включении дублируются в списке на станции
                    {
                        int number_station = x.Next(stations.Count);        //получаем номер какойто случайной станции из появившихся

                        phone.Registration(stations[number_station]);      
                    }
                    Console.WriteLine();
                }
                else
                if (key == ConsoleKey.D)
                {
                    int st = x.Next(stations.Count);
                    int ph = x.Next(phones.Count);
                    stations[st].RegisteredPhones.Remove(phones[ph]);       //тупо удаляем из списка по айдишникам коллекций основной проги
                    Console.WriteLine($"Станция: ID Абонента: '{ph}' был разрегистрирован на станции с ID ='{st}'");
                    Console.WriteLine();
                }
                else
                    if (key == ConsoleKey.Spacebar)
                        break;
            }
        }


        //Abonent abonent1 = new Abonent("Vladimir", "+79828019521");
        //phone3.Call(abonent1);
    }
}
