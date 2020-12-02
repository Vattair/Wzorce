using Cards;
using System.Collections.Generic;

namespace Games
{
    class InitChanceCard
    {
        /// <summary>
        /// Wywołanie kart
        /// </summary>
        /// <returns>Lista kart</returns>
        public List<ChanceCard> InitializeChanceCards()
        {
            List<ChanceCard> listOfCards = new List<ChanceCard>
            {
                new ChanceCard("Opłata", "Płacisz za rozbudowę szpitala", -200),
                new ChanceCard("Wzbogacenie", "Otrzymujesz zwrot z podatku", 200),
                new ChanceCard("Pusta", "Karta szans jest pusta - nic się nie dzieje", 0)
            };
            return listOfCards;
        }
    }
}
