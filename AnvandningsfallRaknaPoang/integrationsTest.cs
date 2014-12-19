using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvandningsfallRaknaPoang
{
    class integrationsTest
    {
        public void integrationstester()
        {
            Console.Clear();
            count countTest = new count();

            if (loggedintest1()) //startar testfallet logintest1 som returnerar true eller false. If satsen skriver ut resultatet.
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_isloggedin är false - testet lyckat!\n");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("_isloggedin är true fastän det inte har ändrats. Du är inloggad utan att ha loggat in.... något är fel");
                Console.ResetColor();
            }

            if (loggedintest2()) //startar testfallet logintest1 som returnerar true eller false. If satsen skriver ut resultatet.
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_isloggedin är true efter inloggning - testet lyckat!\n");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("_isloggedin är false efter inloggning. Trots rätt användarnamn/lösenord så blir du inte inloggad");
                Console.ResetColor();
            }

            if (loggedintest3()) //startar testfallet logintest1 som returnerar true eller false. If satsen skriver ut resultatet.
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_isloggedin är false efter misslyckad inloggning - testet lyckat!\n");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("_isloggedin är true efter misslyckad inloggning. Trots fel användarnamn/lösenord så blir du inloggad");
                Console.ResetColor();
            }
            if (loggedintest4()) //startar testfallet logintest1 som returnerar true eller false. If satsen skriver ut resultatet.
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_isloggedin är false efter utloggning - testet lyckat!\n");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("_isloggedin är true efter utloggningloggning. Trots att man ska bli utloggad förblir man inloggad!");
                Console.ResetColor();
            }


            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nTryck valfri tangent för att starta programmet");
            Console.ResetColor();
            Console.ReadKey();
        }

        static bool loggedintest1() //Anropar login.Isloggedin för att se om man är inloggad.
        {
            Console.WriteLine("login INTEGRATIONSTEST1 - status på _isloggedin när man inte loggat in");
            login loginTest = new login();
            try
            {
                if (loginTest.Isloggedin == false)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {

                return false;
            }
        }
        static bool loggedintest2() // detta test loggar först in med korrekt parametrar och kollar sedan så att "_isloggedin" är true eftersom man är inloggad
        {
            Console.WriteLine("login INTEGRATIONSTEST2 - status på _isloggedin efter lyckad inloggning");
            login loginTest = new login();
            try
            {
                loginTest.loggingIn("admin", "admin");
                if (loginTest.Isloggedin == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch 
            {
                return false;
            }

        }
        static bool loggedintest3() 
        {
            Console.WriteLine("login INTEGRATIONSTEST3 - status på _isloggedin efter misslyckad inloggning");
            login loginTest = new login();
            try
            {
                loginTest.loggingIn("admin", "fel");
                if (loginTest.Isloggedin == false)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return true;
            }

        }
        static bool loggedintest4()
        {
            Console.WriteLine("login INTEGRATIONSTEST4 - status på _isloggedin efter utloggning");
            login loginTest = new login();

            loginTest.loggingIn("admin", "admin"); // loggar in med korrekta inloggningsuppgifter
            loginTest.logOut();          //kör logOut som ska sätta inloggningstatusen till false
            if (loginTest.Isloggedin == false) 
            {
                return true;
            }
            else
                return false;

        }
    }
}
