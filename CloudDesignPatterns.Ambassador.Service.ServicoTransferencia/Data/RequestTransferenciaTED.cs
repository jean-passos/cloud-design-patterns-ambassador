using System.Runtime.Serialization;

namespace CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Data
{
    [DataContract]
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
