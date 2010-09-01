using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Dojo
{
    [TestFixture]
    public class TennisGameTests
    {
        [Test]
        public void When_Each_Player_Have_No_Points_Then_Game_Is_Not_Over()
        {
            TennisGame game = new TennisGame();
            bool isOver = game.IsGameOver;
            Assert.That(isOver, Is.False);
        }

        [Test]
        public void When_A_Player_Scores_Four_Times_Then_Game_Is_Over()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);

            bool isOver = game.IsGameOver;
            Assert.That(isOver, Is.True);
        }

        [Test]
        public void PointsA_Player_A_Starts_With_Zero_Points()
        {
            TennisGame game = new TennisGame();
            Assert.AreEqual(TennisScore.Love, game.PointsA);
        }

        [Test]
        public void PointsB_Player_B_Starts_With_Zero_Points()
        {
            TennisGame game = new TennisGame();
            Assert.AreEqual(TennisScore.Love, game.PointsB);
        }

        [Test]
        public void When_PlayerB_Scores_Starting_With_Zero_Then_PlayerB_Has_15()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerB);

            Assert.That(game.PointsB, Is.EqualTo(TennisScore.Fifteen));
        }

        [Test]
        public void When_PlayerA_Scores_Starting_With_Zero_Then_PlayerA_Has_15()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);

            Assert.That(game.PointsA, Is.EqualTo(TennisScore.Fifteen));
        }

        [Test]
        public void When_PlayerA_Scores_Two_Times_Then_PlayerA_Has_30()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);


            Assert.That(game.PointsA, Is.EqualTo(TennisScore.Thirty));
        }

        [Test]
        public void When_PlayerA_Scores_Three_Times_Then_PlayerA_Has_40()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);

            Assert.That(game.PointsA, Is.EqualTo(TennisScore.Forty));
        }

        [Test]
        public void When_PlayerA_scores_4times_PointsA_Equals_Game()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);

            Assert.That(game.PointsA, Is.EqualTo(TennisScore.Game));
        }

        [Test]
        public void When_PlayerA_has_40_and_PlayerB_has_40_PlayerA_scores_to_advantage()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);

            game.Score(TennisPlayer.PlayerB);
            game.Score(TennisPlayer.PlayerB);
            game.Score(TennisPlayer.PlayerB);

            game.Score(TennisPlayer.PlayerA);

            Assert.That(game.PointsA, Is.EqualTo(TennisScore.Advantage));
        }

        

        [TestCase(TennisPlayer.PlayerA)]
        [TestCase(TennisPlayer.PlayerB)]
        public void When_PlayerB_has_40_and_PlayerA_has_40_PlayerB_scores_to_advantagePar(TennisPlayer player)
        {
            TennisGame game = new TennisGame();

            TennisPlayer otherPlayer = TennisPlayer.PlayerA;
            if (player == TennisPlayer.PlayerA)
                otherPlayer = TennisPlayer.PlayerB;

            game.Score(player);
            game.Score(player);
            game.Score(player);

            game.Score(otherPlayer);
            game.Score(otherPlayer);
            game.Score(otherPlayer);

            game.Score(otherPlayer);

            Assert.That(game.Points(otherPlayer), Is.EqualTo(TennisScore.Advantage));
        }
    }
    public enum TennisPlayer
    {
        PlayerA,
        PlayerB
    }

    public enum TennisScore
    {
        Love,
        Fifteen,
        Thirty,
        Forty,
        Advantage,
        Game
    }

    public class TennisGame
    { 
        public bool IsGameOver { get; set; }

        private Dictionary<TennisPlayer, TennisScore> scores =
            new Dictionary<TennisPlayer, TennisScore>()
                {
                    {TennisPlayer.PlayerA, TennisScore.Love},
                    {TennisPlayer.PlayerB, TennisScore.Love}
                };

        public TennisScore PointsB 
        {
            get { return this.scores[TennisPlayer.PlayerB]; }
        }

        public TennisScore PointsA
        {
            get { return this.scores[TennisPlayer.PlayerA]; }
        }

        public void Score(TennisPlayer player)
        {
            TennisPlayer otherPlayer = TennisPlayer.PlayerA;

            if (player == TennisPlayer.PlayerA)
                otherPlayer = TennisPlayer.PlayerB;

            this.scores[player] += 1;

            if (this.scores[otherPlayer] != TennisScore.Forty &&
                this.scores[player] == TennisScore.Advantage)
            {
                this.scores[player] = TennisScore.Game;
                this.IsGameOver = true;
            }
        }

        public TennisScore Points(TennisPlayer player)
        {
            return scores[player];
        }
    }
}
