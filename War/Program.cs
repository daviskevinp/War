using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace War
{
    class Program
    {
        static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            var numGamesPlayed = 0;
            var gameRecords = new List<GameRecord>();

            while (numGamesPlayed < 200)
            {
                gameRecords.Add(PlayGame());
                numGamesPlayed++;
            }

            WriteToFile(gameRecords, args[0] == null ? @"c:\temp\war.csv" : @"C:\temp\" + args[0] + ".csv" );

            Console.ReadLine();
        }

        private static void WriteToFile(IEnumerable<GameRecord> gameRecords, string fileName)
        {
            var builder = new StringBuilder();
            builder.Append("Winner,NumTricks,NAcesP1,NAcesP2");
            //implementez vous
            foreach (var gameRecord in gameRecords)
            {
                builder.Append(Environment.NewLine + string.Format("{0},{1},{2},{3},{4},{5}", gameRecord.Winner, gameRecord.NumTricks, gameRecord.NumAcesPlayer1,
                                  gameRecord.NumAcesPlayer2, gameRecord.NumShuffles, gameRecord.ArtificiallyBroken));
                Console.WriteLine("Winner {0}, NTricks {1}, Player 1 Aces: {2}, Player 2 Aces: {3}, NShuffles: {4}, Ended: {5}",
                                  gameRecord.Winner, gameRecord.NumTricks, gameRecord.NumAcesPlayer1,
                                  gameRecord.NumAcesPlayer2, gameRecord.NumShuffles, gameRecord.ArtificiallyBroken);
            }

            File.WriteAllText(fileName, builder.ToString());
        }

        private static GameRecord PlayGame()
        {
            var deck = DeckOfCards.GetStandardDeck(Random);
            deck.Shuffle();

            var playerOne = deck.Deal(26);
            var playerTwo = deck.Deal(26);

            var gameRecord = new GameRecord {NumAcesPlayer1 = playerOne.NumAces, NumAcesPlayer2 = playerTwo.NumAces};
            var gameEngine = new GameEngine();
            while (playerOne.Cards.Count > 0 && playerTwo.Cards.Count > 0)
            {
                gameEngine.PlayTrick(playerOne, playerTwo);
                gameRecord.NumTricks++;
                if (gameRecord.NumTricks % 25000 == 0) 
                {
                    playerOne.Shuffle();
                    gameRecord.NumShuffles++;
                }
                if (gameRecord.NumTricks > 10000000)
                {
                    gameRecord.ArtificiallyBroken = true;
                    break;
                }
            }

            gameRecord.Winner = playerOne.Cards.Count == 0 ? "Player 2" : "Player 1";

            return gameRecord;
        }

        private static void ListCards(DeckOfCards deck)
        {
            foreach (var card in deck.Cards)
            {
                Console.WriteLine(card.Name);
            }
        }
    }
}
