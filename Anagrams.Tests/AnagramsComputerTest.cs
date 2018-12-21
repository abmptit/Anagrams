using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;

namespace Anagrams.Tests
{
    public class AnagramsComputerTest
    {

        [Fact]
        public void GenerateAnagramsSample1()
        {
            //act 
            List<string> wordList =
                "kinship pinkish enlist inlets listen silent boaster boaters borates fresher refresh sinks skins knits stink rots sort"
                    .Split(' ').ToList();
            wordList.Shuffle();

            List<string> expectedOutput = new List<string>
            {
                "boaster boaters borates",
                "enlist inlets listen silent",
                "fresher refresh",
                "kinship pinkish",
                "knits stink",
                "rots sort",
                "sinks skins",
            };


            //arrange
            //var result = wordList.GenerateAnagrams("enlist");
            var result = wordList.GenerateAnagrams();

            //assert
            Assert.Equal(result, expectedOutput);
        }

        [Theory]
        [InlineData("peter", "repet")]
        [InlineData("azerty", "yteraz")]
        public void IsAnagramTest(string word1, string word2)
        {
            var result = AnagramsComputer.IsAnagram(word1, word2);
            Assert.True(result);
        }

        [Fact]
        public void GenerateAnagramsSample2()
        {
            //act 
            List<string> wordList =
                "crepitus cuprites pictures piecrust paste pates peats septa spate tapes tepas punctilio unpolitic sunders undress"
                    .Split(' ').ToList();
            wordList.Shuffle();

            List<string> expectedOutput = new List<string>
            {
                "crepitus cuprites pictures piecrust",
                "paste pates peats septa spate tapes tepas",
                "punctilio unpolitic",
                "sunders undress"
            };


            //arrange
            //var result = wordList.GenerateAnagrams("enlist");
            var result = wordList.GenerateAnagrams();

            //assert
            Assert.Equal(result, expectedOutput);
        }

        [Fact]
        public void GenerateAnagramsFromFile()
        {
            string text = System.IO.File.ReadAllText(@"shortwordlist.txt");
            List<string> wordList = text.Split("\r\n").ToList();
            
            string expectText = System.IO.File.ReadAllText(@"expectedresultshortwordlist.txt");
            List<string> expectedOutput = expectText.Split("\r\n").ToList();

            var result = wordList.GenerateAnagrams();
            string contentResult = string.Join("<br/>\r\n", result);

            //assert
            Assert.Equal(result, expectedOutput);
        }

        [Fact]
        public void GenerateAnagramsFromHugeFile()
        {
            string text = System.IO.File.ReadAllText(@"wordlist.txt");
            List<string> wordList = text.Split("\r\n").ToList();

            string expectText = System.IO.File.ReadAllText(@"expectedresultwordlist.txt");
            List<string> expectedOutput = expectText.Split("\r\n").ToList();

            var result = wordList.GenerateAnagrams();
            string contentResult = string.Join("\r\n", result);

            //assert
            Assert.Equal(result, expectedOutput);
        }
    }
}
