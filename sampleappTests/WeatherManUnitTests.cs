using Xunit;
using System;
using sampleapp;

namespace sampleappTests
{
    public class WeatherManUnitTests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(8, false)]
        public void IsValidDayIndex_Values_CorrectResponse(int dayIndex, bool expectedOutput)
        {
            var weatherMan = new WeatherMan();
            
            Assert.Equal(expectedOutput, weatherMan.IsValidDayIndex(dayIndex));
        }
    }
}