using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Cards.Models;
using Microsoft.AspNetCore.Http;

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
            Player player1 = new Player();
            List<CardInHand> player1Cards = new List<CardInHand>();
            Card firstCard = deck.Deal();
            Card secondCard = deck.Deal();

            player1Cards.Add(new CardInHand(firstCard.Face, firstCard.Suit, firstCard.Value, firstCard.ImgURL));
            player1Cards.Add(new CardInHand(secondCard.Face, secondCard.Suit, secondCard.Value, secondCard.ImgURL));
            player1.CardsInHand = player1Cards;
            string playerScore = getScoreFromHand(player1.CardsInHand);
            Player dealer = new Player();
            List<CardInHand> dealerCards = new List<CardInHand>();
            
            firstCard = deck.Deal();
            secondCard = deck.Deal();
            
            dealerCards.Add(new CardInHand(firstCard.Face, firstCard.Suit, firstCard.Value, firstCard.ImgURL));
            dealerCards.Add(new CardInHand(secondCard.Face, secondCard.Suit, secondCard.Value, secondCard.ImgURL, false));
            dealer.CardsInHand = dealerCards;
            string dealerScore = getScoreFromHand(dealer.CardsInHand);

            _context.Add(deck);
            _context.Add(player1);
            _context.Add(dealer);
            _context.SaveChanges();

            int thisDeck = _context.Decks.OrderByDescending(d => d.DeckId).FirstOrDefault().DeckId;
            int thisPlayer = _context.Players.OrderByDescending(p => p.PlayerId).FirstOrDefault().PlayerId;
            

            HttpContext.Session.SetInt32("PlayerId", thisPlayer);
            HttpContext.Session.SetInt32("DeckId", thisDeck);

            ViewBag.Hand = player1.CardsInHand;
            ViewBag.Dealer = dealer.CardsInHand;
            ViewBag.Display = false;
            ViewBag.playerScore = playerScore;
            ViewBag.dealerScore = dealerScore;
            return View();
        }

        [HttpGet("/hit")]
        public IActionResult Hit()
        {
            int? playerId = HttpContext.Session.GetInt32("PlayerId");
            int? DealerId = playerId - 1;
            int? deckId = HttpContext.Session.GetInt32("DeckId");

            Player player1 = _context.Players
                .Include(p => p.CardsInHand)
                .FirstOrDefault(p => p.PlayerId == playerId - 1);
            if(player1 == null)
                return RedirectToAction("Index");
            Player dealer = _context.Players
                .Include(d => d.CardsInHand)
                .FirstOrDefault(p => p.PlayerId == playerId);
            var deck = _context.Decks
                .Include(d => d.CardsInDeck)
                .FirstOrDefault(d => d.DeckId == deckId);

            foreach(var c in deck.CardsInDeck)
                Console.WriteLine(c);
            for (int i = 0; i < 52; i++)
            {
                deck.Deal();
            }
            Card hitCard = deck.Deal();

            player1.CardsInHand.Add(new CardInHand(hitCard.Face, hitCard.Suit, hitCard.Value, hitCard.ImgURL));
            
            string playerScore = getScoreFromHand(player1.CardsInHand);
            string dealerScore = getScoreFromHand(dealer.CardsInHand);

            
            ViewBag.Hand = player1.CardsInHand;
            ViewBag.Dealer = dealer.CardsInHand;
            ViewBag.Display = false;
            ViewBag.playerScore = playerScore;
            ViewBag.dealerScore = dealerScore;
            
            //update the deck in the database
            _context.Update(deck);
            _context.SaveChanges();

            Console.WriteLine("HIT");
            return View("Index");
        }

        [HttpGet("/stay")]
        public IActionResult Stay()
        {
            int? playerId = HttpContext.Session.GetInt32("PlayerId");
            int? DealerId = playerId - 1;
            int? deckId = HttpContext.Session.GetInt32("DeckId");

            Player player1 = _context.Players
                .Include(p => p.CardsInHand)
                .FirstOrDefault(p => p.PlayerId == playerId - 1);
            if(player1 == null)
                return RedirectToAction("Index");

            Player dealer = _context.Players
                .Include(d => d.CardsInHand)
                .FirstOrDefault(p => p.PlayerId == playerId);
            
            dealer.CardsInHand[0].Shown = true;
            var deck = _context.Decks
                .Include(d => d.CardsInDeck)
                .FirstOrDefault(d => d.DeckId == deckId);

            foreach(var c in deck.CardsInDeck)
                Console.WriteLine(c);
            for (int i = 0; i < 52; i++)
            {
                deck.Deal();
            }

            string playerScore = getScoreFromHand(player1.CardsInHand);
            string dealerScore = getScoreFromHand(dealer.CardsInHand);

            Console.WriteLine(dealerScore);
            List<int> dealerScoreList = getScoreFromString(dealerScore);
            foreach(var _ in dealerScoreList)
                Console.WriteLine(_);
            
            while(dealerScoreList[0] < 17)
            {
                //deal the card to dealer
                Card hitCard = deck.Deal();
                dealer.CardsInHand.Add(new CardInHand(hitCard.Face, hitCard.Suit, hitCard.Value, hitCard.ImgURL));
                dealerScore = getScoreFromHand(dealer.CardsInHand);
                dealerScoreList = getScoreFromString(dealerScore);
            }
            ViewBag.Hand = player1.CardsInHand;
            ViewBag.Dealer = dealer.CardsInHand;
            ViewBag.Display = true;
            ViewBag.playerScore = playerScore;
            ViewBag.dealerScore = dealerScore;
            Console.WriteLine("Staying");
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public static string getScoreFromHand(List<CardInHand> Hand)
        {
            int[] score =  {0,0};
            foreach(CardInHand c in Hand)
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
        
        public List<int> getScoreFromString(string score)
        {
            string[] scoreString = score.Split(",");
            List<int> returnInt = new List<int>();
            foreach(var s in scoreString)
                returnInt.Add(Int32.Parse(s));               

            return returnInt;
        }
    }
}
