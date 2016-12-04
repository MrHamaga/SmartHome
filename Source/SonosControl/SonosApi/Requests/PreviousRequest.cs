using System.ServiceModel;

namespace SonosApi.Requests
{

    [MessageContract(WrapperName = "Previous", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class PreviousRequest
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }
    }

}
    /*
    <s:Envelope
        xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
        <s:Body>
            <Play
                xmlns="urn:schemas-upnp-org:service:AVTransport:1">
                <InstanceID
                    xmlns="">
                    0
                    </InstanceID>
                <Speed
                    xmlns="">
                    1
                    </Speed>
                </Play>
            </s:Body>
        </s:Envelope>
     */