using Cards;
using System.Collections.Generic;

namespace Players
{
    public class Player
    {
        private int _cash;
        private readonly string _name;
        private int _jailCountDown; //Jeżeli inne iż 0 to jesteś w więzieniu na x tur
        private List<Card> myCards;
        private readonly bool _isAI;
        private int _pos;

        /// <summary>
        /// Nazwa gracza
        /// </summary>
        public string Name { get => _name; }
        /// <summary>
        /// Ilość posiadanej gotówki
        /// </summary>
        public int Cash { get => _cash; set => _cash = value; }
        /// <summary>
        /// Zwraca licznik ilości dni pozostałych do spędzenia w więzieniu
        /// </summary>
        public int JailCountDown { get => _jailCountDown; set => _jailCountDown = value; }
        /// <summary>
        /// Aktualna pozycja gracza na planszy
        /// </summary>
        public int Pos { get => _pos; set => _pos = value; }
        /// <summary>
        /// Lista kart posiadanych przez gracza
        /// </summary>
        public List<Card> MyCards { get => myCards; set => myCards = value; }

        /// <summary>
        /// Zwraca true jeżeli gracz jest komputerem
        /// </summary>
        public bool IsAI => _isAI;

        /// <summary>
        /// Konstruktor gracza
        /// </summary>
        /// <param name="isAI">True jeżeli ma być obsługiwany przez komputer</param>
        /// <param name="name">Nazwa gracza</param>
        public Player(bool isAI, string name)
        {
            _name = name;
            _isAI = isAI;
            Cash = 4000;
            JailCountDown = 0;
            Pos = 0;
            MyCards = new List<Card>();
        }
    }
}
