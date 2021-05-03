using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Cards.Models;

namespace Cards.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            List<Card> Hand = new List<Card>();
            Hand.Add(deck.Deal());
            Hand.Add(deck.Deal());
            string playerScore = getScoreFromHand(Hand);
            Console.WriteLine(playerScore);
            List<Card> Dealer = new List<Card>();
            Dealer.Add(deck.Deal());
            Dealer.Add(deck.Deal());
            string dealerScore = getScoreFromHand(Dealer);
            Console.WriteLine(dealerScore);
            ViewBag.Hand = Hand;
            ViewBag.Dealer = Dealer;
            ViewBag.playerScore = playerScore;
            ViewBag.dealerScore = dealerScore;
            return View(Hand);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public static string getScoreFromHand(List<Card> Hand)
        {
            int[] score =  {0,0};
            foreach(Card c in Hand)
            {
                if(c.Value > 10)
                {
                    score[0] += 10;
                    if(score[1] != 0)
                        score[1] += 10;
                }
                else if(c.Value == 1)
                {
                    if(score[0] == 0)
                    {
                        score[0] = 1;
                        score[1] = 11;
                    }
                    else
                    {
                        score[0] += 1;
                        score[1] = score[0] + 10;
                    }
                }
                else
                {
                    score[0] += c.Value;
                    if(score[1] != 0)
                        score[1] += c.Value;
                }
            }
            if(score[1] == 0)
            {
                return score[0].ToString();
            }
            else
            {
                return $"{score[0]}, {score[1]}";
            }
        }
    }
}
