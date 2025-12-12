using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.ContaCorrente.Model
{
    public class SaldoResponse
    {
        [JsonPropertyName("saldo_disponivel")]
        public decimal SaldoDisponivel { get; set; }

    }
}
