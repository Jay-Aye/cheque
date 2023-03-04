using cheque.Services.NumberConverterService;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace cheque.Tests.NumberConverterServiceTests
{
    public class ConvertToWords
    {
        private readonly IMock<ILogger<NumberConverterService>> _mockLogger;
        public ConvertToWords()
        {
            _mockLogger = new Mock<ILogger<NumberConverterService>>();
        }

        [Theory]
        [InlineData(0.22, "TWENTY-TWO CENTS ONLY")]
        [InlineData(2.22, "TWO DOLLARS AND TWENTY-TWO CENTS")]
        public async void Grammer_HandleWhenToShow_ONLY(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0.01, "ONE CENT ONLY")]
        [InlineData(1.22, "ONE DOLLAR AND TWENTY-TWO CENTS")]
        [InlineData(2.22, "TWO DOLLARS AND TWENTY-TWO CENTS")]
        public async void Grammer_HandleWhenToShow_PluralCentsAndDollars(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0.1234567, "TWELVE CENTS ONLY")]
        [InlineData(0.129, "TWELVE CENTS ONLY")]
        [InlineData(0.99999999999999, "NINETY-NINE CENTS ONLY")]
        public async void Maths_HandleRoundingDownDecimals(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1000, "ONE THOUSAND DOLLARS")]
        [InlineData(1234.56, "ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS AND FIFTY-SIX CENTS")]
        public async void Maths_HandleThousands(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1000000, "ONE MILLION DOLLARS")]
        [InlineData(1000100, "ONE MILLION ONE HUNDRED DOLLARS")]
        [InlineData(1234567, "ONE MILLION TWO HUNDRED THIRTY-FOUR THOUSAND FIVE HUNDRED SIXTY-SEVEN DOLLARS")]
        public async void Maths_HandleMillions(decimal number, string expectedResult)
        {
            // Arrange
            var numberConverterService = new NumberConverterService(_mockLogger.Object);

            // Act
            var actualResult = await numberConverterService.ConvertToWords(number);

            // Assert
            actualResult.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1000000000, "ONE BILLION DOLLARS")]
        [InlineData(1000000100, "ONE BILLION ONE HUNDRED DOLLARS")]
        [InlineData(1234567891, "ONE BILLION TWO HUNDRED THIRTY-FOUR MILLION FIVE HUNDRED SIXTY-SEVEN THOUSAND EIGHT HUNDRED NINETY-ONE DOLLARS")]
        public async void Maths_HandleBillions(decimal number, string expectedResult)
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