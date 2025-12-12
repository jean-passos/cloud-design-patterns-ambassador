using CloudDesignPatterns.Ambassador.API.ContaCorrente.Business.Interface;
using CloudDesignPatterns.Ambassador.API.ContaCorrente.Model;
using Microsoft.AspNetCore.Mvc;

namespace CloudDesignPatterns.Ambassador.API.ContaCorrente.Controllers
{
    [Route("api-contacorrente/")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly ISaldo _saldo;
        public ContaController(ISaldo saldo)
        {
            _saldo = saldo;
        }

        [HttpGet("saldo/{documento}/{nro_conta}")]
        public async Task<IActionResult> GetSaldo([FromRoute] string documento, [FromRoute] string nro_conta)
        {
            decimal saldoDisponivel = await _saldo.ObterSaldo(documento, nro_conta);

            return Ok(new SaldoResponse { SaldoDisponivel = saldoDisponivel });
        }

    }
}
