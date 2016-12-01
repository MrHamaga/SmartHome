using System.ServiceModel;

namespace SonosApi.Requests
{

    [MessageContract(WrapperName = "Seek", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class SeekRequest
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }

        [MessageBodyMember(Namespace = "")]
        public Unit Unit { get; set; }

        [MessageBodyMember(Namespace = "")]
        public int Target { get; set; }
    }

    enum Unit
    {
        TRACK_NR
    }
}
/*
 
     <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
    s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
    <s:Body>
        <u:GetPositionInfo
            xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID>
                0
                </InstanceID>
            </u:GetPositionInfo>
        </s:Body>
    </s:Envelope>

   


     */
//<s:Envelope
//    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
//    s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
//    <s:Body>
//        <u:Seek
//            xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
//            <InstanceID>
//                0
//                </InstanceID>
//            <Unit>
//                TRACK_NR
//                </Unit>
//            <Target>
//                2
//                </Target>
//            </u:Seek>
//        </s:Body>
//    </s:Envelope>

