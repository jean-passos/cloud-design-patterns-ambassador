using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Request
{
    public class RequestTED
    {
        [JsonPropertyName("documento-recebedor")]
        public string DocumentoRecebedor { get; set; }

        [JsonPropertyName("valor-transferencia")]
        public decimal ValorTransferencia { get; set; }
    }
}
