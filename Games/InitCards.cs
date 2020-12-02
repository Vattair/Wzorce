using Cards;
using System.Collections.Generic;

namespace Games
{
    public class InitCards
    {
        /// <summary>
        /// Wywołanie kart
        /// </summary>
        /// <returns>Lista kart</returns>
        public List<Card> InitializeCards()
        {
            List<Card> listOfCards = new List<Card>
            {
                new Card((int)CardTypes.Start, "Start", 400),

                //--------------------------------------------|Start Grecja|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Grecja, "Saloniki", 120, 100, 100, new int[] { 10, 40, 120, 360, 640, 900 }, 60),


                new Card((int)CardTypes.KartaSzans, "Szansa"),

                new Card((int)CardTypes.Miasto, (int)Country.Grecja, "Ateny", 120, 100, 100, new int[] { 10, 40, 120, 360, 640, 900 }, 60),
                //--------------------------------------------|End Grecja|---------------------------------------------------------


                new Card((int)CardTypes.Oplata, "Parking strzeżony", 400),

                new Card((int)CardTypes.Koleje, (int)Country.Koleje, "Koleje południowe", 400, new int[] { 50, 100, 200, 400 }, 200),
                //--------------------------------------------|Start Włochy|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Wlochy, "Neapol", 200, 100, 100, new int[] { 15, 60, 180, 540, 800, 1100 }, 100),

                new Card((int)CardTypes.KartaSzans, "Szansa"),

                new Card((int)CardTypes.Miasto, (int)Country.Wlochy, "Mediolan", 200, 100, 100, new int[] { 15, 60, 180, 540, 800, 1100 }, 100),
                new Card((int)CardTypes.Miasto, (int)Country.Wlochy, "Rzym", 240, 100, 100, new int[] { 20, 80, 200, 600, 900, 1200 }, 120),
                //--------------------------------------------|End Włochy|---------------------------------------------------------

                new Card((int)CardTypes.Bez_Efektu, "Więzienie / Dla odwiedzających"),

                //--------------------------------------------|Start Hiszpania|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Hiszpania, "Barcelona", 280, 200, 200, new int[] { 20, 100, 300, 900, 1250, 1500 }, 140),
                new Card((int)CardTypes.Budynki, (int)Country.Budynki, "Elektrownia Atomowa", 300, 150),
                new Card((int)CardTypes.Miasto, (int)Country.Hiszpania, "Sewilla", 280, 200, 200, new int[] { 20, 100, 300, 900, 1250, 1500 }, 140),
                new Card((int)CardTypes.Miasto, (int)Country.Hiszpania, "Madryt", 320, 200, 200, new int[] { 25, 120, 360, 1000, 1400, 1800 }, 160),
                //--------------------------------------------|End Hiszpania|---------------------------------------------------------
                new Card((int)CardTypes.Koleje, (int)Country.Koleje, "Koleje zachodnie", 400, new int[] { 50, 100, 200, 400 }, 200),
                //--------------------------------------------|Start Anglia|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Anglia, "Liverpool", 360, 200, 200, new int[] { 30, 140, 400, 1100, 1500, 1900 }, 180),


                new Card((int)CardTypes.KartaSzans, "Szansa"),

                new Card((int)CardTypes.Miasto, (int)Country.Anglia, "Glasgow", 360, 200, 200, new int[] { 30, 140, 400, 1100, 1500, 1900 }, 180),
                new Card((int)CardTypes.Miasto, (int)Country.Anglia, "Londyn", 400, 200, 200, new int[] { 35, 160, 440, 1200, 1600, 2000 }, 200),
                //--------------------------------------------|End Anglia|---------------------------------------------------------


                new Card((int)CardTypes.Bez_Efektu, "Darmowy parking"),

                //--------------------------------------------|Start Benelux|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Benelux, "Rotterdam", 440, 300, 300, new int[] { 35, 180, 500, 1400, 1750, 2100 }, 220),


                new Card((int)CardTypes.KartaSzans, "Szansa"),

                new Card((int)CardTypes.Miasto, (int)Country.Benelux, "Bruksela", 440, 300, 300, new int[] { 35, 180, 500, 1400, 1750, 2100 }, 220),
                new Card((int)CardTypes.Miasto, (int)Country.Benelux, "Amsterdam", 480, 300, 300, new int[] { 40, 200, 600, 1500, 1850, 2200 }, 240),
                //--------------------------------------------|End Benelux|---------------------------------------------------------
                new Card((int)CardTypes.Koleje, (int)Country.Koleje, "Koleje północne", 400, new int[] { 50, 100, 200, 400 }, 200),
                //--------------------------------------------|Start Szwecja|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Szwecja, "Malmo", 520, 300, 300, new int[] { 45, 220, 660, 1600, 1950, 2300 }, 260),
                new Card((int)CardTypes.Miasto, (int)Country.Szwecja, "Gotenberg", 520, 300, 300, new int[] { 45, 220, 660, 1600, 1950, 2300 }, 260),
                new Card((int)CardTypes.Budynki, (int)Country.Budynki, "Sieć wodociągów", 300, 150),
                new Card((int)CardTypes.Miasto, (int)Country.Szwecja, "Sztokholm", 560, 300, 300, new int[] { 50, 240, 720, 1700, 2050, 2400 }, 280),
                //--------------------------------------------|End Szwecja|---------------------------------------------------------
                new Card((int)CardTypes.IdzWienzienie, "Idziesz do więzienia!"),
                //--------------------------------------------|Start RFN|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.RFN, "Frankfurt", 600, 400, 400, new int[] { 55, 260, 780, 1900, 2200, 2550 }, 300),
                new Card((int)CardTypes.Miasto, (int)Country.RFN, "Kolonia", 600, 400, 400, new int[] { 55, 260, 780, 1900, 2200, 2550 }, 300),


                new Card((int)CardTypes.KartaSzans, "Szansa"),

                new Card((int)CardTypes.Miasto, (int)Country.RFN, "Bonn", 640, 400, 400, new int[] { 60, 300, 900, 2000, 2400, 2800 }, 320),
                //--------------------------------------------|End RFN|---------------------------------------------------------
                new Card((int)CardTypes.Koleje, (int)Country.Koleje, "Koleje wschodnie", 400, new int[] { 50, 100, 200, 400 }, 200),


                new Card((int)CardTypes.KartaSzans, "Szansa"),

                //--------------------------------------------|Start Austria|---------------------------------------------------------
                new Card((int)CardTypes.Miasto, (int)Country.Austria, "Innsbruk", 700, 400, 400, new int[] { 70, 350, 1000, 2200, 2600, 3000 }, 350),


                new Card((int)CardTypes.Oplata, "Podatek od wzbogacenia", 400),

                new Card((int)CardTypes.Miasto, (int)Country.Austria, "Wiedeń", 800, 400, 400, new int[] { 100, 400, 1200, 2800, 3400, 4000 }, 400)
            };
            //--------------------------------------------|End Austria|---------------------------------------------------------
            return listOfCards;
        }
    }
}
