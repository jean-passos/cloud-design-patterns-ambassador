using CloudDesignPatterns.Ambassador.API.ContaCorrente.Business.Interface;

namespace CloudDesignPatterns.Ambassador.API.ContaCorrente.Business
{
    public class Saldo : ISaldo
    {
        public Task<decimal> ObterSaldo(string documento, string nro_conta)
        {
            //simulate a call to an external system
            // and return a fixed value for demonstration purposes
            // In a real implementation, you would replace this with actual logic

            return Task.FromResult(1000.00M);
        }
    }
}
