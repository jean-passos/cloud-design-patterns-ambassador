using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Request
{
    public class RequestTED
    {
        [JsonPropertyName("debito")]
        public RequestContaDebito ContaDebito { get; set; }

        [JsonPropertyName("credito")]
        public RequestContaCredito ContaCredito { get; set; }
    }


    public class RequestContaDebito
    {
        [JsonPropertyName("documentoCorrentista")]
        public string DocumentoCorrentista { get; set; }
        [JsonPropertyName("nroContaDebito")]
        public string NroConta { get; set; }
    }

    public class RequestContaCredito
    {
        [JsonPropertyName("instituicaoRecebedor")]
        public string InstituicaoRecebedor { get; set; }

        [JsonPropertyName("documentoRecebedor")]
        public string DocumentoRecebedor { get; set; }

        [JsonPropertyName("agenciaRecebedor")]
        public string AgenciaRecebedor { get; set; }

        [JsonPropertyName("nroContaCredito")]
        public string NroContaRecebedor { get; set; }

        [JsonPropertyName("valorTransferencia")]
        public decimal ValorTransferencia { get; set; }



    }


}
