﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class _default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Display the reels upon page load
                string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
                displayImages(reels);
                ViewState.Add("PlayersMoney", 100);
                displayPlayersMoney();
            }
        }
        
        protected void leverButton_Click(object sender, EventArgs e)
        {
            int bet = 0;
                if(!int.TryParse(betBox.Text, out bet))return;

            int winnings = pullLever(bet);
            displayResult(bet, winnings);
            adjustPlayersMoney(bet, winnings);
            displayPlayersMoney();
        }

        private void displayPlayersMoney()
        {
            playersMoneyLabel.Text = String.Format("Player's Money {0:C}", ViewState["PlayersMoney"]);
        }

        private void adjustPlayersMoney(int bet, int winnings)
        {
            int playersMoney = int.Parse(ViewState["PlayersMoney"].ToString());
            playersMoney -= bet;
            playersMoney += winnings;
            ViewState["PlayersMoney"] = playersMoney;
        }

        private void displayResult(int bet, int winnings)
        {
            if (winnings > 0)
            {
                betSummaryLabel.Text = String.Format("You Bet {0:C} and won {1:C}", bet, winnings);
            }
            else
            {
                betSummaryLabel.Text = String.Format("Sorry, you lost {0:C}.  Better luck next time!", bet);
            }
        }

        private int pullLever(int bet)
        {
            string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
            displayImages(reels);
            int multiplier = evaluateSpin(reels);
            return bet * multiplier;
        }

        private int evaluateSpin(string[] reels)
        {
            if (isBar(reels)) return 0;
            if (isJackpot(reels)) return 100;
            int multiplier = 0;
            if(isWinner(reels, out multiplier)) return multiplier;
            return 0;
        }

        private bool isWinner(string[] reels, out int multiplier)
        {
            multiplier = determineCherryMultiplier(reels);
            if (multiplier > 0) return true;
            return false;
        }

        private int determineCherryMultiplier(string[] reels)
        {
            int cherryCount = determineCherryCount(reels);
            if (cherryCount == 1) return  2;
            if (cherryCount == 2) return  3;
            if (cherryCount == 3) return  4;
            return 0;
        }

        private int determineCherryCount(string[] reels)
        {
            int cherryCount = 0;
            if (reels[0] == "Cherry") cherryCount++;
            if (reels[1] == "Cherry") cherryCount++;
            if (reels[2] == "Cherry") cherryCount++;
            return cherryCount;
        }
        private bool isJackpot(string[] reels)
        {
            if (reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven")
                return true;
            else
                return false;
        }

        private bool isBar(string[] reels)
        {
            if (reels[0] == "Bar" || reels[1] == "Bar" || reels[2] == "Bar")
                return true;
            else
                return false;
        }

        private void displayImages(string[] reels)
        {
            Image1.ImageUrl = "/Images/" + reels[0] + ".png";
            Image2.ImageUrl = "/Images/" + reels[1] + ".png";
            Image3.ImageUrl = "/Images/" + reels[2] + ".png";

        }

        private string spinReel()
        {
            string[] images = new string[] {"Strawberry", "Bar", "Lemon", "Bell", "Diamond", "Cherry", "Seven", "Orange",
            "Clover", "HorseShoe", "Plum", "Watermelon"};
            
            return images[random.Next(11)];

        }
        
    }
}