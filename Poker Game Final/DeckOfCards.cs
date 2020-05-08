    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game_Final
{
    class DeckOfCards
    {
        Card[] Deck;

        Card[] Hend;




       public DeckOfCards() {
            Hend = new Card[10];

            //Deck Generator 
            Deck = new Card[52];
            string[] suits = { "C", "D", "H", "S" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "A", "J", "Q", "K" };
            string[] cards = new string[52];
            int count = 0;

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    
                    Deck[count] = new Card(values[i], suits[j]);
                    //Console.WriteLine(Deck[count].GetCard());

                    count++;
                }
            }





        }


        public Card[] ReturnHend() {

            Random r = new Random();

            Deck = Deck.OrderBy(x => r.Next()).ToArray();
            for (int i = 0; i < 10; i++)
            {
                Hend[i] = Deck[i];
                //Console.WriteLine(Deck[i].GetCard());

            }

            return Hend;
        }


        

        


    }
}
