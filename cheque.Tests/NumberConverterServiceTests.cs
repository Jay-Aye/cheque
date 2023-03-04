using cheque.Services.NumberConverterService;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace cheque.Tests
{
    public class NumberConverterServiceTests
    {
        private readonly IMock<ILogger<NumberConverterService>> _mockLogger;
        public NumberConverterServiceTests()
        {
            _mockLogger = new Mock<ILogger<NumberConverterService>>();
        }

        [Theory]
        [InlineData(1234.56, "ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS AND FIFTY-SIX CENTS")]
        [InlineData(0.22, "TWENTY-TWO CENTS ONLY")]
        [InlineData(102.03, "ONE HUNDRED TWO DOLLARS AND THREE CENTS")]
        [InlineData(1.021, "ONE DOLLAR AND TWO CENTS")]
        [InlineData(1.23987, "ONE DOLLAR AND TWENTY-THREE CENTS")]
        public async void ConvertToWords_WhenGivenDecimals_ConvertToStrings(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }
    }
}