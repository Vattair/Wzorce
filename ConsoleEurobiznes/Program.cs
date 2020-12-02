using Games;
using System;

namespace ConsoleEurobiznes
{
    class Program
    {
        private static string nick;
        public static string Nick { get => nick; set => nick = value; }

        static void Main()
        {
            Console.WriteLine("Witaj w Eurobiznes!");
            Console.Write("Podaj swój nick: ");
            Nick = Console.ReadLine();
            Menu();

        }

        private static void Menu()
        {
            //Menu 
            Console.WriteLine($"Witaj {Nick} w Eurobiznes!");
            Console.WriteLine("1.Rozpocznij nową grę");
            Console.WriteLine("2.Zmień nick");
            Console.WriteLine("3.Wyjdź");
            Console.Write("Wpisz numer akcji: ");
            switch (Console.ReadLine())
            {
                case "1":
                    NewGame();
                    break;
                case "2":
                    ChangeNick();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        private static void NewGame()
        {

            Game game = new Game();
            game.TrowDices();
            int[] sumaKosci = game.ActualDicesTrow;
            game.TrowDices();
            Console.WriteLine($"Wyrzuciłeś {sumaKosci[0]} i {sumaKosci[1]} w sumie {(sumaKosci[0] + sumaKosci[1])}, przeciwnik wyrzucił {game.ActualDicesTrow[0]} i {game.ActualDicesTrow[1]} w sumie {(game.ActualDicesTrow[0] + game.ActualDicesTrow[1])}.");

            #region Queue
            if ((game.ActualDicesTrow[0] + game.ActualDicesTrow[1]) < (sumaKosci[0] + sumaKosci[1]))
            {
                Console.WriteLine($"Grę rozpoczyna {Nick}.");
                spawnPlayer(game, false);

            }
            else if ((game.ActualDicesTrow[0] + game.ActualDicesTrow[1]) > (sumaKosci[0] + sumaKosci[1]))
            {
                Console.WriteLine($"Grę rozpoczyna AI.");
                spawnPlayer(game, true);
            }
            else
            {
                Console.WriteLine("Gra wylosuje pierwszego gracza.");
                Random random = new Random();
                if (random.Next(1, 2) == 1)
                {
                    Console.WriteLine($"Grę rozpoczyna {Nick}.");
                    spawnPlayer(game, false);
                }
                else
                {
                    Console.WriteLine($"Grę rozpoczyna AI.");
                    spawnPlayer(game, true);
                }

            }
            #endregion

            PlayerMove(game);
            static void spawnPlayer(Game game, bool aiFirst)
            {
                if (aiFirst)
                {
                    game.AddPlayer(true, "AI");
                    game.AddPlayer(false, Nick);
                }
                else
                {
                    game.AddPlayer(false, Nick);
                    game.AddPlayer(true, "AI");
                }
            }
        }

        private static void PlayerMove(Game game)
        {
            string actualPlayerName = game.GetActualPlayer().Name;
            int actualPlayerCash = game.GetActualPlayer().Cash;
            int actualPlayerJail = game.GetActualPlayer().JailCountDown;


            Console.WriteLine();
            if (actualPlayerName == Nick) { Console.BackgroundColor = ConsoleColor.Blue; }
            else { Console.BackgroundColor = ConsoleColor.Red; }
            Console.WriteLine($"Tura:{actualPlayerName}|Pieniądze:{actualPlayerCash}$");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            if (game.InJail() == 0)
            {
                game.TrowDices();
                if (game.IsDuble() == 0)
                {
                    //suma 2 kości
                    if (game.Premia(game.ActualDicesTrow[0] + game.ActualDicesTrow[1])) { Console.WriteLine("Otrzymujesz premię za start 400$!"); }
                    game.MovePlayer(game.ActualDicesTrow[0] + game.ActualDicesTrow[1]);
                    Console.WriteLine($"{actualPlayerName} wyrzucił {game.ActualDicesTrow[0]}, {game.ActualDicesTrow[1]} stanął na {game.GetCardName()}.");
                }
                else if (game.IsDuble() == 1)
                {
                    //suma 4 kości
                    if (game.Premia(game.ActualDicesTrow[0] + game.ActualDicesTrow[1] + game.ActualDicesTrow[2] + game.ActualDicesTrow[3])) { Console.WriteLine("Otrzymujesz premię za start 400$!"); }
                    game.MovePlayer(game.ActualDicesTrow[0] + game.ActualDicesTrow[1] + game.ActualDicesTrow[2] + game.ActualDicesTrow[3]);
                    Console.WriteLine($"{actualPlayerName} wyrzucił 1 dubel {game.ActualDicesTrow[0]}, {game.ActualDicesTrow[1]}|{game.ActualDicesTrow[2]}, {game.ActualDicesTrow[3]} stanął na {game.GetCardName()}.");
                }
                else if (game.IsDuble() == 2)
                {
                    //2 duble idziesz do więzienia
                    Console.WriteLine($"{actualPlayerName} wyrzucił 2 dubele {game.ActualDicesTrow[0]}, {game.ActualDicesTrow[1]}|{game.ActualDicesTrow[2]}, {game.ActualDicesTrow[3]} i idzie do więzienia.");
                    game.GoToJail();
                }


                ShowCardActionsIndex(game.ShowCardActionsIndex(), game);
            }
            else
            {
                game.MinusDayJail();
                if (game.GetActualPlayer().JailCountDown > 0)
                {
                    if (game.GetActualPlayer().JailCountDown == 1)
                    {
                        Console.WriteLine($"Jesteś w więzieniu pozostało ci {game.GetActualPlayer().JailCountDown} tura w więzieniu");
                    }
                    else
                    {
                        Console.WriteLine($"Jesteś w więzieniu pozostało ci {game.GetActualPlayer().JailCountDown} tury w więzieniu");
                    }
                }
                else
                {
                    Console.WriteLine("Wychodzisz z wiezienia");
                    PlayerMove(game);
                }

            }
            game.NextPlayer();
            PlayerMove(game);
        }

        private static void ShowCardActionsIndex(int v, Game game)
        {
            switch (v)
            {
                case (int)CardTypes.Start:
                    game.NextPlayer();
                    PlayerMove(game);
                    break;
                case (int)CardTypes.Oplata:
                    Console.WriteLine($"Płacisz {game.GetFeeAmount()}$ za {game.GetCardName()}");
                    game.ChangeMoney(-game.GetFeeAmount());
                    game.NextPlayer();
                    PlayerMove(game);
                    break;
                case (int)CardTypes.Miasto:
                    ShowCardActions(game.WhoseCard(), game.ActualPlayerIndex, game, "M");
                    break;
                case (int)CardTypes.Budynki:
                    ShowCardActions(game.WhoseCard(), game.ActualPlayerIndex, game, "B");
                    break;
                case (int)CardTypes.Koleje:
                    ShowCardActions(game.WhoseCard(), game.ActualPlayerIndex, game, "K");
                    break;
                case (int)CardTypes.KartaSzans:
                    ChanceCard(game);
                    break;
                case (int)CardTypes.IdzWienzienie:
                    game.GoToJail();
                    game.NextPlayer();
                    PlayerMove(game);
                    break;
                case (int)CardTypes.Bez_Efektu:
                    game.NextPlayer();
                    PlayerMove(game);
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            if (game.IsAI())
            {
                Console.WriteLine("Wciśnij enter aby kontynuować ..");
                Console.ReadLine();
            }
        }

        private static void ChanceCard(Game game)
        {
            string[] data = game.TossChanceCard();
            if (data[3] == "0")
            {
                if (data[2] == "0")
                {
                    Console.WriteLine($"Wylosowałeś kartę szans \"{data[0]}\" o treści \"{data[1]}\"");
                }
                else
                {
                    Console.WriteLine($"Wylosowałeś kartę szans \"{data[0]}\" o treści \"{data[1]} {data[2]}$\"");
                }
            }
            else
            {
                Console.WriteLine($"Bankrutuje gracz {game.GetPlayerName(game.ActualPlayerIndex)}!");
                Environment.Exit(0);
            }
        }

        private static void ShowCardActions(int v, int ActualPlayerIndex, Game game, string T)
        {
            if (v == -1)
            {
                Console.WriteLine($"Karta \"{game.GetCardName()}\" kosztuje {game.GetCardPrice()}$.");
                string dTmp = "2";
                if (game.IsAI())
                {
                    dTmp = "1";
                }
                else
                {
                    Console.WriteLine("1 - Kup kartę");
                    Console.WriteLine("2 - Pomiń ruch");
                    Console.WriteLine("3 - Zamknij aplikacje");
                    Console.Write("Wpisz numer akcji:");
                    dTmp = Console.ReadLine();
                }
                switch (dTmp)
                {
                    case "1":
                        if (game.BuyCard())
                        {
                            Console.WriteLine($"Kupiłeś {game.GetCardName()} za {game.GetCardPrice()}");
                        }
                        else
                        {
                            Console.WriteLine("Nie stać cię na kartę.");
                        }
                        break;
                    case "2":

                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            else if (ActualPlayerIndex == v)
            {
                Console.WriteLine("Karta należy do ciebie!");
                //kupno domku lub hotelu
                if (T == "M")
                {
                    if (game.GetCardActualUpgrade() < 5)
                    {
                        Console.WriteLine($"Domek kosztuje {game.GetCardHousePrice()}$");
                        string dTmp = "2";
                        if (game.IsAI())
                        {
                            dTmp = "1";
                        }
                        else
                        {
                            Console.WriteLine("1 - Kup domek");
                            Console.WriteLine("2 - Pomiń ruch");
                            Console.WriteLine("3 - Zamknij aplikacje");
                            Console.Write("Wpisz numer akcji:");
                            dTmp = Console.ReadLine();
                        }
                        switch (dTmp)
                        {
                            case "1":
                                if (game.BuyCardUpgrade(game.GetCardHousePrice()))
                                {
                                    Console.WriteLine($"Kupiłeś domek za {game.GetCardHousePrice()}$");
                                }
                                else
                                {
                                    Console.WriteLine("Nie stać cię na domek.");
                                }
                                break;
                            case "2":

                                break;
                            case "3":
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (game.GetCardActualUpgrade() < 6)
                    {
                        Console.WriteLine($"Hotel kosztuje {game.GetCardApartmentPrice()}$");
                        string dTmp = "2";
                        if (game.IsAI())
                        {
                            dTmp = "1";
                        }
                        else
                        {
                            Console.WriteLine("1 - Kup hotel");
                            Console.WriteLine("2 - Pomiń ruch");
                            Console.WriteLine("3 - Zamknij aplikacje");
                            Console.Write("Wpisz numer akcji:");
                            dTmp = Console.ReadLine();
                        }
                        switch (dTmp)
                        {
                            case "1":
                                if (game.BuyCardUpgrade(game.GetCardApartmentPrice()))
                                {
                                    Console.WriteLine($"Kupiłeś hotel za {game.GetCardApartmentPrice()}$");
                                }
                                else
                                {
                                    Console.WriteLine("Nie stać cię na hotel.");
                                }
                                break;
                            case "2":

                                break;
                            case "3":
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Budynek jest maksymalnie ulepszony");
                    }
                }
            }
            else
            {
                if (T == "M")
                {
                    if (game.CardFee())
                    {
                        Console.WriteLine($"Należy do gracza o nazwie {game.GetPlayerName(v)} płacisz {game.CardFeeAmount()}$");
                        game.PayFeeToPlayer(v, game.CardFeeAmount());
                    }
                    else
                    {
                        Console.WriteLine($"Bankrutuje gracz {game.GetPlayerName(v)}!");
                        Environment.Exit(0);
                    }
                }
            }
        }

        static void ChangeNick()
        {
            Console.Write("Podaj nowy nick: ");
            Nick = Console.ReadLine();
            Menu();
        }
    }
}
