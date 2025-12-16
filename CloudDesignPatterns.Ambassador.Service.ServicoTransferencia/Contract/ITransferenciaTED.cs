using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Data;
using CoreWCF;

namespace CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Contract
{
    [ServiceContract(Namespace = "http://ServicoTransferencia.TED/")]
    public interface ITransferenciaTED
    {
        [OperationContract (Action = "RealizaTransferenciaTED")] 
        string RealizaTransferenciaTED(RequestTransferenciaTED requestTransferencia);
    }
}
