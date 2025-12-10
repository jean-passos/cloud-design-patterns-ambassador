using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
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
            string identificadorTransferencia = await _transferenciaTED.RealizaTransferencia(new Model.Entity.EntityTED());

            ResponseTED response = new ResponseTED { IdentificadorTransferencia = identificadorTransferencia };

            return Accepted(response);
        }
    }
}
