using NUnit.Framework;
using Shouldly;
using StandardUtils.Helpers;

namespace StandardUtils.Unit.Tests.Helpers
{
    [TestFixture]
    public class StringHelperTests
    {
        [TestCase("test")]
        [TestCase("test_caliskan")]
        public void StringHelper_IsAlphabeticalOrUnderscore(string text)
        {
            Assert.True(text.IsAlphabeticalOrUnderscore());
        }

        [TestCase("Test12345")]
        [TestCase("Test12345*")]
        public void StringHelper_IsValidPassword(string text)
        {
            Assert.True(text.IsValidPassword());
        }

        [TestCase("testcaliskan")]
        [TestCase("12345678")]
        [TestCase("TESTCALISKAN")]
        [TestCase("test112345656")]
        [TestCase("Testcasdasdcas")]
        [TestCase("TEST1SDFSLKDJFKLS")]
        [TestCase("Test1")]
        public void StringHelper_IsNotValidPassword(string text)
        {
            Assert.True(text.IsNotValidPassword());
        }

        [TestCase("test@test.com")]
        [TestCase("test.caliskan@test.com")]
        public void StringHelper_IsEmail(string text)
        {
            Assert.True(text.IsEmail());
        }

        [TestCase("testtest.com")]
        [TestCase("testtestcom")]
        [TestCase(".com")]
        public void StringHelper_IsNotEmail(string text)
        {
            Assert.True(text.IsNotEmail());
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        [TestCase(null)]
        public void StringHelper_IsEmpty(string text)
        {
            Assert.True(text.IsEmpty());
        }

        [TestCase("test")]
        public void StringHelper_IsNotEmpty(string text)
        {
            Assert.True(text.IsNotEmpty());
        }
        
        [TestCase("TRUE")]
        [TestCase("1")]
        public void StringHelper_IsTrue(string text)
        {
            Assert.True(text.IsTrue());
        }
        
        [TestCase("")]
        [TestCase("test")]
        public void StringHelper_IsFalse(string text)
        {
            Assert.True(text.IsFalse());
        }

        [TestCase("http://www.google.com")]
        [TestCase("https://hype.games/")]
        [TestCase("http://hype.games/")]
        [TestCase("http://hype.games")]
        public void StringHelper_IsUrl(string text)
        {
            Assert.True(text.IsUrl());
        }

        [TestCase("www.google.com")]
        [TestCase("google.com")]
        [TestCase("asdasd")]
        public void StringHelper_IsNotUrl(string text)
        {
            Assert.True(text.IsNotUrl());
        }

        [TestCase("")]
        public void StringHelper_IsValidCronExpression_False(string text)
        {
            Assert.False(text.IsValidCronExpression());
        }

        [TestCase("0 0 0 ? APR,MAY * 2019,2020,2021")]
        public void StringHelper_IsValidCronExpression_True(string text)
        {
            Assert.True(text.IsValidCronExpression());
        }

        [TestCase("A 0 0 ? APR,MAY * 2019,2020,2021")]
        public void StringHelper_IsNotValidCronExpression_True(string text)
        {
            Assert.True(text.IsNotValidCronExpression());
        }

        [TestCase("  trime text  ")]
        [TestCase("trime text  ")]
        [TestCase("  trime text")]
        public void StringHelper_TrimOrDefault_Trim(string text)
        {
            var trimmedText = text.Trim();
            text.TrimOrDefault().ShouldBe(trimmedText);
        }

        [TestCase(null)]
        public void StringHelper_TrimOrDefault_Null(string text)
        {
            text.TrimOrDefault().ShouldBe("");
        }

        [TestCase("   textDeneme", "textDeneme")]
        [TestCase("text    Deneme", "textDeneme")]
        [TestCase("textDeneme   ", "textDeneme")]
        [TestCase("   text   Deneme   ", "textDeneme")]
        public void StringHelper_CleanWhiteSpace(string text, string result)
        {
            text.CleanWhitespaces().ShouldBe(result);
        }
    }
}