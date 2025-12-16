using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Request;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Controllers
{
    [Route("api-transferencia")]
    [ApiController]
    public class InterbancariaController : ControllerBase
    {
        private ITransferenciaTED _transferenciaTED;

        public InterbancariaController(ITransferenciaTED transferenciaTED)
        {
            _transferenciaTED = transferenciaTED;
        }

        [HttpPost("outra-instituicao")]
        public async Task<IActionResult> TransferenciaInterbancaria([FromBody]RequestTED requestTED)
        {
            CreditoTED credito = new CreditoTED
            {
                InstituicaoCredito = requestTED.ContaCredito.InstituicaoRecebedor,
                DocumentoCredito = requestTED.ContaCredito.DocumentoRecebedor,
                AgenciaCredito = requestTED.ContaCredito.AgenciaRecebedor,
                NroContaCredito = requestTED.ContaCredito.NroContaRecebedor,
                ValorTransferencia = requestTED.ContaCredito.ValorTransferencia
            };

            DebitoTED debito = new DebitoTED
            {
                DocumentoCorrentista = requestTED.ContaDebito.DocumentoCorrentista,
                NroContaCorrentista = requestTED.ContaDebito.NroConta
            };

            await _transferenciaTED.RealizaTransferencia(debito, credito);

            ResponseTED response = new ResponseTED { IdentificadorTransferencia = _transferenciaTED.CodigoTransferencia };
            return Accepted(response);
        }
    }
}
