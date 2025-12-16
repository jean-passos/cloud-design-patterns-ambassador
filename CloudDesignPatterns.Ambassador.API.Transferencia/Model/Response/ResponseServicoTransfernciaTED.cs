using System.Xml.Serialization;

namespace CloudDesignPatterns.Ambassador.API.Transferencia.Model.Response
{


    /**
     * 
     * 
 <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <RealizaTransferenciaTEDResponse xmlns="http://ServicoTransferencia.TED/">
            <RealizaTransferenciaTEDResult>STR0123456789</RealizaTransferenciaTEDResult>
        </RealizaTransferenciaTEDResponse>
    </s:Body>
</s:Envelope>
     */

    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", ElementName = "Envelope")]
    public class Envelope
    {
        public Body Body { get; set; }
    }

    public class Body
    {
        [XmlElement(Namespace = "http://ServicoTransferencia.TED/", ElementName = "RealizaTransferenciaTEDResponse")]
        public ResponseServicoTransfernciaTED ResponseServicoTransfernciaTED { get; set; }
    }

    public class ResponseServicoTransfernciaTED
    {
        [XmlElement(ElementName = "RealizaTransferenciaTEDResult")]
        public string CodigoTransferencia { get; set; }
    }
}
