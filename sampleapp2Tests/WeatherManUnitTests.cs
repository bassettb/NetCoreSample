using NUnit.Framework;
using sampleapp;
using System;

namespace sampleappTests
{
    [TestFixture]
    public class WeatherManUnitTests
    {
        [Test]
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(6, false)]
        public void IsValidDayIndex_Values_CorrectResponse(int dayIndex, bool expectedOutput)
        {
            var weatherMan = new WeatherMan();            
            Assert.AreEqual(expectedOutput, weatherMan.IsValidDayIndex(dayIndex));
        }
    }
}