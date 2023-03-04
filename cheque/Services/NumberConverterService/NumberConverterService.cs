using cheque.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cheque.Services.NumberConverterService
{
    public class NumberConverterService : INumberConverterService
    {
        private readonly ILogger<NumberConverterService> _logger;

        string[] ones = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        string[] tens = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        string[] thousands = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };

        public NumberConverterService(ILogger<NumberConverterService> logger)
        {
            _logger = logger;        
        }

        public async Task<string> ConvertToWords(decimal number)
        {
            string result = "";

            int dollars = (int)number;
            int cents = (int)Math.Floor((number - dollars) * 100);

            if (dollars > 0)
            {
                result = ConvertDollarsToWords(dollars);
            }

            if (cents > 0)
            {
                result += ConvertCentsToWords(cents, dollars);
            }

            return result.Trim();
        }

        private string ConvertDollarsToWords(int dollars)
        {
            var result = "";
            var log10 = (int)(Math.Log10(dollars) / 3);

            var workingDollar = dollars;
            var timesOfThousands = 0;

            while (log10 >= 0)
            {
                var dollarToConvert = workingDollar % 1000;
                if (dollarToConvert != 0)
                {
                    result = thousands[timesOfThousands] + " " + result;
                    result = ConvertThreeDigitNumberToWords(dollarToConvert) + " " + result;
                }

                workingDollar = workingDollar / 1000;
                log10--;
                timesOfThousands++;
                result = result.Trim();
            }

            result += HandlePlurality(dollars, " DOLLAR");

            return result;
        }

        private string ConvertCentsToWords(int cents, int dollars)
        {
            var result = "";

            result += ConvertTwoDigitNumberToWords(cents);
            result += HandlePlurality(cents, " CENT");

            if (dollars == 0)
            {
                result += " ONLY";
            }
            else
            {
                result = " AND " + result;
            }

            return result;
        }

        private string HandlePlurality(int amount, string denomination)
        {
            var response = denomination;

            if (amount != 1)
            {
                response += "S";
            }

            return response;
        }

        private string ConvertThreeDigitNumberToWords(int number)
        {
            string result = "";

            if (number >= 100)
            {
                result += ones[number / 100] + " HUNDRED ";
                number %= 100;
            }

            result += ConvertTwoDigitNumberToWords(number);

            return result.Trim();
        }

        private string ConvertTwoDigitNumberToWords(int number)
        {
            if (number < 20)
            {
                return ones[number];
            }

            string result = tens[number / 10] + "-";
            if (number % 10 > 0)
            {
                result += ones[number % 10];
            }

            return result.Trim();
        }
    }
}
