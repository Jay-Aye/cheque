namespace cheque.Services.NumberConverterService
{
    public interface INumberConverterService
    {
        public Task<string> ConvertToWords(decimal number);
    }
    public class NumberConverterService : INumberConverterService
    {
        private readonly ILogger<NumberConverterService> _logger;

        public NumberConverterService(ILogger<NumberConverterService> logger)
        {
            _logger = logger;        
        }

        public async Task<string> ConvertToWords(decimal number)
        {


            return "";
        }
    }
}
