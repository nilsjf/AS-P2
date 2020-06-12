using System;
using Gefangenendilemma.Basis;

namespace Gefangenendilemma
{
    class Utility
    {
        public static (BasisStrategie, BasisStrategie) Auswahl2Strats()
        {
            int st1, st2;

            Console.WriteLine("Wählen Sie ihre 2 Strategien:");
            for (int i = 0; i < VerwaltungProgramm._strategien.Count; i++)
            {
                Console.WriteLine($"{i} - {VerwaltungProgramm._strategien[i].Name()}");
            }
            st1 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 1. Strategie", 0, VerwaltungProgramm._strategien.Count);
            st2 = VerwaltungKram.EingabeZahlMinMax("Wählen Sie die 2. Strategie", 0, VerwaltungProgramm._strategien.Count);

            //holt die beiden Strategien aus der Collection.
            BasisStrategie strategie1 = VerwaltungProgramm._strategien[st1];
            BasisStrategie strategie2 = VerwaltungProgramm._strategien[st2];

            return (strategie1, strategie2);
        }

        public static BasisStrategie AuswahlStrat()
        {
            int st;

            Console.WriteLine("Wählen Sie ihre gegnerische Strategien:");
            for (int i = 0; i < VerwaltungProgramm._strategien.Count; i++)
            {
                Console.WriteLine($"{i} - {VerwaltungProgramm._strategien[i].Name()}");
            }
            st = VerwaltungKram.EingabeZahlMinMax("Auswahl: ", 0, VerwaltungProgramm._strategien.Count);
            BasisStrategie strategie = VerwaltungProgramm._strategien[st];

            return strategie;
        }

        public static (int, int) NeunSpiele(BasisStrategie strategie1, BasisStrategie strategie2)
        {
            int punkte1final = 0, punkte2final = 0;

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

            return (punkte1final, punkte2final);
        }

        public static string GetSchwere(int i)
        {
            if(i == 0)
            {
                return "leicht";
            }
            if(i == 1)
            {
                return "mittel";
            }
            if(i == 2)
            {
                return "schwer";
            }
            return null;
        }

        public static string GetReaktion(int i)
        {
            if(i == -1)
            {
                return "Noch nicht verhört";
            }
            if(i == 0)
            {
                return "Kooperieren";
            }
            if(i == 1)
            {
                return "Verrat";
            }
            return null;
        }
    }
}