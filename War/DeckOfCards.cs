using System;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class DeckOfCards
    {
        private readonly Random _random;

        public IList<Card> Cards { get; private set; }

        public int NumAces
        {
            get { return Cards.Count(card => card.Rank == "Ace"); }
        }

        public DeckOfCards(IList<Card> cards, Random random)
        {
            Cards = cards;
            _random = random;
        }

        public void Shuffle()
        {
            var n = Cards.Count;
            while (n > 1)
            {
                n--;
                var k = _random.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        public DeckOfCards Deal(int numCards)
        {
            if (numCards > Cards.Count)
            {  // player is out of cards.  Drain cards and throw exception - game is over
                for (var count = 0; count < numCards; count++)
                {
                    Cards.RemoveAt(0);
                }

                throw new Exception();
            }

            var list = new List<Card>();

            for (int count = 0; count < numCards; count++)
            {
                list.Add(Cards[count]);
            }

            for (int count = 0; count < numCards; count++)
            {
                Cards.RemoveAt(0);
            }

            return new DeckOfCards(list, _random);
        }

        public void Add(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public static DeckOfCards GetStandardDeck(Random random)
        {
            var list = new List<Card>();
            for (int count = 0; count < 52; count++)
            {
                list.Add(new Card(count));
            }

            var deck = new DeckOfCards(list, random);
            return deck;
        }
    }
}