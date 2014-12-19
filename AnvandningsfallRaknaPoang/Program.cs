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
        static void Main() // har denna ungefär som en init funktion så jag sedan kan "simulera" att man är inloggad.
        {
            test test = new test();
            test.testMain();
            integrationsTest integTest = new integrationsTest();
            integTest.integrationstester();

            log(false);
        }
        
        static void log(bool loggedin) //Detta är funktionen som kör det mesta annat. När denna startas skickar jag med true eller false för att se om man är "inloggad" eller inte. 
        {                               // är man inte inloggad får man logga in lösenord och användarnamn är båda "admin"
            Console.Clear();
            
            login login = new login();
            login.Isloggedin = loggedin;
            count count = new count();

            if (login.Isloggedin == false)
            {
                login.userLogInput();//startar klassen "login" och kör userLogInput där man skriver in användarnamn och lösenord. boolean "loggedin" skickas med för att se om man är inloggad eller inte.
            }

            if (login.Isloggedin) //Isloggedin returnerar det privata fältet _isloggedin som är true eller false beroende på om man är inloggad eller ej
            {
                int userChoice;
                userChoice = userInput("Välj ett menyalternativ!\n0. Räkna poäng\nAnnan siffra stänger av!\n");
                if (userChoice == 0) //finns just nu bara 1 menyval. Väljer man 0 så har man valt enda funktionen än så länge: räkna poäng.
                {
                    int numberOfJudges = userInput("Ange antalet domare/tal från domarna (måste vara fler än 2): ");
                    if (numberOfJudges < 2) // det måste vara fler än 2 domare för att uträkningen ska fungera eftersom man tar bort det största och minsta talet innan uträkningen påbörjas.
                    {
                        Console.WriteLine("Du angav inte fler än 2 domare. Har ni tillräckligt med domare för att få giltiga resultat? Stänger av programmet");
                        Thread.Sleep(1500);
                        return;
                    }
                    int[] pointArray; // array som innehåller alla poäng
                    pointArray = new int[numberOfJudges];
                    int a;
                    for (int i = 0; i < numberOfJudges; i++) // här skriver man in alla poängen till arrayen.
                    {
                        Console.Clear();
                        a = userInput(string.Format("ange poäng från domare {0} (Poängskalan är 0-10): ", i + 1));
                        if (a < 0 || a > 10)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Giltig poäng är 0-10... försök igen");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            i--;
                        }
                        else
                        {
                            pointArray[i] = a;
                        }
                    }
                    decimal averagePoints = count.average(pointArray); //räknar ut medelpoängen för arrayen. 
                    Console.WriteLine("Medelpoängen för genomförandet är: {0:f2}", averagePoints); //skriver ut medelpoängen.
                }
                else
                {
                    return;
                }
            }
            else
            { Console.WriteLine("Inloggningen misslyckades"); }
            int restart = 1337; 
            if (login.Isloggedin == false)
            { restart = userInput("Vad vill du göra?\n0. Försöka igen\n1. Försöka igen\n- Annan siffra stänger av...\n"); } //är man inte inloggad får man välja om man vill försöka igen eller inte
            else if (login.Isloggedin == true) //är man inloggad Frågar om man vill göra en ny uträkning eller stänga av
            { restart = userInput("Vad vill du göra?\n0. Ny uträkning\n1. Logga ut\n- Annan siffra stänger av...\n"); }
            if (restart == 0)
            {
                if(login.Isloggedin == true)
                {
                log(login.Isloggedin); //startar log än en gång. Denna gången skickas "true" med eftersom man redan är "inloggad"
                }
                else
                    log(login.Isloggedin);
            }
            else if (restart == 1)
            {
                login.logOut();
                log(login.Isloggedin);
            }
        }

        public static int userInput(string prompt) //kallas när man ska skriva in något som ska skrivas i nummer
        {
            while (true)
            {
                try
                {
                    //Console.Clear();
                    Console.Write(prompt);
                    int b = int.Parse(Console.ReadLine());
                    return b;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("något blev fel... skrev du in ett nummer?");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
