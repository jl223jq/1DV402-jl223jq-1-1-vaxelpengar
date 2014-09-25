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
            uint ErhålletBelopp;
            double Totalsumma;
            double Öresavrundning;
            uint Avrundadtotalsumma;
            uint Tillbaka;
            uint AntaletFemhundralappar;
            uint AntaletHundralappar;
            uint AntaletFemtiolappar;
            uint AntaletTjugor;
            uint AntaletTior;
            uint AntaletFemkronor;
            uint AntaletEnkronor;


            // Här felhanterar jag de fallen då användaren skrivit in ogiltiga värden.
            while (true)
            {
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    Totalsumma = double.Parse(Console.ReadLine());
                    if (Totalsumma < 1)
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
            while (true)
            {
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    ErhålletBelopp = uint.Parse(Console.ReadLine());
                    if (ErhålletBelopp < Totalsumma)
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

            Avrundadtotalsumma = (uint)Math.Round(Totalsumma);
            Öresavrundning = Avrundadtotalsumma - Totalsumma;
            Tillbaka = ErhålletBelopp - Avrundadtotalsumma;

            // Kvittot
            Console.Write("\nKVITTO\n");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Totalt          : {0:c}", Totalsumma);
            Console.WriteLine("Öresavrundning  : {0:c}", Öresavrundning);
            Console.WriteLine("Att betala      : {0:c}", Avrundadtotalsumma);
            Console.WriteLine("Kontant         : {0:c}", ErhålletBelopp);
            Console.WriteLine("Tillbaka        : {0:c}", Tillbaka);
            Console.WriteLine("-----------------------------");

            AntaletFemhundralappar = Tillbaka / Femhundra;
            Tillbaka = Tillbaka % Femhundra;
            AntaletHundralappar = Tillbaka / Hundra;
            Tillbaka = Tillbaka % Hundra;
            AntaletFemtiolappar = Tillbaka / Femtio;
            Tillbaka = Tillbaka % Femtio;
            AntaletTjugor = Tillbaka / Tjugo;
            Tillbaka = Tillbaka % Tjugo;
            AntaletTior = Tillbaka / Tio;
            Tillbaka = Tillbaka % Tio;
            AntaletFemkronor = Tillbaka / Femkrona;
            Tillbaka = Tillbaka % Femkrona;
            AntaletEnkronor = Tillbaka / Enkrona;

            // Här ser jag till att kvittot enbart skriver ut sedlarna som används.
            if (AntaletFemhundralappar != 0)
            {
                Console.WriteLine("500-lappar      : {0}", AntaletFemhundralappar);
            }
            if (AntaletHundralappar != 0)
            {
                Console.WriteLine("100-lappar      : {0}", AntaletHundralappar);
            }
            if (AntaletFemtiolappar != 0)
            {
                Console.WriteLine("50-lappar       : {0}", AntaletFemtiolappar);
            }
            if (AntaletTjugor != 0)
            {
                Console.WriteLine("20-lappar       : {0}", AntaletTjugor);
            }
            if (AntaletTjugor != 0)
            {
                Console.WriteLine("10-kronor       : {0}", AntaletTior);
            }
            if (AntaletFemkronor != 0)
            {
                Console.WriteLine("5-kronor        : {0}", AntaletFemkronor);
            }
            if (AntaletEnkronor != 0)
            {
                Console.WriteLine("1-kronor        : {0}", AntaletEnkronor);
            }
        }
    }

}