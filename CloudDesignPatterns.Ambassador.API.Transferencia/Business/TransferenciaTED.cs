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
        public string? CodigoTransferencia { get; private set; }

        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public TransferenciaTED(ILogger<TransferenciaTED> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task RealizaTransferencia(DebitoTED debito, CreditoTED credito)
        {
            decimal saldoDisponivel = await ObterSaldoContaCorrente(debito.DocumentoCorrentista, debito.NroContaCorrentista);
            if (saldoDisponivel >= credito.ValorTransferencia)
                CodigoTransferencia = await RealizarTransferenciaTED(credito);
        }

        private async Task<decimal> ObterSaldoContaCorrente(string documento, string nro_conta)
        {
            using (var httpContaCorrenteClient = _httpClientFactory.CreateClient("api-contacorrente"))
            {
                string rota = $"api-contacorrente/saldo/{documento}/{nro_conta}";

                var retorno = await httpContaCorrenteClient.GetAsync(rota);

                ResponseContaCorrenteSaldo contaCorrenteSaldo;
                if (retorno.StatusCode == HttpStatusCode.OK)
                {
                    string jsonRetorno = await retorno.Content.ReadAsStringAsync();
                    contaCorrenteSaldo = JsonSerializer.Deserialize<ResponseContaCorrenteSaldo>(jsonRetorno)!;
                    return contaCorrenteSaldo.SaldoDisponivel;
                }
                else
                {
                    return 0;
                } 
            }
        }

        private async Task<string> RealizarTransferenciaTED(CreditoTED credito)
        {
            string xmlString = CreateSoapRequest(credito).ToString();
            Envelope? deserializedResultXml;
            using (var httpServicoTransferenciaClient = _httpClientFactory.CreateClient("service-transferencia"))
            {
                httpServicoTransferenciaClient.DefaultRequestHeaders.Add("SOAPAction", "RealizaTransferenciaTED");
                HttpResponseMessage responseMessageSoap = await httpServicoTransferenciaClient.PostAsync("", new StringContent(xmlString));
                string xmlRetorno = await responseMessageSoap.Content.ReadAsStringAsync();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Envelope));
                deserializedResultXml = xmlSerializer.Deserialize(new StringReader(xmlRetorno)) as Envelope;
            }
            return deserializedResultXml!.Body.ResponseServicoTransfernciaTED.CodigoTransferencia;
        }

        private XDocument CreateSoapRequest(CreditoTED credito)
        {
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
                                new XElement(req + "AgenciaDestino", credito.AgenciaCredito),
                                new XElement(req + "ContaDestino", credito.NroContaCredito),
                                new XElement(req + "DocumentoBeneficiario", credito.DocumentoCredito),
                                new XElement(req + "InstituicaoDetino", credito.InstituicaoCredito),
                                new XElement(req + "ValorTransferencia", credito.ValorTransferencia)
                            )
                        )
                    )
                ));
            return xDocument;
        }


    }
}