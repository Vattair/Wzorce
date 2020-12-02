using Cards;
using Dices;
using Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Games
{
    public class Game
    {

        private readonly List<Player> players;
        private readonly List<Card> _board;
        private readonly List<ChanceCard> _chanceCards;
        private int _actualPlayer;
        private int[] _actualDicesTrow;

        /// <summary>
        /// Konstruktor gry
        /// </summary>
        public Game()
        {
            //Wczytanie kart
            InitCards initCards = new InitCards();
            _board = initCards.InitializeCards();
            //Wczytywanie kart szans
            InitChanceCard initChanceCard = new InitChanceCard();
            _chanceCards = initChanceCard.InitializeChanceCards();
            //Utworzenie tymczasowego rzutu koścmi
            _actualDicesTrow = new int[] { 0, 0, 0, 0 };

            players = new List<Player>();
            ActualPlayerIndex = 0;
        }
        #region Trow
        /// <summary>
        /// Wykonanie rzutu kościmi
        /// </summary>
        public void TrowDices()
        {
            Dice dice = new Dice();
            _actualDicesTrow = dice.RollDice;
        }

        /// <summary>
        /// Zwraca aktualny rzut kościmi
        /// </summary>
        public int[] ActualDicesTrow => _actualDicesTrow;

        /// <summary>
        /// Sprawdza czy zapisany rzut kośćmi posiada duble
        /// <para>Zwraca: </para>
        /// <list type="bullet">
        /// <item>-1 Brak zapisanego rzutu kośćmi</item>
        /// <item> 0 Brak dubli</item>
        /// <item> 1 Posiada 1 dubel</item>
        /// <item> 2 Posiada 2 duble</item>
        /// </list>
        /// </summary>
        public int IsDuble()
        {
            if (_actualDicesTrow != null)
            {
                if (_actualDicesTrow[0] == _actualDicesTrow[1])
                {
                    //1 dubel
                    if (_actualDicesTrow[2] == _actualDicesTrow[3])
                    {
                        //2 duble
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Zmienia pozycje gracza na planszy
        /// </summary>
        /// <param name="stepToMove">Ilość pozycji do przebycia</param>
        public void MovePlayer(int stepToMove)
        {
            int mapLenght = 39;
            for (int i = stepToMove; i > 0; i--)
            {
                if (GetActualPlayer().Pos == mapLenght)
                {
                    GetActualPlayer().Pos = 0;
                }
                else
                {
                    GetActualPlayer().Pos++;
                }
            }
        }
        /// <summary>
        /// Sprawdza czy graczowi należy się premia
        /// </summary>
        /// <param name="stepToMove">Ilość pozycji do przebycia</param>
        /// <returns>Zwraca True jeżeli gracz otrzymuje premie</returns>
        public bool Premia(int stepToMove)
        {
            int playerPos = GetActualPlayer().Pos;
            int step = stepToMove;
            do
            {
                playerPos++;
                if (playerPos == 40 || playerPos == 0)
                {
                    ChangeMoney(400);
                    return true;
                }
                step--;
            } while (step > 0);
            return false;
        }
        #endregion
        #region Player info
        /// <summary>
        /// Zwraca index aktualnego gracza
        /// </summary>
        public int ActualPlayerIndex { get => _actualPlayer; set => _actualPlayer = value; }

        /// <summary>
        /// Zwraca obiekt Player z listy graczy
        /// </summary>
        public Player GetActualPlayer()
        {
            return players[ActualPlayerIndex];
        }
        /// <summary>
        /// Zwraca ilość gotówki aktualnego gracza
        /// </summary>
        public int GetPlayerCash()
        {
            return players[ActualPlayerIndex].Cash;
        }
        #endregion

        #region Main mechanics
        public bool IsAI()
        {
            return GetActualPlayer().IsAI;
        }
        /// <summary>
        /// Zmienia index aktualnego gracza na kolejny lub resetuje go.
        /// </summary>
        public void NextPlayer()
        {
            //throw new NotImplementedException();
            int iloscGraczy = players.Count() - 1;// liczone od 0, 1, 2 ..  
            if (ActualPlayerIndex == iloscGraczy)
            {
                ActualPlayerIndex = 0;
            }
            else
            {
                ActualPlayerIndex++;
            }
        }
        /// <summary>
        /// Tworzy gracza
        /// </summary>
        /// <param name="isAI">True jeżeli gracz ma być obsługiwany przez komputera</param>
        /// <param name="name">Nazwa gracza</param>
        public void AddPlayer(bool isAI, string name)
        {
            players.Add(new Player(isAI, name));
        }
        /// <summary>
        /// Zmiana stanu gotówki aktualnego gracza
        /// </summary>
        /// <param name="v">Kwota o którą będzie zmieniony stan aktualnego gracza</param>
        public void ChangeMoney(int v)
        {
            GetActualPlayer().Cash += v;
        }
        /// <summary>
        /// Kwota mandatu
        /// </summary>
        /// <returns>Zwraca kwote mandatu</returns>
        public int GetFeeAmount()
        {
            return GetCard().Price;
        }
        /// <summary>
        /// Zapłata opłaty za postój graczowi
        /// </summary>
        /// <param name="v1">Index gracza który otrzyma gotówkę</param>
        /// <param name="v2">Kwota</param>
        public void PayFeeToPlayer(int v1, int v2)
        {
            players[v1].Cash += v2;
        }
        /// <summary>
        /// Zwraca nazwę gracza
        /// </summary>
        /// <param name="v">index gracza</param>
        public string GetPlayerName(int v)
        {
            return players[v].Name;
        }
        #endregion
        #region Jail
        /// <summary>
        /// Zwraca licznik dni w więzieniu
        /// </summary>
        public int InJail()
        {
            //throw new NotImplementedException();
            return GetActualPlayer().JailCountDown;
        }
        /// <summary>
        /// Umieszcza gracza w więzieniu
        /// </summary>
        public void GoToJail()
        {
            //throw new NotImplementedException();
            GetActualPlayer().JailCountDown += 3;
            GetActualPlayer().Pos = 10;
        }
        /// <summary>
        /// Odjęcie 1 dnia z licznika dni w więzieniu
        /// </summary>
        public void MinusDayJail()
        {
            //throw new NotImplementedException();
            GetActualPlayer().JailCountDown--;
        }

        #endregion
        #region Card
        /// <summary>
        /// Zwraca nazwę karty
        /// </summary>
        public string GetCardName()
        {
            return GetCard().Name;
        }
        /// <summary>
        /// Zwraca obiekt Card z aktualnej pozycji gracza
        /// </summary>
        public Card GetCard()
        {
            return _board[GetActualPlayer().Pos];
        }
        /// <summary>
        /// Zwraca typ karty
        /// </summary>
        public int ShowCardActionsIndex()
        {
            return GetCard().CardType;
        }

        /// <summary>
        /// Zwraca idex gracza jeżeli karta została kupiona lub -1 jeżeli jest dostępna do kupienia
        /// </summary>
        public int WhoseCard()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].MyCards.Contains(GetCard()))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Zwraca cene karty
        /// </summary>
        public int GetCardPrice()
        {
            return GetCard().Price;
        }
        /// <summary>
        /// Zwraca aktualny stopień ulepszenia karty
        /// </summary>
        public int GetCardActualUpgrade()
        {
            return GetCard().ActualUpgradeLevel;
        }
        /// <summary>
        /// Zwraca cene domku na karcie
        /// </summary>
        public int GetCardHousePrice()
        {
            return GetCard().HousePrice;
        }
        /// <summary>
        /// Zwraca cene hotelu na karcie
        /// </summary>
        public int GetCardApartmentPrice()
        {
            return GetCard().ApartmentPrice;
        }
        /// <summary>
        /// Losuje kartę szans, wykonuję czynność i zwraca w string[] dane karty | [3] == 1 gracz zbankrutował
        /// </summary>
        public string[] TossChanceCard()
        {
            Random random = new Random();
            int i = random.Next(0, _chanceCards.Count - 1);
            string[] data = { _chanceCards[i].Name, _chanceCards[i].Content, _chanceCards[i].Money.ToString(), "0" };
            if (_chanceCards[i].Money != 0)
            {
                if (GetPlayerCash() >= _chanceCards[i].Money)
                {
                    ChangeMoney(_chanceCards[i].Money);
                }
                else
                {
                    ChangeMoney(_chanceCards[i].Money);
                    data[3] = "1";
                }
            }
            return data;
        }

        /// <summary>
        /// Wykonuje opłate za postój na karcie
        /// </summary>
        /// <returns>Zwraca true jeżeli gracz zapłacił opłatę</returns>
        public bool CardFee()
        {
            if (CardFeeAmount() <= GetPlayerCash())
            {
                ChangeMoney(-CardFeeAmount());
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Zwraca kwote opłaty parkingowej
        /// </summary>
        public int CardFeeAmount()
        {
            return GetCard().ParkingFee;
        }
        /// <summary>
        /// Kupno karty przez aktualnego gracza
        /// </summary>
        /// <returns>True karta została kupiona</returns>
        public bool BuyCard()
        {
            if (GetCardPrice() > GetPlayerCash())
            {
                //return ("Nie stać cię na kartę.");
                return false;
            }
            else
            {
                ChangeMoney(-GetCardPrice());
                GetActualPlayer().MyCards.Add(GetCard());
                //return ($"Kupiłeś {GetCardName()} za {GetCardPrice()}");
                return true;
            }
        }
        /// <summary>
        /// Ulepsza kartę o 1
        /// </summary>
        /// <param name="v">Koszt ulepszenia</param>
        public bool BuyCardUpgrade(int v)
        {
            if (v > GetPlayerCash())
            {
                return false;
            }
            else
            {
                ChangeMoney(-v);
                GetCard().ActualUpgradeLevel += 1;
                return true;
            }
        }


        #endregion


    }

}
