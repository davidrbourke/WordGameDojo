using System;
using Xunit;
using FluentAssertions;
using WordGame;

namespace WordGameTests
{
    public class WordTests
    {
        //[Fact]
        //public void WordGame_FindWordInSingleWord_WordFound()
        //{
        //    var input = "het";
        //    var matchedWord = "the";

        //    var result = new Word().FindWord(input, matchedWord);

        //    result.Should().Be("the");
        //}

        //[Fact]
        //public void WordGame_FindWordInSingleWord_WordNotFound()
        //{
        //    var input = "het";
        //    var matchedWord = "tha";

        //    var result = new Word().FindWord(input, matchedWord);

        //    result.Should().BeEmpty();
        //}

        [Theory]
        [InlineData("het", "the", "the")]
        [InlineData("het", "tha", "")]
        [InlineData("ttha", "that", "that")] // Repeating letters
        [InlineData("tha", "that", "")]
        public void WordGame_FindWord_ResultReturned(string input, string dictionary, string result)
        {
            var foundWord = new Word().FindWord(input, dictionary);

            foundWord.Should().Be(result);
        }

        [Theory]
        [InlineData("het", new[] { "the", "and" }, "the")]
        [InlineData("htee", new[] { "thee", "the" }, "thee")] // Longest word
        public void WordGame_FindWordFromMultipleWords_ResultReturned(string input, string[] dictionary, string result)
        {
            var foundWord = new Word().FindWord(input, dictionary);

            foundWord.Should().Be(result);
        }
    }
}
