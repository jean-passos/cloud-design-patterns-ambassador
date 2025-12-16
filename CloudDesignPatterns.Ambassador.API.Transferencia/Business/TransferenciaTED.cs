using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Entity;
using CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Business
{
    public class TransferenciaTED : ITransferenciaTED
    {
        private readonly ILogger _logger;
        public TransferenciaTED(ILogger<TransferenciaTED> logger)
        {
            _logger = logger;
        }
        public async Task<EntityTED> RealizaTransferencia(EntityTED transferenciaTED)
        {
            HttpClient httpClient = new HttpClient
            {
                // use this method calling direct api via resource ORRR
                //BaseAddress = new Uri("http://localhost:3500/v1.0/invoke/api-contacorrente/method/")

                // this to abstract the complex URIs
                //  but in that way it's necessary add header "dapr-app-id"
                BaseAddress = new Uri("http://localhost:3500/")
            };

            string documento = "12345678932";
            string nro_conta = "987654321";

            string rota = $"api-contacorrente/saldo/{documento}/{nro_conta}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, rota);
            httpRequestMessage.Headers.Add("dapr-app-id", "api-contacorrente");

            _logger.LogInformation(httpRequestMessage.ToString());

            var retorno = await httpClient.SendAsync(httpRequestMessage);

            ResponseContaCorrenteSaldo contaCorrenteSaldo;

            if (retorno.StatusCode == HttpStatusCode.OK)
            {
                string jsonRetorno = await retorno.Content.ReadAsStringAsync();

                _logger.LogInformation(jsonRetorno);

                contaCorrenteSaldo = JsonSerializer.Deserialize<ResponseContaCorrenteSaldo>(jsonRetorno)!;

                if (contaCorrenteSaldo != null && contaCorrenteSaldo.SaldoDisponivel >= transferenciaTED.ValorTransferencia)
                {

                    httpClient = new HttpClient
                    {
                        BaseAddress = new Uri("http://localhost:3500/v1.0/invoke/httpenpoint-service-transferencia/method/")
                    };
                    httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "");

                    XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
                    XNamespace ser = "http://ServicoTransferencia.TED/";
                    XNamespace req = "http://schemas.datacontract.org/2004/07/RequestTransferenciaTED.Data";

                    XDocument xDocument = new XDocument(
                        new XElement(soapenv + "Envelope",
                            new XAttribute(XNamespace.Xmlns + "soapenv", soapenv),
                            new XAttribute(XNamespace.Xmlns + "ser", ser),
                            new XAttribute(XNamespace.Xmlns + "req", req),
                            new XElement(soapenv + "Header"),
                            new XElement(soapenv + "Body",
                                new XElement(ser + "RealizaTransferenciaTED",
                                    new XElement(ser + "requestTransferencia",
                                        new XElement(req + "AgenciaDestino", "0001"),
                                        new XElement(req + "ContaDestino", nro_conta),
                                        new XElement(req + "DocumentoBeneficiario", documento),
                                        new XElement(req + "InstituicaoDetino", "001"),
                                        new XElement(req + "ValorTransferencia", transferenciaTED.ValorTransferencia)
                                    )
                                )
                            )
                        ));

                    string xmlString = xDocument.ToString();

                    httpRequestMessage.Headers.Add("SOAPAction", "RealizaTransferenciaTED");
                    httpRequestMessage.Content = new StringContent(xmlString);
                    var responseMessageSoap = await httpClient.SendAsync(httpRequestMessage)!;
                    var xmlRetorno = await responseMessageSoap.Content.ReadAsStringAsync();

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Envelope));
                    var deserializedResultXml = xmlSerializer.Deserialize(new StringReader(xmlRetorno)) as Envelope;

                    transferenciaTED.IdentificadorTransferencia = deserializedResultXml!.Body.ResponseServicoTransfernciaTED.CodigoTransferencia;
                }
            }
            return transferenciaTED;
        }
    }
}
