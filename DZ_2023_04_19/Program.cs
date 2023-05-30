using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_work_19._04._2023_1_
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Практическая 01");
            int counter = 0;
            string input;
            for (int i = 0; i < args.Length; i++)
            {
                input = args[i];
                Regex regex = new Regex(@"(-){0,1}(\d){1,}([\.\,]\d{1,}){0,}", RegexOptions.IgnoreCase);
                MatchCollection matchFind = regex.Matches(input);

                foreach (var item in matchFind)
                {
                    Console.WriteLine($"Совпадение номер {counter} {item}");
                    counter++;
                }
            }
            Console.ReadKey();

            Console.WriteLine("Практическая 02");
            string emailString;
            string numberPhone;
            string nameUser;
            Regex regexemail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", RegexOptions.IgnoreCase);
            Regex regexphone = new Regex(@"(?:\+|\d)[\d\-\(\) ]{9,}\d", RegexOptions.IgnoreCase);
            Regex regexname = new Regex(@"^[a-zA-Z][a-zA-Z0]{3,10}$", RegexOptions.IgnoreCase);


            Console.ReadLine();
            foreach (var arg in args)
            {
                Match matchCollection1 = regexemail.Match(arg);
                Match matchCollection2 = regexphone.Match(arg);
                Match matchCollection3 = regexname.Match(arg);

                if (matchCollection3.Success)
                {
                    Console.WriteLine($"Имя {matchCollection3.Value}");
                    matchCollection3 = matchCollection2.NextMatch();
                }

                if (matchCollection2.Success)
                {
                    Console.WriteLine($"Номер мобильного телефона {matchCollection2.Value}");
                    matchCollection2 = matchCollection1.NextMatch();
                }

                if (matchCollection1.Success)
                {
                    Console.WriteLine($"Электронная почта {matchCollection1.Value}");
                }
            }
        }
    }
}
