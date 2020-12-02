using System;

namespace Dices
{
    public class Dice
    {
        private readonly Random _dice = new Random();

        /// <summary>
        /// Konstruktor kostki
        /// </summary>
        public Dice()
        {
        }

        /// <summary>
        /// Metoda zwracająca tablice int[] zawierającą 4 losowe cyfry
        /// </summary>
        public int[] RollDice
        {
            get
            {
                int[] result = { _dice.Next(1, 6), _dice.Next(1, 6), _dice.Next(1, 6), _dice.Next(1, 6) };
                return result;
            }
        }
    }
}
