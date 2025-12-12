using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response;
using System.Net;
using System.Text.Json;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Business
{
    public class TransferenciaTED : ITransferenciaTED
    {
        public async Task<string> RealizaTransferencia(EntityTED transferenciaTED)
        {
            HttpClient httpClient = new HttpClient 
            {
                //BaseAddress = new Uri("http://localhost:3500/v1.0/invoke/api-contacorrente/method/")
                BaseAddress = new Uri("http://localhost:3500/")
            };
            

            string documento = "12345678932";
            string nro_conta = "987654321";

            string rota = $"api-contacorrente/saldo/{documento}/{nro_conta}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, rota);
            httpRequestMessage.Headers.Add("dapr-app-id", "api-contacorrente");

            Console.WriteLine(httpRequestMessage.ToString());

            var retorno = await httpClient.SendAsync(httpRequestMessage);

            ResponseContaCorrenteSaldo contaCorrenteSaldo;

            if (retorno.StatusCode == HttpStatusCode.OK)
            {
                string jsonRetorno = await retorno.Content.ReadAsStringAsync();

                Console.WriteLine(jsonRetorno);

                contaCorrenteSaldo = JsonSerializer.Deserialize<ResponseContaCorrenteSaldo>(jsonRetorno)!;


                if (contaCorrenteSaldo != null && contaCorrenteSaldo.SaldoDisponivel >= transferenciaTED.ValorTransferencia)
                {
                    // fazer a transferencia
                }
            }
            return "STR.......";
        }
    }
}
