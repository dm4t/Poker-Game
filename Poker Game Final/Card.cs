using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game_Final
{
    public class Card
    {
        //public string name;
        public string value;
        public string suit;



        public Card(string value,string suit) {

            this.value = value;
            this.suit = suit;
        }

        public string GetCard()
        {
            return value+suit;
        }


        public string GetValue() {
            return value;
        }

        public string GetSuit()
        {
            return suit;
        }








    }
}
