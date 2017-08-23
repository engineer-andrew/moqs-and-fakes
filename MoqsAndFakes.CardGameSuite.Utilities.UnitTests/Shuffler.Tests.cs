using System;
using System.Collections.Generic;
using Xunit;

namespace MoqsAndFakes.CardGameSuite.Utilities.UnitTests
{
    public class ShufflerTests : IDisposable
    {
        private readonly Shuffler _shuffler;

        public ShufflerTests()
        {
            _shuffler = new Shuffler();
        }

        [Fact]
        public void ShuffleShouldShuffleSingleDeckOfCards()
        {
            // arrange
            var originalDeck = new List<string>
            {
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS",
                "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD"
            };

            // act
            var result = _shuffler.Shuffle(1);

            // assert
            Assert.NotEqual(originalDeck, result);
        }

        [Fact]
        public void ShuffleShouldShuffleMultipleDecksOfCards()
        {
            // arrange
            var originalDeck = new List<string>
            {
                "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS",
                "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH",
                "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC",
                "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD"
            };
            var multipleDecks = new List<string>();
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);
            multipleDecks.AddRange(originalDeck);

            // act
            var result = _shuffler.Shuffle(8);

            // assert
            Assert.NotEqual(multipleDecks, result);
        }

        [Fact]
        public void ShuffleShouldShuffleCardsInDifferentOrderEveryTime()
        {
            // arrange
            var firstRun = _shuffler.Shuffle(8);

            // act
            var result = _shuffler.Shuffle(8);

            // assert
            Assert.NotEqual(firstRun, result);
        }

        public void Dispose()
        {
        }
    }
}