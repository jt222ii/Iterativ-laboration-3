using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnvandningsfallRaknaPoang
{
    class Program
    {
        static void Main()
        {

            log(false);

        }

        static void log(bool loggedin)
        {
            Console.Clear();
            login login = new login();
            count count = new count();
            while (loggedin == false)
            {
                try
                {
                    string userN = userStringInput("Ange användarnamnet: ");
                    string pass = "";
                    Console.Write("Ange lösenordet: "); // Den här delen gjorde jag först exakt som när jag skrev in användarnamnet. Kom på att lösenordet ska inte vara synligt när man skriver
                    ConsoleKeyInfo key;                 // och därför tog jag hjälp från: http://stackoverflow.com/a/3404522 för att visa asterisker istället för vad man tryckte på
                    do
                    {
                        key = Console.ReadKey(true);

                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                        {
                            pass += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                            {
                                pass = pass.Substring(0, (pass.Length - 1));
                                Console.Write("\b \b");
                            }
                        }
                    }
                    while (key.Key != ConsoleKey.Enter);

                    login.loggingIn(userN, pass);
                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Fel användarnamn eller lösenord... försök igen!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
            menu();
            int userChoice;
            userChoice = userInput("\nVälj ett menyalternativ inom 0-10!\n0. Lägg till poäng\n1-10 stänger av!\n");
            if (userChoice == 0)
            {
                int numberOfJudges = userInput("Ange antalet domare/tal från domarna (måste vara fler än 2): ");
                if (numberOfJudges < 2)
                {
                    Console.WriteLine("Du angav inte fler än 2 domare. Har ni tillräckligt med domare för att få giltiga resultat? Stänger av programmet");
                    Thread.Sleep(1500);
                    return;
                }
                int[] pointArray;
                pointArray = new int[numberOfJudges];
                for (int i = 0; i < numberOfJudges; i++)
                {
                    Console.Clear();
                    pointArray[i] = userInput(string.Format("ange poäng från domare {0}: ", i + 1));
                }
                decimal averagePoints = count.average(pointArray);
                Console.WriteLine("Medelpoängen för lagets genomförande är: {0:f2}", averagePoints);
            }
            else
            {
                return;
            }
            int restart = userInput("Vad vill du göra?\n0. Ny uträkning\n1-10 stänger av...\n");
            if (restart == 0)
            {
                log(true);
            }
        }
        static void menu()
        {
            //Menyn används inte ännu fixar jag textdokumentet etc så ska det här gå att välja lag
            // switch case för lagen typ...
                           
        }
        static int userInput(string prompt)
        {
            while (true)
            {
                try
                {
                    //Console.Clear();
                    Console.Write(prompt);
                    int b = int.Parse(Console.ReadLine());
                    if (b<0 || b>10)
                    { throw new ArgumentOutOfRangeException(); }
                    else
                    return b;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("något blev fel... skrev du in ett nummer inom 1-10?");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
        }
        static string userStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write(prompt);
                    string a = Console.ReadLine();
                    return a;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("något blev fel...");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
