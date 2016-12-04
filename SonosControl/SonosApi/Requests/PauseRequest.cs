using System.ServiceModel;

namespace SonosApi.Requests
{
    [MessageContract(WrapperName = "Pause", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class PauseRequest
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }
    }

}
/*
 
   <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <Pause
            xmlns="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID
                xmlns="">
                0
                </InstanceID>
            </Pause>
        </s:Body>
    </s:Envelope>
     */