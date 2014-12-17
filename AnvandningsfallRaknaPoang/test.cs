using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvandningsfallRaknaPoang
{
    class test
    {
        public void testMain() // startar de olika testsviterna
        {
            testCount(); // startar testsviten för klassen count

            testLogin(); // startar testsviten för klassen login

            Console.ReadKey();
        }
        static void testCount() // testsviten för uträkning
        {
                if(counttest1()) // startar testfallet counttest1 som returnerar true eller false
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Resultatet blev som det förväntade resultatet - Uträkningen fungerar! Sorteringen fungerar också - annars skulle uträkningen bli fel\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uträkningen fungerar inte korrekt...");
                    Console.ResetColor();
                }

        }
        static void testLogin()
        {
                if (logintest1()) //startar testfallet logintest1 som returnerar true eller false. If satsen skriver ut resultatet.
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Inloggningen misslyckades med ogiltigt användarnamn - testet lyckat\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("inloggningen lyckades med ogiltigt användarnamn - testet misslyckades\n");
                    Console.ResetColor();
                }

                if (logintest2())//startar testfallet logintest2 som returnerar true eller false. If satsen skriver ut resultatet.
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Inloggningen misslyckades med ogiltigt lösenord - testet lyckat\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("inloggningen lyckades med ogiltigt lösenord - testet misslyckades\n");
                    Console.ResetColor();
                }

                if (logintest3())//startar testfallet logintest3 som returnerar true eller false. If satsen skriver ut resultatet.
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Inloggningen misslyckades med ogiltigt användarnamn och lösenord - testet lyckat\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("inloggningen lyckades med ogiltigt användarnamn och lösenord - testet misslyckades\n");
                    Console.ResetColor();
                }

                if (logintest4())//startar testfallet logintest4 som returnerar true eller false. If satsen skriver ut resultatet.
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Inloggningen lyckades med giltigt användarnamn och lösenord - testet lyckat\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("inloggningen lyckades inte med giltigt användarnamn och lösenord - testet misslyckades\n");
                    Console.ResetColor();
                }


                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck valfri tangent för fortsätta...");
                Console.ResetColor();
        }

        static bool counttest1() //testfall 1 för uträkning. 
        {
            Console.WriteLine("count TEST1 - Uträkning av poäng");
            count count = new count();
            int[] array; //array skapas 
            array = new int[5] { 2, 3, 5, 4, 1 }; //hårdkodar in värden i arrayen
            decimal expectedAverage = 3; // medelpoängen som förväntas. ( (2+3+4)/3 = 3 ). Största och minsta värdena räknas inte med som beskrivet i problembeskrivningen.
            decimal averageResult = count.average(array); // sätter avarageResult till det som returneras av metoden average i klassen count. 

            Console.WriteLine("Det förväntade resultatet är {0} funktionen returnerade {1}", expectedAverage, averageResult);

            if (expectedAverage == averageResult) //om resultatet blir det resultat som förväntades...
            {

                return true; // ...så returneras true
            }
            else
            {
                return false;
            }
        }
        static bool logintest1() //testfall 1 för inloggning
        {
            Console.WriteLine("login TEST1 - inloggning med fel användarnamn men rätt lösenord");
            login logintest = new login();
            try
            {
                logintest.loggingIn("fel","admin"); //skickar in två strängar till metoden som kollar om det är korrekt kombination. Är det inte det kastas ett undantag.
                return false;//kastas inte undantag returneras false
            }
            catch
            {
                return true;
            }
        }
        static bool logintest2()
        {
            Console.WriteLine("login TEST2 - inloggning med fel lösenord men rätt användarnamn");
            login logintest = new login();
            try
            {
                logintest.loggingIn("admin", "fel"); //skickar in två strängar till metoden som kollar om det är korrekt kombination. Är det inte det kastas ett undantag.
                return false;//kastas inte undantag returneras false
            }
            catch
            {
                return true;
            }
        }
        static bool logintest3()
        {
            Console.WriteLine("login TEST3 - inloggning med fel lösenord och användarnamn");
            login logintest = new login();
            try
            {
                logintest.loggingIn("fel", "fel"); //skickar in två strängar till metoden som kollar om det är korrekt kombination. Är det inte det kastas ett undantag.
                return false; //kastas inte undantag returneras false
            }
            catch
            {
                return true;
            }
        }
        static bool logintest4()
        {
            Console.WriteLine("login TEST4 - inloggning med rätt inloggningskombination");
            login logintest = new login();
            try
            {
                logintest.loggingIn("admin", "admin"); //skickar in två korrekta strängar. Metoden kollar om det man skickar in är korrekt kombination.
                return true; //kastas inte undantag returneras true
            }
            catch
            {
                return false;
            }
        }


    }
}
