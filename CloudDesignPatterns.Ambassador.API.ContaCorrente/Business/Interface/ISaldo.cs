namespace CloudDesignPatterns.Ambassador.API.ContaCorrente.Business.Interface
{
    public interface ISaldo
    {
        public Task<decimal> ObterSaldo(string documento, string nro_conta);
    }
}
