using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using War;

namespace WarTests
{
    [TestClass]
    public class GameEngineTests    
    {
        [TestMethod]
        public void CanCreateGameEngine()
        {
            Assert.IsNotNull(new GameEngine());
        }

        [TestMethod]
        public void CanPlayTrickWithASingleWar()
        {
            //Arrange
            var random = new Random(DateTime.Now.TimeOfDay.Seconds);
            var deckOneCards = new List<Card>();
            deckOneCards.Add(new Card(0));
            deckOneCards.Add(new Card(1));
            deckOneCards.Add(new Card(2));
            var playerOne = new DeckOfCards(deckOneCards, random);

            var deckTwoCards = new List<Card>();
            deckTwoCards.Add(new Card(0));
            deckTwoCards.Add(new Card(5));
            deckTwoCards.Add(new Card(6));
            var playerTwo = new DeckOfCards(deckTwoCards, random);

            //Act
            new GameEngine().PlayTrick(playerOne, playerTwo);

            //Assert
            Assert.AreEqual(6, playerTwo.Cards.Count);
            Assert.AreEqual(0, playerOne.Cards.Count);
        }

        [TestMethod]
        public void PlayerOneCanWinToo()
        {
            //Arrange
            var random = new Random(DateTime.Now.TimeOfDay.Seconds);
            var deckOneCards = new List<Card>();
            deckOneCards.Add(new Card(0));
            deckOneCards.Add(new Card(5));
            deckOneCards.Add(new Card(6));
            var playerOne = new DeckOfCards(deckOneCards, random);

            var deckTwoCards = new List<Card>();
            deckTwoCards.Add(new Card(0));
            deckTwoCards.Add(new Card(1));
            deckTwoCards.Add(new Card(2));
            var playerTwo = new DeckOfCards(deckTwoCards, random);

            //Act
            new GameEngine().PlayTrick(playerOne, playerTwo);

            //Assert
            Assert.AreEqual(6, playerOne.Cards.Count);
            Assert.AreEqual(0, playerTwo.Cards.Count);
        }

        [TestMethod]
        public void CanPlaySimpleTrick()
        {
            //Arrange
            var random = new Random(DateTime.Now.TimeOfDay.Seconds);
            var deckOneCards = new List<Card>();
            deckOneCards.Add(new Card(0));
            var playerOne = new DeckOfCards(deckOneCards, random);

            var deckTwoCards = new List<Card>();
            deckTwoCards.Add(new Card(6));
            var playerTwo = new DeckOfCards(deckTwoCards, random);

            //Act
            new GameEngine().PlayTrick(playerOne, playerTwo);

            //Assert
            Assert.AreEqual(2, playerTwo.Cards.Count);
            Assert.AreEqual(0, playerOne.Cards.Count);
        }

        [TestMethod]
        public void CanPlayTrickWithDoubleWar()
        {
            //Arrange
            var random = new Random(DateTime.Now.TimeOfDay.Seconds);
            var deckOneCards = new List<Card>();
            deckOneCards.Add(new Card(0));
            deckOneCards.Add(new Card(1));
            deckOneCards.Add(new Card(2));
            deckOneCards.Add(new Card(3));
            deckOneCards.Add(new Card(4));
            var playerOne = new DeckOfCards(deckOneCards, random);

            var deckTwoCards = new List<Card>();
            deckTwoCards.Add(new Card(13));
            deckTwoCards.Add(new Card(18));
            deckTwoCards.Add(new Card(15));
            deckTwoCards.Add(new Card(22));
            deckTwoCards.Add(new Card(23));

            var playerTwo = new DeckOfCards(deckTwoCards, random);

            //Act
            new GameEngine().PlayTrick(playerOne, playerTwo);

            //Assert
            Assert.AreEqual(10, playerTwo.Cards.Count);
            Assert.AreEqual(0, playerOne.Cards.Count);
        }

        [TestMethod]
        public void CanPlayTrickWithTripleWar()
        {
            //Arrange
            var random = new Random(DateTime.Now.TimeOfDay.Seconds);
            var deckOneCards = new List<Card>();
            deckOneCards.Add(new Card(0));
            deckOneCards.Add(new Card(1));
            deckOneCards.Add(new Card(2));
            deckOneCards.Add(new Card(3));
            deckOneCards.Add(new Card(4));
            deckOneCards.Add(new Card(5));
            deckOneCards.Add(new Card(6));
            var playerOne = new DeckOfCards(deckOneCards, random);

            var deckTwoCards = new List<Card>();
            deckTwoCards.Add(new Card(13));
            deckTwoCards.Add(new Card(18));
            deckTwoCards.Add(new Card(15));
            deckTwoCards.Add(new Card(22));
            deckTwoCards.Add(new Card(17));
            deckTwoCards.Add(new Card(22));
            deckTwoCards.Add(new Card(23));

            var playerTwo = new DeckOfCards(deckTwoCards, random);

            //Act
            new GameEngine().PlayTrick(playerOne, playerTwo);

            //Assert
            Assert.AreEqual(14, playerTwo.Cards.Count);
            Assert.AreEqual(0, playerOne.Cards.Count);
        }
    }
}
