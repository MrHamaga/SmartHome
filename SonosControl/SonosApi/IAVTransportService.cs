using SonosApi.Requests;
using System;
using System.ServiceModel;

namespace SonosApi
{

    [ServiceContract(Namespace = "urn:schemas-upnp-org:service:AVTransport:1")]
    internal interface IAVTransportService : IDisposable
    {
        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Play")]
        void Play(PlayRequest request);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Pause")]
        void Pause(PauseRequest request);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1")]
        void Seek(SeekRequest request);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1")]
        void GetPositionInfo(GetPositionInfoRequest request);
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

