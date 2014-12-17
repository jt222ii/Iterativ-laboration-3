using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AnvandningsfallRaknaPoang
{
    class login //Denna klass ska kolla så att lösenordet/användarnamnet är en godkänd kombination. Just nu finns det endast en godkänd kombination.
    {
        private string _userN = "admin"; //privat fält som innehåller användarnamnet
        private string _pass = "admin"; //privat fält som innehåller lösenordet

        public void loggingIn(string userN, string pass)
        {
            if (userN != _userN || pass != _pass) // om det man skrev in inte stämmer överens med fälten kastas undantag...
            {                    
                throw new ArgumentException();
            }
            else //...annars har man lyckats med inloggningen och man skickas tillbaka
                    return;
        }

        public void userLogInput(bool loggedin)
        {
            Program input = new Program();
            while (loggedin == false)
            {
                try
                {
                    Console.Write("Ange användarnamnet(admin): ");
                    string userN = Console.ReadLine(); //LÖSENORD OCH ANVÄNDARNAMN ÄR BÅDA "admin"
                    string pass = "";
                    Console.Write("Ange lösenordet(admin): "); // Den här delen gjorde jag först exakt som när jag skrev in användarnamnet. Kom på att lösenordet ska inte vara synligt när man skriver
                    ConsoleKeyInfo key;                 // och därför tog jag hjälp från: http://stackoverflow.com/a/3404522 för att visa asterisker istället för vad man tryckte på
                    do
                    {
                        key = Console.ReadKey(true);

                        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) //man ska inte kunna skriva in enters eller backspace
                        {
                            pass += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Backspace && pass.Length > 0) //om man trycker backspace tar man bort en bokstav och en mindre asterisk visas.
                            {
                                pass = pass.Substring(0, (pass.Length - 1));
                                Console.Write("\b \b");
                            }
                        }
                    }
                    while (key.Key != ConsoleKey.Enter); // trycker man enter "skickar" man in lösenordet

                    loggingIn(userN, pass); //skickar användarnamnet och lösenordet som man skrev in till "loggingIn" för att se om man skrev in en giltig kombination.
                    break; //bryter loopen
                }
                catch //fångar undantag. Undantag kastas i "login" om man skrev fel användarnamn och/eller lösenord
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nFel användarnamn eller lösenord... försök igen!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
