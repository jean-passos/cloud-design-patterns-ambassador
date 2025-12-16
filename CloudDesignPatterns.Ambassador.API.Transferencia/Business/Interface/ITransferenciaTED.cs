using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface
{
    public interface ITransferenciaTED
    {
        public Task<EntityTED> RealizaTransferencia(EntityTED transferenciaTED);
    }
}
