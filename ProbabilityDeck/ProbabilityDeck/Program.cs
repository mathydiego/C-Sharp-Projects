using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Hearts   = new List<string> { "HA", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK" };
            List<string> Spades   = new List<string> { "SA", "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK" };
            List<string> Clubs    = new List<string> { "CA", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "CJ", "CQ", "CK" };
            List<string> Diamonds = new List<string> { "DA", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "DJ", "DQ", "DK" };

            List<string> BlackCards = new List<string>();
            BlackCards = Spades.Concat(Clubs).ToList();

            List<string> RedCards = new List<string>();
            RedCards = Hearts.Concat(Diamonds).ToList();

            List<string> Deck = new List<string>();
            Deck = BlackCards.Concat(RedCards).ToList();


            int handNum = 5; // number of cards in a hand
            int All_Hearts_Count = 0; // number of simulated hands with all hearts


            uint Simulations = 10000; // number of simulations (uint is used for large unsigned integers)<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            List<string> AllHands = new List<string>(); // we store all our hands in this list

            var watch = System.Diagnostics.Stopwatch.StartNew(); // initializes the calculation of the execution time

            for (int sim = 1; sim <= Simulations; sim++)
            {
                List<string> reducedDeck = new List<string>(); // create alternate deck that is going to be reduced after each draw
                reducedDeck.AddRange(Deck);

                int cardsInDeck = reducedDeck.Count; // a standard deck has 52 cards
                List<string> Hand = new List<string>(); // we store our current hand in this list
                //Console.WriteLine("Your hand is:");
                for (int draw = 1; draw <= handNum; draw++)  // draw cards for our current hand
                {
                    Random rnd = new Random();
                    int randNum = rnd.Next(cardsInDeck); // randomly generates an integer from 0 to 51
                    string drawnCard = reducedDeck[randNum]; // this is the card drawn
                    Hand.Add(drawnCard); // we store our drawn card in our hand                
                    //Console.WriteLine(drawnCard);

                    reducedDeck.RemoveAt(randNum); // removes card from deck
                    cardsInDeck--;

                    
                }

                AllHands.AddRange(Hand); // adds new simulated hand to AllHands

                int HeartsCount = 0; 
                foreach (var card in Hand) // counts the number of cars in current hand  
                {
                    if (Hearts.Contains(card))
                    {
                        HeartsCount++;
                    }                    
                }
                if (HeartsCount == handNum) // decides if a hand is full of hearts
                {
                    All_Hearts_Count++;
                }

            }

            watch.Stop(); // finalizes the computation of execution time
            var elapsedTime = watch.ElapsedMilliseconds;
            
            
            Console.WriteLine("Total hands with only Hearts:");
            Console.WriteLine(All_Hearts_Count);

            double Prob_AllHearts = (double)All_Hearts_Count / (double)Simulations; // simulated probability should be close to 33/66640 or 0.0004952
            Console.WriteLine("Simulated probability of a hand full of hearts using {0} simulations:", Simulations);
            Console.WriteLine(Prob_AllHearts);

            Console.WriteLine("Execution Time (in miliseconds):");
            Console.WriteLine(elapsedTime);


        }
    }
}

