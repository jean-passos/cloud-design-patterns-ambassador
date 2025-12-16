using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Request;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Controllers
{
    [Route("api-transferencia/interbancaria")]
    [ApiController]
    public class InterbancariaController : ControllerBase
    {

        private ITransferenciaTED _transferenciaTED;

        public InterbancariaController(ITransferenciaTED transferenciaTED)
        {
            _transferenciaTED = transferenciaTED;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestTED"></param>
        /// <returns></returns>
        [HttpPost("ted")]
        public async Task<AcceptedResult> TransferenciaInterbancaria([FromBody]RequestTED requestTED)
        {
            EntityTED entityTED = new EntityTED
            {
                ValorTransferencia = requestTED.ValorTransferencia
            };

            entityTED = await _transferenciaTED.RealizaTransferencia(entityTED);
            ResponseTED response = new ResponseTED { IdentificadorTransferencia = entityTED.IdentificadorTransferencia };
            return Accepted(response);
        }
    }
}
