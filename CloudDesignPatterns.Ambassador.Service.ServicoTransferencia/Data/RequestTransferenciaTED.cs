using System.Runtime.Serialization;

namespace CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Data
{
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RequestTransferenciaTED.Data")]
    public class RequestTransferenciaTED
    {
        [DataMember]
        public string InstituicaoDetino { get; set; }

        [DataMember]
        public string AgenciaDestino { get; set; }

        [DataMember]
        public string ContaDestino { get; set; }

        [DataMember]
        public string DocumentoBeneficiario { get; set; }

        [DataMember]
        public decimal ValorTransferencia { get; set; }
    }
}
