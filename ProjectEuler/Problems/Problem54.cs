using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Problem54:IProblem
    {
        List<char> cards = new List<char>(){ '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
        public string Run()
        {
            string[] hands = File.ReadAllLines(Environment.CurrentDirectory + @"\Files\p054_poker.txt");
            int playerWins = 0;

            foreach (string hand in hands)
            {
                string player1 = hand.Substring(0, 14).Replace(" ","");
                string player2 = hand.Substring(15).Replace(" ", "");

                int p1Score = handScore(player1);
                int p2Score = handScore(player2);

                if (p1Score > p2Score || p1Score == p2Score && player1Wins(player1, p1Score, player2))
                {
                    playerWins++;
                }                   
            }

            return playerWins.ToString();

        }
        private bool player1Wins(string player1, int score, string player2) {

            player1 = String.Concat(player1.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i));
            player2 = String.Concat(player2.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i));
            //flush, straight, no hand
            if (score == 8 || score == 4 || score == 5 || score==0)
            {
                return player1HighCard(player1, player2).Value;
            }
            else if (score == 1 || score == 3 || score == 7)
            {
                IEnumerable<char> player1Group = player1.GroupBy(x=>x).Where(x=>x.Count()>1).Select(x=>x.First());
                IEnumerable<char> player2Group = player2.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.First());

                if (cards.IndexOf(player1Group.ElementAt(0)) > (cards.IndexOf(player2Group.ElementAt(0))))
                    return true;
                else if (cards.IndexOf(player1Group.ElementAt(0)) == (cards.IndexOf(player2Group.ElementAt(0))))
                {
                    return player1HighCard(String.Concat(player1.GroupBy(x => x).Where(x => x.Count() == 1).SelectMany(x => x)), String.Concat(player2.GroupBy(x => x).Where(x => x.Count() == 1).SelectMany(x => x))).Value;
                }
            }
            else
            {
                IEnumerable<char> player1Groups = player1.GroupBy(x => x).Where(x => x.Count() > 1).SelectMany(x => x);
                IEnumerable<char> player2Groups = player2.GroupBy(x => x).Where(x => x.Count() > 1).SelectMany(x => x);
                
                bool? result = player1HighCard(String.Concat(player1Groups), String.Concat(player2Groups));
                if (result.HasValue)
                    return result.Value;
                else
                    return player1HighCard(String.Concat(player1.GroupBy(x => x).Where(x => x.Count() == 1).SelectMany(x => x)), String.Concat(player2.GroupBy(x => x).Where(x => x.Count() == 1).SelectMany(x => x))).Value;
            }

            return false;
        }
        private bool? player1HighCard(string player1, string player2)
        {
            IEnumerable<char> p1Score = from card in player1.Select(x => x)
                      orderby cards.IndexOf(card) descending
                      select card;
            IEnumerable<char> p2Score = from card in player2.Select(x => x)
                      orderby cards.IndexOf(card) descending
                      select card;
            for (int i = 0; i < p1Score.Count(); i++)
            {
                if (cards.IndexOf(p1Score.ElementAt(i)) > (cards.IndexOf(p2Score.ElementAt(i))))
                    return true;
                else if (cards.IndexOf(p1Score.ElementAt(i)) < (cards.IndexOf(p2Score.ElementAt(i))))
                    return false;
            }
            return null;
        }
        private int handScore(string hand) {

            int score = 0;
            int pairs = pair(hand);
            bool triples = triple(hand);
            bool quads = quad(hand);
            bool straight = isStraight(hand);
            bool flush = isFlush(hand);

            if(pairs>=1)
            {
                score = pairs;
            }
            if(triples)
            {
                score = 3;
            }
            if (quads)
            {
                score = 7;
            }
            if (pairs == 1 && triples)
            {
                score = 6;
            }
            else if (flush && straight)
                score = 8;
            else if (straight)
                score = 4;
            else if (flush)
                score = 5;

            return score;

        }
        private bool quad(string hand)
        {
            char[] numbers = hand.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i).ToArray();
            return numbers.GroupBy(x => x).Where(x => x.Count() == 4).Count() == 1;
        }
        private int pair(string hand)
        {
            char[] numbers = hand.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i).ToArray();
            return numbers.GroupBy(x => x).Where(x => x.Count() == 2).Count();
        }
        private bool triple(string hand)
        {
            char[] numbers = hand.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i).ToArray();
            return numbers.GroupBy(x => x).Where(x => x.Count() == 3).Count()==1;
        }
        private bool isStraight(string hand)
        {
            IEnumerable<char> numbers = from card in hand.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 0).Select(q => q.i)
                      orderby cards.IndexOf(card)
                      select card;
            bool straight = true;
            for (int i = 0; i < numbers.Count() - 1; i++)
                straight = straight && cards.IndexOf(numbers.ElementAt(i)) + 1 == cards.IndexOf(numbers.ElementAt(i+1));

            return straight;
        }
        private bool isFlush(string hand)
        {
            char[] suits = hand.Select((i, x) => new { i, x }).Where(a => a.x % 2 == 1).Select(q => q.i).ToArray();
            return suits.Distinct().Count() == 1;
        }
    }
}
