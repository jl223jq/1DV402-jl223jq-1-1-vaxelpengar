using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaxelpengar
{
    class Program
    {
        const uint Femhundra = 500;
        const uint Hundra = 100;
        const uint Femtio = 50;
        const uint Tjugo = 20;
        const uint Tio = 10;
        const uint Femkrona = 5;
        const uint Enkrona = 1;
        static void Main(string[] args)
        {
            uint erhålletbelopp;
            double totalsumma;
            double oresavrundning;
            uint avrundadtotalsumma;
            uint tillbaka;
            uint antaletfemhundralappar;
            uint antalethundralappar;
            uint antaletfemtiolappar;
            uint antalettjugor;
            uint antalettior;
            uint antaletfemkronor;
            uint antaletenkronor;


            // Här felhanterar jag de fallen då användaren skrivit in ogiltiga värden.
            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    totalsumma = double.Parse(Console.ReadLine());
                    if (totalsumma < 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Snåljåp! Vi accepterar inte så låga vården här.");
                        Console.ResetColor();
                        return;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inga bokstäver är tillåtna, använd bara siffror tack.");
                    Console.ResetColor();
                }
            }
            
            avrundadtotalsumma = (uint)Math.Round(totalsumma);

            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    erhålletbelopp = uint.Parse(Console.ReadLine());
                    if (erhålletbelopp < avrundadtotalsumma)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Inte tillräckligt mycket betalat.");
                        Console.ResetColor();
                        return;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inga bokstäver är tillåtna, använd bara siffror tack.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("För stort tal, din plånbok är större än vi kan hantera.");
                    Console.ResetColor();

                }
            }

            oresavrundning = avrundadtotalsumma - totalsumma;
            tillbaka = erhålletbelopp - avrundadtotalsumma;

            // Kvittot
            Console.Write("\nKVITTO\n");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Totalt          : {0:c}", totalsumma);
            Console.WriteLine("Öresavrundning  : {0:c}", oresavrundning);
            Console.WriteLine("Att betala      : {0:c}", avrundadtotalsumma);
            Console.WriteLine("Kontant         : {0:c}", erhålletbelopp);
            Console.WriteLine("Tillbaka        : {0:c}", tillbaka);
            Console.WriteLine("-----------------------------");

            antaletfemhundralappar = tillbaka / Femhundra;
            tillbaka = tillbaka % Femhundra;
            antalethundralappar = tillbaka / Hundra;
            tillbaka = tillbaka % Hundra;
            antaletfemtiolappar = tillbaka / Femtio;
            tillbaka = tillbaka % Femtio;
            antalettjugor = tillbaka / Tjugo;
            tillbaka = tillbaka % Tjugo;
            antalettior = tillbaka / Tio;
            tillbaka = tillbaka % Tio;
            antaletfemkronor = tillbaka / Femkrona;
            tillbaka = tillbaka % Femkrona;
            antaletenkronor = tillbaka / Enkrona;

            // Här ser jag till att kvittot enbart skriver ut sedlarna som används.
            if (antaletfemhundralappar != 0)
            {
                Console.WriteLine("500-lappar      : {0}", antaletfemhundralappar);
            }
            if (antalethundralappar != 0)
            {
                Console.WriteLine("100-lappar      : {0}", antalethundralappar);
            }
            if (antaletfemtiolappar != 0)
            {
                Console.WriteLine("50-lappar       : {0}", antaletfemtiolappar);
            }
            if (antalettjugor != 0)
            {
                Console.WriteLine("20-lappar       : {0}", antalettjugor);
            }
            if (antalettjugor != 0)
            {
                Console.WriteLine("10-kronor       : {0}", antalettior);
            }
            if (antaletfemkronor != 0)
            {
                Console.WriteLine("5-kronor        : {0}", antaletfemkronor);
            }
            if (antaletenkronor != 0)
            {
                Console.WriteLine("1-kronor        : {0}", antaletenkronor);
            }
        }
    }

}