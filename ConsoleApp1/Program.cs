using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу тестового задания 'Cтанции и телефоны'.");
        Console.WriteLine("Для остановки вв");
        var stations = new List<IStation>();
        stations.Add(new SimpleStation());
        stations.Add(new Station3G());
        //SimpleStation station1 = new ();
        //внутри:
        //создали station1.RegisteredPhone
        //создали station1.RegisteredPhones
        //создали station1.ProcessCall
        //Station3G station3g = new ();
        //внутри:
        //создали station3g.RegisteredPhone (переопределеный: добавляет либо в список RegisteredPhones либо в список RegisteredPhones3g? реализовать второе осталось)
        //создали station3g.RegisteredPhones 
        //создали station3g.RegisteredPhones3g
        //создали station3g.ProcessCall
        //-------------------------------------------------------------------------------------------------

        var phones = new List<IPhone>();
        phones.Add(new SimplePhone("123412341234124", "+79828019521"));
        phones.Add(new Phone3G("332412347688664", "+79828019523"));
        phones.Add(new Phone3G("332412347688555", "+79828019555"));
        //SimplePhone phone1 = new ("123412341234124", "+79828019521");
        //Phone3G phone3 = new("332412347688664", "+79828019523");
        //station1.RegisteredPhones.Add(phone1); - станция зарегала сама, а надо чтоб телефон сам при объявлении зарегался, для этого и создали функцию ConnectToBase
        //public string Imei
        //public string SimNumber
        //public IStation BaseStation
        //public List<Abonent> Abonents
        //public void ConnectToBase(IStation station)
        //public void Call(string contactNumber)
        //public void Call(Abonent abonent)
        //-------------------------------------------------------------------------------------------------
        phones[0].ConnectToBase(stations[0]);//при включении телефон послал запрос на регистрацию

        Random x = new Random();//рандом для постепенного создания подключений телефонов
        Random y = new Random();//рандом для случайной станции


        for (; ; )
        {
            int n = x.Next(100);
            Console.WriteLine(n);
                if (n == 55)                                            //наконец дождались что телефоны включились
                foreach (var phone in phones)                           //все теелфоны коннектим к случайной станции - при повторном включении дублируются в списке на станции
                {
                    int number_station = y.Next(stations.Count);
                    phone.ConnectToBase(stations[number_station]);
                    phones[2].Call("+79828019521");                     //типо звоним - если не зареган то звонок прекращаем
                }
                if (n == 55)
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
        }

        
        //Abonent abonent1 = new Abonent("Vladimir", "+79828019521");
        //phone3.Call(abonent1);
    }
}
