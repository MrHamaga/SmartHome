using System.ServiceModel;

namespace SonosApi.Requests
{
    [MessageContract(WrapperName = "GetPositionInfo", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class GetPositionInfoRequest
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }

        /*
    
        From Windows Program:     
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


        Current:
        <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <GetPositionInfo
            xmlns="urn:schemas-upnp-org:service:AVTransport:1">
            <InstanceID
                xmlns="">
                0
                </InstanceID>
            </GetPositionInfo>
        </s:Body>
    </s:Envelope>



         */
    }

    [MessageContract(WrapperName = "GetPositionInfoResponse", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class GetPositionInfoResponse
    {

        /*
         <s:Envelope
    xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
    s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
    <s:Body>
        <u:GetPositionInfoResponse
            xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
            <Track>
                1
                </Track>
            <TrackDuration>
                0:03:15
                </TrackDuration>
            <TrackMetaData>
                 [truncated]&lt;DIDL-Lite xmlns:dc=&quot;http://purl.org/dc/elements/1.1/&quot; xmlns:upnp=&quot;urn:schemas-upnp-org:metadata-1-0/upnp/&quot; xmlns:r=&quot;urn:schemas-rinconnetworks-com:metadata-1-0/&quot; xmlns=&quot;urn:schemas-upnp-or
                </TrackMetaData>
            <TrackURI>
                x-sonos-http:tr%3a135025836.mp3?sid=2&amp;flags=8224&amp;sn=1
                </TrackURI>
            <RelTime>
                0:00:03
                </RelTime>
            <AbsTime>
                NOT_IMPLEMENTED
                </AbsTime>
            <RelCount>
                2147483647
                </RelCount>
            <AbsCount>
                2147483647
                </AbsCount>
            </u:GetPositionInfoResponse>
        </s:Body>
    </s:Envelope>

         */
    }
}
/*
 
  


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

