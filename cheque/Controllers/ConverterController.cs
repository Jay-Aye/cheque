using cheque.Services.NumberConverterService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace cheque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : Controller
    {
        private readonly INumberConverterService _numberConverterService;
        public ConverterController(INumberConverterService numberConverterService)
        {
            _numberConverterService = numberConverterService;
        }

        [Description("Converts a decimal number to words in the format of a cheque")]
        [HttpPost]
        public Task<string> ConvertNumbersToWords(decimal number)
        {
            if (number <= 0)
            {
                throw new Exception("Number must be greater than 0");
            }

            var result = _numberConverterService.ConvertToWords(number);

            return result;
        }
    }
}
