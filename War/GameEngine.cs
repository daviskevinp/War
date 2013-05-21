namespace War
{
    public class GameEngine
    {
        public void PlayTrick(DeckOfCards playerOne, DeckOfCards playerTwo)
        {
            try
            {
                var cardPlayerOne = playerOne.Deal(1).Cards[0];
                var cardPlayerTwo = playerTwo.Deal(1).Cards[0];

                var playerOneWins = false;

                if (cardPlayerOne.SameRankAs(cardPlayerTwo))
                {
                    playerOneWins = PlayerOneWinsWar(playerOne, playerTwo);
                }

                else if (cardPlayerOne.Beats(cardPlayerTwo))
                {
                    playerOneWins = true;
                }

                if ( playerOneWins )
                {
                    //Console.WriteLine("{0} beats {1} - cards to player 1", cardPlayerOne.Name, cardPlayerTwo.Name);
                    playerOne.Add(cardPlayerOne);
                    playerOne.Add(cardPlayerTwo);
                }
                else
                {
                    //Console.WriteLine("{0} beats {1} - cards to player 2", cardPlayerTwo.Name, cardPlayerOne.Name);
                    playerTwo.Add(cardPlayerOne);
                    playerTwo.Add(cardPlayerTwo);
                }
            }
            catch
            {
                // move along
            }
        }

        private static bool PlayerOneWinsWar(DeckOfCards playerOne, DeckOfCards playerTwo)
        {
            var playerOneWins = false;
            
            //Console.WriteLine("WAR: {0}, {1}", cardPlayerOne.Name, cardPlayerTwo.Name);
            var moreCardsPlayerOne = playerOne.Deal(2);
            var moreCardsPlayerTwo = playerTwo.Deal(2);

            if (moreCardsPlayerOne.Cards[1].Beats(moreCardsPlayerTwo.Cards[1]))
            {
                playerOneWins = true;
            }
            else if (moreCardsPlayerTwo.Cards[1].Beats(moreCardsPlayerOne.Cards[1]))
            {
                // playerOneWins = false;
            }
            else
            {
                playerOneWins = PlayerOneWinsWar(playerOne, playerTwo);
            }

            if (playerOneWins)
            {
                playerOne.Add(moreCardsPlayerTwo.Cards);
                playerOne.Add(moreCardsPlayerOne.Cards);
            }
            else
            {
                playerTwo.Add(moreCardsPlayerTwo.Cards);
                playerTwo.Add(moreCardsPlayerOne.Cards);
            }

            return playerOneWins;
        }
    }
}