using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Interfaces;
using TestWorkDirectum.Structs;
using System;
using System.Collections.Generic;
using System.IO;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в имитационную программу тестового задания 'Cтанции и телефоны'.");
        Console.WriteLine("Для останова программы - пробел.");
        Console.WriteLine();
        List<IStation> stations = new List<IStation>();
        //stations.Add(new SimpleStation());                      //не смог сделать базу без параметра ибо выводится сообщение в теле конструктора
        stations.Add(new SimpleStation(stations.Count));
        stations.Add(new Station3G(stations.Count));
        stations.Add(new Station3G(stations.Count));
        //SimpleStation station1 = new ();          - пример одиночный
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
        //var phones = new List<IPhone>();
        PhoneList phoneslist = new PhoneList();
        //phones.Add(new SimplePhone("123456789012345", "+75671119111"));
        phoneslist.Add("123456789012345", "+75671119111", 0);                   // 0-базовая, 1-3g
        phoneslist.Add("123456789055555", "+75672229222", 0);
        phoneslist.Add("123456789066666", "+75673339333", 1);
        phoneslist.Add("123456789077777", "+75678889888", 1);
        //SimplePhone phone1 = new ("123412341234124", "+79828019521");         - пример одиночный
        //Phone3G phone3 = new("332412347688664", "+79828019523");              - пример одиночный
        //station1.RegisteredPhones.Add(phone1);                                - станция зарегала сама, а надо чтоб телефон сам при объявлении зарегался,
        //                                                                        для этого и создаем функцию ConnectToBase - пример одиночный
        //public string Imei
        //public string SimNumber
        //public IStation BaseStation
        //public List<Abonent> Abonents
        //public void ConnectToBase(IStation station)                           -переименовываем на Registration
        //public void Call(string contactNumber)
        //public void Call(Abonent abonent)
        //-------------------------------------------------------------------------------------------------
        Random x = new Random();//рандом для создания подключений телефонов и прочего
        for (; ; )
        {
            int n = x.Next(100);
            if (n == 55)
            {
                Console.WriteLine();
                Console.WriteLine("Получаем количественную информацию о системе - o.");
                Console.WriteLine("Введите для создания : базового телефона - a, 3g телефона - b, случайного телефона - e, 3g станции - c, базовой станции - d.");
                Console.WriteLine("Для регистрации телефонов нажмите r.");
                Console.WriteLine("Для разрегистрации случайного телефона на случайной станции нажмите k.");
                Console.WriteLine("Для вызова со случайного телефона из имеющихся нажмите t.");
                Console.WriteLine("Добавляем в справочник первого телефона, зарегистрированного на станции, три контакта - y.");
                Console.WriteLine("Для вызова по имени контакта c первого телефона, зарегистрированного на станции - u.");
                Console.WriteLine("Для выхода - пробел.");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.R)                                        //регистрируем:
                {
                    Console.WriteLine();
                    Console.WriteLine($"Регистрируем телефоны в сети на случайной станции. всего телефонов на данный момент - '{phoneslist.Count}' станций - '{stations.Count}'.");
                    List<string> myText = new List<string>();
                    myText.Add(DateTime.Now + " New 3G phone registrations:");
                    File.AppendAllLines("D:\\log.txt", myText);                 //шапку в файл сразу пишем чтоб было более понятно
                    foreach (var phone in phoneslist)                           //все теелфоны коннектим к ближайшей(случайной) станции - при повторном включении дублируются в списке на станции
                    {
                        phone.Registration(stations[x.Next(stations.Count)]);   //получаем номер какойто случайной станции из созданных - ArgumentOutOfRangeException  
                    }
                    Console.WriteLine();
                }
                else
                if (key == ConsoleKey.K)                                        //разрегистрируем одного случайного:
                {
                    Console.WriteLine();
                    int st = x.Next(stations.Count);
                    int ph = x.Next(phoneslist.Count);
                    try
                    {
                        stations[st].RegisteredPhones.Remove(phoneslist[ph]);       //тупо удаляем из списка по айдишникам коллекций основной проги
                    }
                    catch (ArgumentOutOfRangeException argumentOutOfRangeException) { Console.WriteLine("Ошибочка: работаем над ней.."); }
                    Console.WriteLine($"Станция: ID Абонента: '{ph}' был разрегистрирован на станции с ID ='{st}'.");
                    Console.WriteLine();
                }
                else
                if (key == ConsoleKey.A)                                        //добавляем телефон
                {
                    Console.WriteLine();
                    Console.Write("Введите номер SIM телефона через +7: ");
                    string sim = Console.ReadLine();
                    Console.Write("Введите номер IMEI(15 цифр): ");
                    string imei = Console.ReadLine();
                    phoneslist.Add(imei, sim, 0);
                }
                else
                if (key == ConsoleKey.B)
                {
                    Console.WriteLine();
                    Console.Write("Введите номер SIM телефона 3g через +7: ");
                    string sim = Console.ReadLine();
                    Console.Write("Введите номер IMEI(15 цифр) телефона 3g: ");
                    string imei = Console.ReadLine();
                    phoneslist.Add(imei, sim, 1);
                }
                else
                if (key == ConsoleKey.C)
                {
                    Console.WriteLine();
                    stations.Add(new Station3G(stations.Count));
                }
                else
                if (key == ConsoleKey.D)
                {
                    Console.WriteLine();
                    stations.Add(new SimpleStation(stations.Count));
                }
                else
                if (key == ConsoleKey.E)                                    //быстро генерим телефон
                {
                    Console.WriteLine();
                    phoneslist.AnyPhoneAdd(x.Next(2));
                }
                else
                if (key == ConsoleKey.T)                                    //исходящий звонок со случайного номера из созданных
                {
                    Console.WriteLine();
                    int ph = x.Next(phoneslist.Count);
                    try
                    {
                        phoneslist[ph].Call("+79826661666");
                    }
                    catch(ArgumentOutOfRangeException argumentOutOfRangeException) { Console.WriteLine("Ошибочка: работаем над ней.."); }
                }
                else
                if (key == ConsoleKey.Y)                                    //создаем список
                {
                    Console.WriteLine();
                    phoneslist[0].CollectNumber(new Abonent("Vladimir", "+79828819521"));
                    phoneslist[0].CollectNumber(new Abonent("Ivan", "+79824449444"));
                    phoneslist[0].CollectNumber(new Abonent("Artur", "+79825559555"));
                }
                if (key == ConsoleKey.U)                                    //исходящий звонок со первого номера по имени в справочнике
                {
                    Console.WriteLine();
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    phoneslist[0].Call(new Abonent(name, ""));
                }
                else
                if (key == ConsoleKey.O)                                    //итог текущий
                {
                    Console.WriteLine();
                    Console.WriteLine($"На данный момент имеем следующее(просто стало интересно, да и проверить легче). Всего телефонов на данный момент - '{phoneslist.Count}' станций - '{stations.Count}'");
                    int Cnt_p = 0, Cnt_s = 0;
                    int[] Cnt_r = {};
                    foreach (var phone in phoneslist)
                        if (phone is Phone3G)
                        {
                            Cnt_p++;
                        }
                    Console.WriteLine($"Телефонов 3g  - '{Cnt_p}'.");
                    foreach (var st in stations)
                        if (st is Station3G)
                        {
                            Cnt_s++;
                            Array.Resize(ref Cnt_r, Cnt_r.Length + 1);
                            foreach (var R in st.RegisteredPhones)
                                if (R is Phone3G)
                                {
                                    Cnt_r[Cnt_s-1]++;
                                }
                        }
                    Console.WriteLine($"Станций 3g  - '{Cnt_s}'. Зарегистрированных на них 3g телефонов:");
                    for (int i = 0; i < Cnt_r.Length; i++)
                    {
                        Console.WriteLine($"На станции под номером '{i+1}' - '{Cnt_r[i]}'");
                    }
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
