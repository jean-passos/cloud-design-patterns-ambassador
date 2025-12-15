using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Data;
using CoreWCF;

namespace CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Contract
{
    [ServiceContract]
    public interface ITransferenciaTED
    {
        [OperationContract]
        string RealizaTransferenciaTED(RequestTransferenciaTED requestTransferencia);
    }
}
