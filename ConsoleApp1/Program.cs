﻿using TestWorkDirectum.Phones;
using TestWorkDirectum.Stations;
using TestWorkDirectum.Structs;

namespace TestWorkDirectum;
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Добро пожаловать в программу тестового задания 'Cтанции и телефоны'.");

        SimpleStation station1= new ();
        Station3G station3g = new ();
        SimplePhone phone1 = new ("123412341234124", "+79828019521");
        SimplePhone phone2 = new ("223412347688664", "+79828019522");
        Phone3G phone3 = new ("332412347688664", "+79828019523");
        phone1.ConnectToBase(station1);
        phone2.ConnectToBase(station1);
        phone3.ConnectToBase(station3g);
        phone1.Call("+79828019521");
        Abonent abonent1 = new Abonent("Vladimir", "+79828019521");
        phone3.Call(abonent1);
    }
}
