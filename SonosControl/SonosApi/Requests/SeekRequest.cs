using System.ServiceModel;

namespace SonosApi.Requests
{

    [MessageContract(WrapperName = "Seek", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class SeekRequest
    {
        [MessageBodyMember(Namespace = "", Order = 1)]
        public int InstanceID { get; set; }

        [MessageBodyMember(Namespace = "", Order = 2)]        
        public Unit Unit { get; set; }

        [MessageBodyMember(Namespace = "", Order = 3)]
        public int Target { get; set; }
    }

    enum Unit
    {
        TRACK_NR
    }
}
/*
   <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <Seek
            xmlns="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID
                xmlns="">
                0
                </InstanceID>
            <Target
                xmlns="">
                2
                </Target>
            <Unit
                xmlns="">
                TRACK_NR
                </Unit>
            </Seek>
        </s:Body>
    </s:Envelope>


   Windows app:
    <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
    s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
    <s:Body>
        <u:Seek
            xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID>
                0
                </InstanceID>
            <Unit>
                TRACK_NR
                </Unit>
            <Target>
                4
                </Target>
            </u:Seek>
        </s:Body>
    </s:Envelope>

*/
/*
 
     <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <Seek
            xmlns="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID
                xmlns="">
                0
                </InstanceID>
            <Unit
                xmlns="">
                TRACK_NR
                </Unit>
            <Target
                xmlns="">
                2
                </Target>
            </Seek>
        </s:Body>
    </s:Envelope>

     <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
    s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
    <s:Body>
        <u:Seek
            xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID>
                0
                </InstanceID>
            <Unit>
                TRACK_NR
                </Unit>
            <Target>
                2
                </Target>
            </u:Seek>
        </s:Body>
    </s:Envelope>

     */
