using System.Text.Json.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity
{
    public class CreditoTED
    {
        public string InstituicaoCredito { get; set; }

        public string DocumentoCredito { get; set; }

        public string AgenciaCredito { get; set; }

        public string NroContaCredito { get; set; }

        public decimal ValorTransferencia { get; set; }
    }
}
