using SonosApi.Requests;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System;

namespace SonosApi
{
    internal class AVTransportService : IAVTransportService
    {
        private ChannelFactory<IAVTransportService> factory;
        private IAVTransportService service;

        public AVTransportService(string baseAddress)
        {
            factory = new ChannelFactory<IAVTransportService>(GetBinding(), new EndpointAddress(baseAddress));
            service = factory.CreateChannel();
        }
        static Binding GetBinding()
        {
            return new BasicHttpBinding();
        }
       
        public void Pause(PauseRequest request)
        {
            service.Pause(request);
        }

        public void Play(PlayRequest request)
        {
            service.Play(request);
        }
        public void Next(NextRequest request)
        {
            service.Next(request);
        }
        public void Previous(PreviousRequest request)
        {
            service.Previous(request);
        }

        public void Dispose()
        {
            ((IClientChannel)service).Close();
        }

        public void Seek(SeekRequest request)
        {
            service.Seek(request);
        }

        public GetPositionInfoResponse GetPositionInfo(GetPositionInfoRequest request)
        {
            GetPositionInfoResponse resp = service.GetPositionInfo(request);
            return resp;
        }
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

