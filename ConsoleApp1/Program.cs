using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Interfaces;
using TestWorkDirectum.Structs;

namespace TestWorkDirectum;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в имитационную программу тестового задания 'Cтанции и телефоны'.");
        Console.WriteLine("Для останова программы - пробел");
        Console.WriteLine();
        var stations = new List<IStation>();
        stations.Add(new SimpleStation());              //stations[0]
        stations.Add(new Station3G(stations.Count));                  //stations[1]
        //SimpleStation station1 = new ();  - пример одиночный
        //внутри:
        //создали station1.RegisteredPhone          - метод: регистрирует телефоны - если уже регался, то в список RegisteredPhones не добавляем
        //создали station1.RegisteredPhones         - список зарег. простых телефонов
        //создали station1.ProcessCall              - метод: смотрит RegisteredPhones - если есть то звони пожалуйста
        //Station3G station3g = new ();             - пример одиночный
        //внутри:
        //создали station3g.RegisteredPhone         - переопределеный метод: добавляет либо в список RegisteredPhones либо в список RegisteredPhones3g? реализовать второе осталось
        //создали station3g.RegisteredPhones        - --
        //создали station3g.RegisteredPhones3g      - список зарег. 3g телефонов
        //создали station3g.ProcessCall             - --
        //-------------------------------------------------------------------------------------------------
        var phones = new List<IPhone>();
        var ph_List = new PhoneList();
        //phones.Add(new SimplePhone("123456789012345", "+75671119111"));     //phones[0]
        ph_List.Add("123456789012345", "+75671119111");
        phones.Add(new Phone3G("223456789012346", "+75672229222"));         //phones[1]
        phones.Add(new Phone3G("323456789012347", "+75673339333"));         //phones[2]
        //SimplePhone phone1 = new ("123412341234124", "+79828019521");         - пример одиночный
        //Phone3G phone3 = new("332412347688664", "+79828019523");              - пример одиночный
        //station1.RegisteredPhones.Add(phone1); - станция зарегала сама, а надо чтоб телефон сам при объявлении зарегался, для этого и созда функцию ConnectToBase - пример одиночный
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
                Console.WriteLine();
                Console.WriteLine("Введите для создания : 3g телефона - a, базового телефона - b, 3g станции - c, базовой станции - d");
                Console.WriteLine("Для регистрации телефонов нажмите r");
                Console.WriteLine("Для разрегистрации случайного телефона на случайной станции нажмите k");
                Console.WriteLine("Для вызова со случайного телефона из имеющихся нажмите t");
                Console.WriteLine("Добавляем в справочник первого телефона три контакта - y");
                Console.WriteLine("Звоним контакту первого телефона - u");
                Console.WriteLine("Для выхода нажмите пробел");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.R)                                    //регистрируем:
                {
                    Console.WriteLine($"Регистрируем телефоны в сети на случайной станции. всего телефонов на данный момент - '{phones.Count}' станций - '{stations.Count}'");
                    List<string> myText = new List<string>();
                    myText.Add("New phone registrations:");
                    File.AppendAllLines("D:\\log.txt", myText);             //шапку в файл сразу пишем чтоб было более понятно
                    foreach (var phone in phones)                           //все теелфоны коннектим к ближайшей(случайной) станции - при повторном включении дублируются в списке на станции
                    {
                        int number_station = x.Next(stations.Count);        //получаем номер какойто случайной станции из появившихся
                        phone.Registration(stations[number_station]);      
                    }
                    Console.WriteLine();
                }
                else
                if (key == ConsoleKey.K)                                    //разрегистрируем одного случайного:
                {
                    int st = x.Next(stations.Count);
                    int ph = x.Next(phones.Count);
                    stations[st].RegisteredPhones.Remove(phones[ph]);       //тупо удаляем из списка по айдишникам коллекций основной проги
                    Console.WriteLine($"Станция: ID Абонента: '{ph}' был разрегистрирован на станции с ID ='{st}'");
                    Console.WriteLine();
                }
                else
                if (key == ConsoleKey.A)
                {
                    Console.Write("Введите номер SIM телефона 3g через +7: ");
                    string sim = Console.ReadLine();
                    Console.Write("Введите номер IMEI(15 цифр) телефона 3g: ");
                    string imei = Console.ReadLine();
                    phones.Add(new Phone3G(imei, sim));
                }
                else
                if (key == ConsoleKey.B)
                {
                    Console.Write("Введите номер SIM телефона через +7: ");
                    string sim = Console.ReadLine();
                    Console.Write("Введите номер IMEI(15 цифр): ");
                    string imei = Console.ReadLine();
                    phones.Add(new SimplePhone(imei, sim));
                }
                else
                if (key == ConsoleKey.C)
                {
                    stations.Add(new Station3G(stations.Count));
                }
                else
                if (key == ConsoleKey.D)
                {
                    stations.Add(new SimpleStation());
                }
                else
                if (key == ConsoleKey.T)                                    //исходящий звонок со случайного номера из имеющихся
                {
                    int ph = x.Next(phones.Count);
                    phones[ph].Call("+79826661666");
                }
                else
                if (key == ConsoleKey.Y)                                    //создаем список
                {
                    phones[0].CollectNumber(new Abonent("Vladimir", "+79828019521"));
                    phones[0].CollectNumber(new Abonent("Ivan", "+79824449444"));
                    phones[0].CollectNumber(new Abonent("Artur", "+79824449444"));
                }
                if (key == ConsoleKey.U)                                    //исходящий звонок со случайного номера из имеющихся но по имени в справочнике
                {
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    phones[0].Call(name);
                }
                else
                    if (key == ConsoleKey.Spacebar)                         //выходим из приложения
                    break;
            }
        }
        //Abonent abonent1 = new Abonent("Vladimir", "+79828019521");       //здесь запись не в справочнике а в уме и получается 
        //phone3.Call(abonent1);
    }
}
