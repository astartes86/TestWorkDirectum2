using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Structs;

namespace TestWorkDirectum;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу тестового задания 'Cтанции и телефоны'.");

        SimpleStation station1 = new ();
        //внутри:
        //создали station1.RegisteredPhone
        //создали station1.RegisteredPhones
        //создали station1.ProcessCall
        Station3G station3g = new ();
        //внутри:
        //создали station3g.RegisteredPhone (переопределеный: добавляет либо в список RegisteredPhones либо в список RegisteredPhones3g? реализовать второе осталось)
        //создали station3g.RegisteredPhones 
        //создали station3g.RegisteredPhones3g
        //создали station3g.ProcessCall
        //-------------------------------------------------------------------------------------------------
        SimplePhone phone1 = new ("123412341234124", "+79828019521");
        //station1.RegisteredPhones.Add(phone1); - станция зарегала сама, а надо чтоб телефон сам при объявлении зарегался, для этого и создали функцию ConnectToBase
        //public string Imei
        //public string SimNumber
        //public IStation BaseStation
        //public List<Abonent> Abonents
        //public void ConnectToBase(IStation station)
        //public void Call(string contactNumber)
        //public void Call(Abonent abonent)
        Phone3G phone3 = new ("332412347688664", "+79828019523");
        //public string Imei
        //public string SimNumber
        //public IStation BaseStation
        //public List<Abonent> Abonents
        //public void ConnectToBase(IStation station)
        //public void Call(string contactNumber)
        //public void Call(Abonent abonent)
        //-------------------------------------------------------------------------------------------------
        phone1.ConnectToBase(station3g);
        phone3.ConnectToBase(station3g);
        phone1.ConnectToBase(station1);
        phone3.ConnectToBase(station1);// если убрать валидацию RegisteredPhones в SimplePhone.cs то ловим исключение в SimpleStation.cs 
        //phone3.ConnectToBase(station3g);// если убрать валидацию RegisteredPhones в SimplePhone.cs то ловим исключение в Station3G.cs
        phone1.Call("+79828019521");
        //Abonent abonent1 = new Abonent("Vladimir", "+79828019521");
        //phone3.Call(abonent1);
    }
}
