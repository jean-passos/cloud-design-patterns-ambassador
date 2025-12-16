using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response
{
    public class ResponseTED
    {
        [JsonPropertyName("identificadorTransferencia")]
        public string IdentificadorTransferencia { get; set; } 
    }
}
