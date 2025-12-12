using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response
{
    public class ResponseContaCorrenteSaldo
    {
        [JsonPropertyName("saldo_disponivel")]
        public decimal SaldoDisponivel { get; set; }
    }
}
