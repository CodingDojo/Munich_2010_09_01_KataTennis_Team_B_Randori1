﻿using System;
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
        public void PointsA_Player_A_Starts_With_Zero_Points()
        {
            TennisGame game = new TennisGame();
            Assert.AreEqual(0, game.PointsA);
        }

        [Test]
        public void PointsB_Player_B_Starts_With_Zero_Points()
        {
            TennisGame game = new TennisGame();
            Assert.AreEqual(0, game.PointsB);
        }

        [Test]
        public void When_PlayerB_Scores_Starting_With_Zero_Then_PlayerB_Has_15()
        {
            TennisGame game = new TennisGame();

            game.Score(TennisPlayer.PlayerB);

            Assert.That(game.PointsB, Is.EqualTo(15));
        }
    }
    public enum TennisPlayer
    {
        PlayerA,
        PlayerB
    }

    public class TennisGame
    {
        public bool IsGameOver { get; set; }

        public int PointsB { get; set; }

        public int PointsA { get; set; }

        public void Score(TennisPlayer player)
        {
            this.PointsB += 15;
        }
    }
}
