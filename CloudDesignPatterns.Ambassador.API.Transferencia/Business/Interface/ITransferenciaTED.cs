using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface
{
    public interface ITransferenciaTED
    {
        public Task<string> RealizaTransferencia(EntityTED transferenciaTED);
    }
}
