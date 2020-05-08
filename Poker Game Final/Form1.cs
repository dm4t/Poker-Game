using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker_Game_Final
{
    public partial class Form1 : Form
    {


        DeckOfCards Deck;
        Card[] card;

        string[] pc;
        string[] player;
        public Form1()
        {
            InitializeComponent();
            Deck = new DeckOfCards();
            pc = new string[5];
            player = new string[5];

            pictureBox1.Image = Image.FromFile("Images/Cards/Poker Large/" + "BB" + ".jpg");
            pictureBox2.Image = Image.FromFile("Images/Cards/Poker Large/" + "BB" + ".jpg");
            pictureBox3.Image = Image.FromFile("Images/Cards/Poker Large/" + "BB" + ".jpg");
            pictureBox4.Image = Image.FromFile("Images/Cards/Poker Large/" + "BB" + ".jpg");
            pictureBox5.Image = Image.FromFile("Images/Cards/Poker Large/" + "BB" + ".jpg");
            pictureBox6.Image = Image.FromFile("Images/Cards/Poker Large/" + "BR" + ".jpg");
            pictureBox7.Image = Image.FromFile("Images/Cards/Poker Large/" + "BR" + ".jpg");
            pictureBox8.Image = Image.FromFile("Images/Cards/Poker Large/" + "BR" + ".jpg");
            pictureBox9.Image = Image.FromFile("Images/Cards/Poker Large/" + "BR" + ".jpg");
            pictureBox10.Image = Image.FromFile("Images/Cards/Poker Large/"+ "BR" + ".jpg");





        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            
             
             card = Deck.ReturnHend();
            for (int i = 0; i < 5; i++)
            {
                player[i] = card[i].GetValue();
                //Console.WriteLine(card[i].GetValue());
            }
            for (int i = 5; i < 10; i++)
            {
                pc[i-5] = card[i].GetValue();
                //Console.WriteLine(card[i].GetValue());

            }


            pictureBox1.Image = Image.FromFile("Images/Cards/Poker Large/"+card[0].GetCard()+".jpg");
            pictureBox2.Image = Image.FromFile("Images/Cards/Poker Large/" + card[1].GetCard() + ".jpg");
            pictureBox3.Image = Image.FromFile("Images/Cards/Poker Large/" + card[2].GetCard() + ".jpg");
            pictureBox4.Image = Image.FromFile("Images/Cards/Poker Large/" + card[3].GetCard() + ".jpg");
            pictureBox5.Image = Image.FromFile("Images/Cards/Poker Large/" + card[4].GetCard() + ".jpg");
            pictureBox6.Image = Image.FromFile("Images/Cards/Poker Large/" + card[5].GetCard() + ".jpg");
            pictureBox7.Image = Image.FromFile("Images/Cards/Poker Large/" + card[6].GetCard() + ".jpg");
            pictureBox8.Image = Image.FromFile("Images/Cards/Poker Large/" + card[7].GetCard() + ".jpg");
            pictureBox9.Image = Image.FromFile("Images/Cards/Poker Large/" + card[8].GetCard() + ".jpg");
            pictureBox10.Image = Image.FromFile("Images/Cards/Poker Large/" + card[9].GetCard() + ".jpg");


            label3.Text = "Winner: " + Wins(card);
            
        }




        public string Wins(Card[] win)
        {

            string cardEvaluation;
            int[] valuesPC = new int[5];
            int[] valuesUser = new int[5];

            string[] suitPC = new string[5];
            string[] suitUser = new string[5];


            int userHand;
            int pcHand;

            bool userStreight = false;
            bool pcStreight = false;

            bool userFlash = false;
            bool pcFlash = false;

            int par = 0;

            bool pairV = false;
            bool three = false;


            //Card evaluationn get Values for the player and pc
            for (int i = 0; i < 5; i++)
            {

                cardEvaluation = win[i].GetValue();
                switch (cardEvaluation)
                {

                    case "A":
                        cardEvaluation = "11";
                        break;
                    case "J":
                        cardEvaluation = "12";
                        break;
                    case "Q":
                        cardEvaluation = "13";
                        break;
                    case "K":
                        cardEvaluation = "14";
                        break;
                    default:
                        cardEvaluation = win[i].GetValue();
                        break;
                }
                valuesUser[i] = int.Parse(cardEvaluation);
                //Console.WriteLine(valuesUser[i]);

            }

            Console.WriteLine("\n");

            for (int i = 5; i < 10; i++)
            {

                cardEvaluation = win[i].GetValue();
                switch (cardEvaluation)
                {

                    case "A":
                        cardEvaluation = "11";
                        break;
                    case "J":
                        cardEvaluation = "12";
                        break;
                    case "Q":
                        cardEvaluation = "13";
                        break;
                    case "K":
                        cardEvaluation = "14";
                        break;
                    default:
                        cardEvaluation = win[i].GetValue();
                        break;
                }
                valuesPC[i - 5] = int.Parse(cardEvaluation);
                //Console.WriteLine(valuesPC[i-5]);

            }


            var dict = new Dictionary<int, int>();

            //valuesUser[0] = 2;
            //valuesUser[1] = 3;
            //valuesUser[2] = 4;
            //valuesUser[3] = 5;
            //valuesUser[4] = 6;


            //valuesPC[0] = 6;
            //valuesPC[1] = 5;
            //valuesPC[2] = 4;
            //valuesPC[3] = 2;
            //valuesPC[4] = 3;




            Console.Clear();
            valuesUser = valuesUser.OrderByDescending(c => c).ToArray();



            if ((valuesUser[0] - 1) == valuesUser[1] && ((valuesUser[1] - 1) == valuesUser[2]) && ((valuesUser[2] - 1) == valuesUser[3]) && ((valuesUser[3] - 1) == valuesUser[4]))
            {

                userStreight = true;

            }


            foreach (var value in valuesUser)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            userHand = 1;
            Console.WriteLine("The Player:");
            foreach (var pair in dict)
            {
                if (pair.Value == 2)
                {
                    Console.WriteLine(pair.Key + " One Pair"); par++;

                }



                if (pair.Value == 3) {
                    three = true;
                    userHand = 4;
                    Console.WriteLine(pair.Key + " Three of King");
                    if (par == 3) { par = 1; }
                }
                if (pair.Value == 4) {
                    par = 0;
                    userHand = 8; Console.WriteLine(pair.Key + " Four of King"); }
            }
            if (par == 1)
            {
                pairV = true;
                userHand = 2;
            }
            if (par == 2)
            {



                Console.WriteLine("Two pair");
                userHand = 3;
            }

            if (pairV == true && three == true) {
                userHand = 7;
                Console.WriteLine("Full Hause");
            } else


            if (userStreight == true) {
                userHand = 5;
                Console.WriteLine("Streight Player");


            }



            if (userHand == 1 && three == false)
            {

                Console.WriteLine(valuesUser[0] + " High Card");
            }





            //Suit


            var dict1 = new Dictionary<int, int>();

            par = 0;

            foreach (var value in valuesPC)
            {
                if (dict1.ContainsKey(value))
                    dict1[value]++;
                else
                    dict1[value] = 1;
            }




            //Tis is Computer

            dict = new Dictionary<int, int>();
            par = 0;

            pairV = false;
            three = false;

            valuesPC = valuesPC.OrderByDescending(c => c).ToArray();

            if ((valuesPC[0] - 1) == valuesPC[1] && ((valuesPC[1] - 1) == valuesPC[2]) && ((valuesPC[2] - 1) == valuesPC[3]) && ((valuesPC[3] - 1) == valuesPC[4]))
            {

                pcStreight = true;

            }


            foreach (var value in valuesPC)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            pcHand = 1;
            Console.WriteLine("The Computer:");
            foreach (var pair in dict)
            {
                if (pair.Value == 2)
                {

                    Console.WriteLine(pair.Key + " One Pair"); par++;

                }



                if (pair.Value == 3)
                {
                    three = true;
                    Console.WriteLine(pair.Key + " Three of King");
                    pcHand = 4;
                    if (par == 3) { par = 1; }
                }
                if (pair.Value == 4)
                {
                    par = 0;
                    pcHand = 8; Console.WriteLine(pair.Key + " Four of King");
                }
            }
            if (par == 1 && pcHand != 4)
            {
                pairV = true;
                pcHand = 2;
            }
            if (par == 2)
            {
                //pairV = true;
                Console.WriteLine("Two pair");
                pcHand = 3;
            }

            if (pairV == true && three == true)
            {
                pcHand = 7;
                Console.WriteLine("Full Hause");
            }
            else


            if (pcStreight == true)
            {
                pcHand = 5;
            }

            if (pcHand == 5)
            {
                pcHand = 4;
                Console.WriteLine("Streight Computer");
            }

            if (pcHand == 1 && three == false)
            {
                pcHand = 1;
                Console.WriteLine(valuesPC[0] + " High Card");
            }



            // Suits
            string carsSuit;


            Console.WriteLine("\n");



            for (int i = 0; i < 5; i++)
            {

                carsSuit = win[i].GetSuit();

                suitUser[i] = carsSuit;
                // Console.WriteLine(valuesUser[i] + "  Znak "+suitUser[i]);

            }

            Console.WriteLine("\n");



            for (int i = 5; i < 10; i++)
            {

                carsSuit = win[i].GetSuit();

                suitPC[i - 5] = carsSuit;
                //Console.WriteLine(valuesPC[i-5]+"  Znak "+suitPC[i - 5]);

            }



            //suitUser[0] = "C";
            //suitUser[1] = "C";
            //suitUser[2] = "C";
            //suitUser[3] = "C";
            //suitUser[4] = "C";







            /* suits suits suits */


            var suits = new Dictionary<string, int>();

            Console.WriteLine("\n" +
                "\n" +
                "PLAYER PLAYER PLAYER PLAYER");

            foreach (var value in suitUser)
            {
                if (suits.ContainsKey(value))
                    suits[value]++;
                else
                    suits[value] = 1;
            }

            foreach (var pair in suits)
            {

                if (pair.Value == 5)
                {
                    Console.WriteLine(pair.Key + " Flash for Player");
                    userFlash = true;
                }
            }

            if (userFlash == true)
            {
                if (userStreight == true) {
                    if (valuesUser[0] == 14)
                    { Console.WriteLine("RF"); userHand = 10; }
                }

                if (userHand <= 5)
                {
                    userHand = 6;
                    Console.WriteLine("Flash");
                }
            }
            if (userFlash == true && userStreight == true) {
                userHand = 9;
                Console.WriteLine("Streight Flash for the Player");

            }

            Console.WriteLine("\n" +
                "\n");


            //PC 

            //suitPC[0] = "C";
            //suitPC[1] = "C";
            //suitPC[2] = "C";
            //suitPC[3] = "C";
            //suitPC[4] = "C";

            Console.WriteLine("COMPUTER COMPUTER COMPUTER COMPUTER");

            suits = new Dictionary<string, int>();

            foreach (var value in suitPC)
            {
                if (suits.ContainsKey(value))
                    suits[value]++;
                else
                    suits[value] = 1;
            }
            foreach (var pair in suits)
            {

                if (pair.Value == 5) { Console.WriteLine(pair.Key + " Flash for PC");
                    pcFlash = true;
                }
            }

            if (pcFlash == true)
            {
                if (pcStreight == true)
                {
                    if (valuesPC[0] == 14)
                    { Console.WriteLine("RF"); userHand = 10; }
                }

                if (pcHand <= 5)
                {
                    pcHand = 6;
                    Console.WriteLine("Flash");
                }
            }
            if (pcFlash == true && pcStreight == true)
            {
                pcHand = 9;

                Console.WriteLine("Streight Flash for the Computer");

            }


            Console.WriteLine("User Hend Power: " + userHand);
            Console.WriteLine("PC Hend Power: " + pcHand);














            if (userHand > pcHand)
            {
                return "Player Win";
            }
            else {
                return "Computer Win";
            }
        }


       









    }
}
