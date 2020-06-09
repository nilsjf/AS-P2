using System;
using System.Collections.Generic;
using Gefangenendilemma.Basis;

namespace Gefangenendilemma
{
    /// <summary>
    /// Diese Klasse können Sie beliebig umschreiben, jenachdem welche Tasks sie erledigen.
    /// </summary>
    class VerwaltungProgramm
    {
        /// <summary>
        /// Diese Liste(Collection) enthält alle Gefangene/Strategien
        /// </summary>
        public static List<BasisStrategie> _strategien;
        
        static void Main(string[] args)
        {
            //bekannt machen der ganzen strategien
            _strategien = new List<BasisStrategie>();
            _strategien.Add(new GrollStrategie());
            _strategien.Add(new VerrateImmerStrategie());
            _strategien.Add(new Strategie1());
            _strategien.Add(new Strategie2());
            _strategien.Add(new Strategie3());
            
            string eingabe;
            do
            {
                // Begrüßung
                Console.WriteLine("Willkommen zum Gefangenendilemma");
                Console.WriteLine("0 - Verhör zwischen 2 Strategien");
                Console.WriteLine("1 - Verhör zwischen 2 Strategien in 9 Runden (E2)");
                Console.WriteLine("2 - Benutzer gegen Strategie (E4)");
                Console.WriteLine("3 - Turnier mit allen Strategien (T1)");
                Console.WriteLine("X - Beenden");
                
                // Eingabe
                Console.Write("Treffen Sie ihre Option: ");
                eingabe = Console.ReadLine();

                // Auswerten der Eingabe
                switch (eingabe.ToLower())
                {
                    case "0":
                        Gefangene2Strats();
                        break;
                    case "1":
                        Gefangene9Spiele();
                        break;
                    case "2":
                        GefangeneBenutzer();
                        break;
                    case "3":
                        GefangeneTurnier();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine($"Eingabe {eingabe} nicht erkannt.");
                        break;
                }
            } while (!"x".Equals(eingabe?.ToLower()));
        }

        /// <summary>
        /// Fragt 2 Strategien, Länge und Schwere ab.
        /// </summary>
        static void Gefangene2Strats()
        {
            int st1, st2;
            int runde, schwere;
            
            Console.WriteLine("Willkommen zum Verhör zwischen 2 Strategien");
            for (int i = 0; i < _strategien.Count; i++)
            {
                Console.WriteLine($"{i} - {_strategien[i].Name()}");
            }
            Console.WriteLine("Wählen Sie ihre 2 Strategien:");
            st1 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 1. Strategie", 0, _strategien.Count);
            st2 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 2. Strategie", 0, _strategien.Count);
            runde = VerwaltungKram.EingabeZahlMinMax("Wie viele Runden sollen diese verhört werden?", 1, 101);
            schwere = VerwaltungKram.EingabeZahlMinMax("Wie schwer sind die Verstöße? (0=leicht, 1=mittel, 2=schwer)", 0, 4);
            
            //holt die beiden Strategien aus der Collection.
            BasisStrategie strategie1 = VerwaltungProgramm._strategien[st1];
            BasisStrategie strategie2 = VerwaltungProgramm._strategien[st2];

            (int punkte1, int punkte2) = VerhoerVerwaltung.Verhoer(strategie1, strategie2, runde, schwere);

            //ausgabe
            Console.WriteLine($"{strategie1.Name()} hat {punkte1} Punkte erhalten.");
            Console.WriteLine($"{strategie2.Name()} hat {punkte2} Punkte erhalten.");
            if (punkte1 < punkte2)
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie1.Name());
            } 
            else
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie2.Name());
            }
        }

        static void Gefangene9Spiele()
        {
            Console.WriteLine("Willkommen zum Verhör zwischen 2 Strategien in 9 Runden");
        }

        static void GefangeneBenutzer()
        {
            Console.WriteLine("Willkommen zum Verhör zwischen Ihnen und einer Strategie");
        }

        static void GefangeneTurnier()
        {
            Console.WriteLine("Willkommen zum Turnier mit allen Strategien");
        }
    }
}