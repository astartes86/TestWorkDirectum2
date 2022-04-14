using TestWorkDirectum.Interfaces;
using TestWorkDirectum.Structs;
using System.Collections.Generic;
using System;

namespace TestWorkDirectum.Phones
{
    internal class SimplePhone : IPhone //класс реализует интерфейс, обязуется выполнить все методы интерфейса! через запятую можно выполнить другой интерфейс
    {
        public SimplePhone(string codeImei, string sim)
        {
            Imei = codeImei;
            //TODO: проверка на то что это именно номер телефона.
            SimNumber = sim;
            mess_ph();
        }

        public virtual void mess_ph()
        {
            Console.WriteLine($"И был создан телефон с номером SIM: '{SimNumber}' и IMEI '{Imei}'.");
        }

        //описываем имей 
        public string Imei { get; set; }

        //описываем номер сим = номер телефона
        public string SimNumber { get; set; }

        //описываем станцию
        public IStation BaseStation { get; set; }

        //описываем справочник
        List<Abonent> abonents = new List<Abonent>();                                 //для коллекции всегда надо прописать аксессоры!
        public List<Abonent> Abonents //{ get; set; }
        {
            get
            {
                return abonents;
            }

            set
            {
                abonents = value;
            }
        }

        //функция коннектит имей к станции, то есть регистрирует
        public virtual void Registration(IStation station)
        {
            BaseStation = station;      //создаем локальную станцию через интерфейс - то есть она либо 3ж либо обычная - и привязываем ее к конкретно указанной руками при вызове
            station.RegisterPhone(this);//эта станция вносит телефон в список зареганых на этой станции
        }

        public void Call(string contactNumber)
        {
            //TODO: Перед звонком сделать проверку что телефон законнекчен к станции.
            //Console.WriteLine($"Абонент '{this.SimNumber}' пытается вызвать абонента '{contactNumber}'");
            var result = BaseStation?.ProcessCall(this); //зарегистрирован на станции? если базовая станция не создана - вызов не происходит
            if (result.Equals(true))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Телефон '{this.SimNumber}': идет соединение с абонентом '{contactNumber}'.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Телефон '{this.SimNumber}': не удалось вызвать абонента '{contactNumber}' по причине отсутствия регистрации на станции.");
                Console.ResetColor();
            }
        }

        public void Call(Abonent abonent)
        {
            bool nocall = false;
            foreach (var ab in Abonents)
                if (ab.NameAbonent == abonent.NameAbonent)
                {
                    Call(ab.PhoneNumber);
                    nocall = true;
                    return;
                }
                else
                {
                    nocall = false;
                }
            if (!nocall)
                Console.WriteLine($"Абонент '{abonent.NameAbonent}' не найден в справочнике контактов телефона с SIM номером '{this.SimNumber}'.");
        }

        //функция регистрирует телефоны
        public void CollectNumber(Abonent abonent)
        {
            Abonents.Add(abonent);
            Console.WriteLine($"Телефон '{this.SimNumber}': Абонент с номером: '{abonent.PhoneNumber}' и номером '{abonent.NameAbonent}' был добавлен в справочник.");
        }
    }
}
