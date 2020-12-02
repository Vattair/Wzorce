using System;

namespace Cards
{
    public class Card
    {
        private readonly int _cardType;
#pragma warning disable IDE0052 // Usuń nieodczytywane składowe prywatne
        private readonly int _countryId;
#pragma warning restore IDE0052 // Usuń nieodczytywane składowe prywatne
        private readonly string _name;
        private readonly int _price;
        private readonly int _housePrice;
        private readonly int _apartmentPrice;
        private readonly int[] _parkingFeeList;
        private int _actualUpgradeLevel = 0;
        private readonly int _mortgage;

        /// <summary>
        /// Konstruktor karty
        /// </summary>
        /// <param name="cardType">Typ karty np. miasto , opłata, itp.</param>
        /// <param name="countryId">Grupowanie miast po id państwa(0 = Nie jest to miasto)</param>
        /// <param name="name">Nazwa karty</param>
        /// <param name="price">Cena karty</param>
        /// <param name="housePrice">Cena domku</param>
        /// <param name="apartmentPrice">Cena hotelu</param>
        /// <param name="parkingFeeList">Lista opłat za postój</param>
        /// <param name="mortgage">Zastaw hipoteczny</param>
        public Card(int cardType, int countryId, string name, int price, int housePrice, int apartmentPrice, int[] parkingFeeList, int mortgage)
        {
            _cardType = cardType;
            _countryId = countryId;
            _name = name;
            _price = price;
            _housePrice = housePrice;
            _apartmentPrice = apartmentPrice;
            _parkingFeeList = parkingFeeList;
            _mortgage = mortgage;
        }

        /// <summary>
        /// Karty typu +- $ itp.
        /// </summary>
        /// <param name="cardType">Typ karty</param>
        /// <param name="name">Nazwa karty</param>
        /// <param name="price">Dodawane lub odejmowane $</param>
        public Card(int cardType, string name, int price)
        {
            _cardType = cardType;
            _name = name;
            _price = price;
        }

        /// <summary>
        /// Karty koleji
        /// </summary>
        /// <param name="cardType">Typ karty</param>
        /// <param name="countryId">Grupowanie kart</param>
        /// <param name="name">Nazwa karty</param>
        /// <param name="price">Cena karty</param>
        /// <param name="parkingFeeList">Lista opłat za postój</param>
        /// <param name="mortgage">Zastaw hipoteczny</param>
        public Card(int cardType, int countryId, string name, int price, int[] parkingFeeList, int mortgage)
        {
            _cardType = cardType;
            _countryId = countryId;
            _name = name;
            _price = price;
            _parkingFeeList = parkingFeeList;
            _mortgage = mortgage;
        }
        /// <summary>
        /// Karty budynków
        /// </summary>
        /// <param name="cardType">Typ karty</param>
        /// <param name="countryId">Grupowanie kart</param>
        /// <param name="name">Nazwa karty</param>
        /// <param name="price">Cena karty</param>
        /// <param name="mortgage">Zastaw hipoteczny</param>
        public Card(int cardType, int countryId, string name, int price, int mortgage)
        {
            _cardType = cardType;
            _countryId = countryId;
            _name = name;
            _price = price;
            _mortgage = mortgage;
        }

        /// <summary>
        /// Karty specjalne
        /// </summary>
        /// <param name="cardType">Typ karty</param>
        /// <param name="name">Nazwa karty</param>
        public Card(int cardType, string name)
        {
            _cardType = cardType;
            _name = name;
        }





        /// <summary>
        /// Nazwa karty
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Typ karty
        /// </summary>
        public int CardType => _cardType;

        /// <summary>
        /// Koszt karty
        /// </summary>
        public int Price => _price;

        /// <summary>
        /// Zastaw hipoteczny
        /// </summary>
        public int Mortgage => _mortgage;

        /// <summary>
        /// Koszt budowy domu
        /// </summary>
        public int HousePrice => _housePrice;

        /// <summary>
        /// Koszt budowy hotelu
        /// </summary>
        public int ApartmentPrice => _apartmentPrice;

        /// <summary>
        /// Aktualny poziom ulepszenia karty
        /// <para>0 - niezabudowany</para>
        /// <para>1 - 5 domki lub hotel</para>
        /// </summary>
        public int ActualUpgradeLevel
        {
            get => _actualUpgradeLevel;
            set
            {
                if (value >= 0 && value < 6)
                {
                    _actualUpgradeLevel = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        /// <summary>
        /// Aktualny poziom opłaty za postój na karcie
        /// </summary>
        public int ParkingFee
        {
            get => _parkingFeeList[_actualUpgradeLevel];
        }
    }
}
