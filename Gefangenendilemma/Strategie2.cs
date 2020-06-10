using Gefangenendilemma.Basis;

namespace Gefangenendilemma
{
    public class Strategie2 : BasisStrategie
    {
        private int _runden;
        private int _runde = 1;
        private int _schwereEinstellung;


        /// <summary>
        /// Gibt den Namen der Strategie zurück, wichtig zum Anzeigen für die Auswahl
        /// </summary>
        /// <returns></returns>
        public override string Name()
        {
            return "Anti-Groll";
        }

        /// <summary>
        /// Gibt den Namen des Autors der Strategie zurück, wichtig für die Turnierpart um den Sieger zu ermitteln.
        /// </summary>
        /// <returns></returns>
        public override string Autor()
        {
            return "Thomas Weier";
        }

        /// <summary>
        /// Teilt mit, dass ein Verhoer jetzt startet
        /// </summary>
        /// <param name="runde">Anzahl der Runden, die verhört wird</param>
        /// <param name="schwere">Schwere des Verbrechen (VLeicht = 0, VMittel = 1, VSchwer = 2)</param>
        public override void Start(int runde, int schwere)
        {
            _runden = runde;
            _schwereEinstellung = schwere;
        }

        /// <summary>
        /// Verhoert einen Gefangenen
        /// </summary>
        /// <param name="letzteReaktion">Reaktion des anderen Gefangenen, die Runde davor (NochNichtVerhoert = -1, Kooperieren = 0, Verrat = 1)</param>
        /// <returns>Gibt die eigene Reaktion für diese Runde zurück (Kooperieren = 0, Verrat = 1)</returns>
        public override int Verhoer(int letzteReaktion)
        {
            if (_schwereEinstellung == 1)
            {
                return Kooperieren;
            }

            if (_runde < _runden)
            {
                _runde++;

                return Kooperieren;
            }

            return Verrat;
        }
    }
}