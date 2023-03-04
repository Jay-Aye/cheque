namespace cheque.Interfaces
{
    public interface INumberConverterService
    {
        public Task<string> ConvertToWords(decimal number);
    }
}
