using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Contract;
using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Data;

namespace CloudDesignPatterns.Ambassador.Service.ServicoTransferencia
{
    public class TransferenciaTEDService : ITransferenciaTED
    {
        public string RealizaTransferenciaTED(RequestTransferenciaTED requestTransferencia)
        {
            return Guid.NewGuid().ToString("N").ToUpper().Substring(0, 15);
        }
    }
}
