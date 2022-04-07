using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkDirectum.Interfaces;

namespace TestWorkDirectum.Phones
{
    internal class PhoneList : List<IPhone>
    {
        public void Add(string codeImei, string sim, string Flag3g)        //переопределить Add не получилось потому создали свой    
        {
            if (codeImei != "" && codeImei.Length == 15 && IsLetterContains(codeImei) && sim != "" && sim.Length == 12 && sim[0] == '+' && IsLetterContainsFrom(sim))
            {
                if (Flag3g != "3g")
                    this.Add(new SimplePhone(codeImei, sim));
                else
                    this.Add(new Phone3G(codeImei, sim));
            }
            else
            {
                Console.WriteLine("IMEI не может быть пустым, должен содержать 15 цифр.\n" +
                                      "Sim не может быть пустым, номер должен начинаться с + и содержать 10 цифр.\n" +
                                      "Телефон не создан");
                Console.WriteLine("Нажмите g для рандомной генерации номера");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();
                if (key == ConsoleKey.G)                                    //go auto
                {
                    codeImei = RndStr(15);
                    sim = '+' + RndStr(11);
                    if (Flag3g != "3g")
                        this.Add(new SimplePhone(codeImei, sim));
                    else
                        this.Add(new Phone3G(codeImei, sim));
                }
            }
        }

        private bool IsLetterContains(string input)
        {
            foreach (char c in input)
                if (!Char.IsNumber(c))
                    return false;                           //ошибка: нашли не число - выходим с false
            return true;
        }

        private bool IsLetterContainsFrom(string input)
        {
            foreach (char c in input.Substring(1))
                if (!Char.IsNumber(c))
                    return false;                           //ошибка: нашли не число - выходим с false
            return true;
        }

        private static string RndStr(int len)
        {
            string s = "", symb = "0123456789";
            Random rnd = new Random();

            for (int i = 0; i < len; i++)
                s += symb[rnd.Next(0, symb.Length)];
            return s;
        }
    }
}