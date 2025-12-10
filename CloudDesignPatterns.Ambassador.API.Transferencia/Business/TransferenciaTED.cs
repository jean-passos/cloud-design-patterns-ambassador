using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Business
{
    public class TransferenciaTED : ITransferenciaTED
    {
        public async Task<string> RealizaTransferencia(EntityTED transferenciaTED)
        {
            await Task.CompletedTask;
            return "STR.......";
            throw new NotImplementedException();
        }
    }
}
