using System;

namespace War
{
    public class Card
    {
        private readonly int _cardValue;

        public Card(int cardValue)
        {
            _cardValue = cardValue;
        }

        public string Suit
        {
            get
            {
                var suit = _cardValue / 13;
                switch (suit)
                {
                    case 0:
                        return "Spades";
                    case 1:
                        return "Clubs";
                    case 2:
                        return "Hearts";
                    case 3:
                        return "Diamonds";
                    default:
                        throw new Exception("AAGH!");
                }
            }
        }

        public int Order { get { return _cardValue % 13; } }

        public string Rank
        {
            get
            {
                switch (Order)
                {
                    case 12:
                        return "Ace";
                    case 0:
                        return "Two";
                    case 1:
                        return "Three";
                    case 2:
                        return "Four";
                    case 3:
                        return "Five";
                    case 4:
                        return "Six";
                    case 5:
                        return "Seven";
                    case 6:
                        return "Eight";
                    case 7:
                        return "Nine";
                    case 8:
                        return "Ten";
                    case 9:
                        return "Jack";
                    case 10:
                        return "Queen";
                    case 11:
                        return "King";
                    default:
                        throw new Exception("NOO!");
                }
            }
        }

        public string Name
        {
            get { return Rank + " of " + Suit; }
        }

        public bool Beats(Card card)
        {
            return Order > card.Order;
        }

        public bool SameRankAs(Card card)
        {
            return Order == card.Order;
        }
    }
}