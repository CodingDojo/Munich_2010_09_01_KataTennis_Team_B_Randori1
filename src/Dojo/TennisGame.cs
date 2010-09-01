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

        [Test]
        public void When_PlayerB_has_40_and_PlayerA_has_40_PlayerB_scores_to_advantage()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);
            game.Score(TennisPlayer.PlayerA);

            game.Score(TennisPlayer.PlayerB);
            game.Score(TennisPlayer.PlayerB);
            game.Score(TennisPlayer.PlayerB);

            game.Score(TennisPlayer.PlayerB);

            Assert.That(game.PointsB, Is.EqualTo(TennisScore.Advantage));
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

        public Dictionary<TennisPlayer, TennisScore> Scores { get; set; }

        public TennisScore PointsB { get; set; }
        public TennisScore PointsA { get; set; }

        public void Score(TennisPlayer player)
        {
            if (player == TennisPlayer.PlayerA)
            {
                this.PointsA += 1;

                if (this.PointsB != TennisScore.Forty &&
                    this.PointsA == TennisScore.Advantage)
                {
                    this.PointsA = TennisScore.Game;
                    this.IsGameOver = true;
                }
             }
            else
            {
                this.PointsB += 1;
            }
       

             
        }
    }
}
