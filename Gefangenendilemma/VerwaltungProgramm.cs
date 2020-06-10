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
                Console.WriteLine("Willkommen zum Gefangenendilemma!");
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
            int runde, schwere;
            
            Console.WriteLine("Willkommen zum Verhör zwischen 2 Strategien!");
            
            (BasisStrategie strategie1, BasisStrategie strategie2) = Auswahl2Strats();
            runde = VerwaltungKram.EingabeZahlMinMax("Wie viele Runden sollen diese verhört werden?", 1, 101);
            schwere = VerwaltungKram.EingabeZahlMinMax("Wie schwer sind die Verstöße? (0=leicht, 1=mittel, 2=schwer)", 0, 3);

            (int punkte1, int punkte2) = VerhoerVerwaltung.Verhoer(strategie1, strategie2, runde, schwere);

            if (punkte1 < punkte2)
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie1.Name());
            } 
            if (punkte1 > punkte2)
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie2.Name());
            }
            if (punkte1 == punkte2)
            {
                Console.WriteLine("Unentschieden.");
            }
        }

        static void Gefangene9Spiele()
        {
            int punkte1final = 0, punkte2final = 0;

            Console.WriteLine("Willkommen zum Verhör zwischen 2 Strategien in 9 Runden!");
            
            (BasisStrategie strategie1, BasisStrategie strategie2) = Auswahl2Strats();

            for(int i = 0; i < 3; i++)
            {
                (int punkte1, int punkte2) = VerhoerVerwaltung.Verhoer(strategie1, strategie2, 5, i);
                punkte1 = punkte1 * 20;
                punkte2 = punkte2 * 20;
                punkte1final += punkte1;
                punkte2final += punkte2;
            }
            for(int i = 0; i < 3; i++)
            {
                (int punkte1, int punkte2) = VerhoerVerwaltung.Verhoer(strategie1, strategie2, 25, i);
                punkte1 = punkte1 * 4;
                punkte2 = punkte2 * 4;
                punkte1final += punkte1;
                punkte2final += punkte2;
            }
            for(int i = 0; i < 3; i++)
            {
                (int punkte1, int punkte2) = VerhoerVerwaltung.Verhoer(strategie1, strategie2, 100, i);
                punkte1final += punkte1;
                punkte2final += punkte2;
            }

            Console.WriteLine("Endergebnis:");
            Console.WriteLine($"{strategie1.Name()} hat insgesamt {punkte1final} Punkte erhalten.");
            Console.WriteLine($"{strategie2.Name()} hat insgesamt {punkte2final} Punkte erhalten.");
            if (punkte1final < punkte2final)
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie1.Name());
            } 
            if (punkte1final > punkte2final)
            {
                Console.WriteLine("Somit hat {0} gewonnen.", strategie2.Name());
            }
            if (punkte1final == punkte2final)
            {
                Console.WriteLine("Unentschieden.");
            }
        }

        static void GefangeneBenutzer()
        {
            Console.WriteLine("Willkommen zum Verhör zwischen Ihnen und einer Strategie!");
        }

        static void GefangeneTurnier()
        {
            Console.WriteLine("Willkommen zum Turnier mit allen Strategien!");
        }

        static (BasisStrategie, BasisStrategie) Auswahl2Strats()
        {
            int st1, st2;

            Console.WriteLine("Wählen Sie ihre 2 Strategien:");
            for (int i = 0; i < _strategien.Count; i++)
            {
                Console.WriteLine($"{i} - {_strategien[i].Name()}");
            }
            st1 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 1. Strategie", 0, _strategien.Count);
            st2 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 2. Strategie", 0, _strategien.Count);

            //holt die beiden Strategien aus der Collection.
            BasisStrategie strategie1 = VerwaltungProgramm._strategien[st1];
            BasisStrategie strategie2 = VerwaltungProgramm._strategien[st2];

            return (strategie1, strategie2);
        }
    } 
}