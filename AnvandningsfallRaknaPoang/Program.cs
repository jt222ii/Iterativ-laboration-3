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

            log(false);

        }

        static void log(bool loggedin) //Detta är funktionen som kör det mesta annat. När denna startas skickar jag med true eller false för att se om man är "inloggad" eller inte. 
        {                               // är man inte inloggad får man logga in lösenord och användarnamn är båda "admin"
            Console.Clear();
            login login = new login();
            count count = new count();

            login.userLogInput(loggedin);//startar klassen "login" och kör userLogInput där man skriver in användarnamn och lösenord. boolean "loggedin" skickas med för att se om man är inloggad eller inte.

            int userChoice;
            userChoice = userInput("\nVälj ett menyalternativ inom 0-10!\n0. Räkna poäng\n1-10 stänger av!\n");
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
                for (int i = 0; i < numberOfJudges; i++) // här skriver man in alla poängen till arrayen.
                {
                    Console.Clear();
                    pointArray[i] = userInput(string.Format("ange poäng från domare {0}: ", i + 1));
                }
                decimal averagePoints = count.average(pointArray); //räknar ut medelpoängen för arrayen. 
                Console.WriteLine("Medelpoängen för lagets genomförande är: {0:f2}", averagePoints); //skriver ut medelpoängen.
            }
            else
            {
                return;
            }
            int restart = userInput("Vad vill du göra?\n0. Ny uträkning\n1-10 stänger av...\n"); //Frågar om man vill göra en ny uträkning eller stänga av
            if (restart == 0)
            {
                log(true); //startar log än en gång. Denna gången skickas "true" med eftersom man redan är "inloggad"
            }
        }

        static int userInput(string prompt) //kallas när man ska skriva in något som ska skrivas i nummer
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
    }
}
