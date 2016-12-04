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

        //[OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1")]
        void Seek(SeekRequest request);

        //[OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1")]
        GetPositionInfoResponse GetPositionInfo(GetPositionInfoRequest request);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Next")]
        void Next(NextRequest request);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Previous")]
        void Previous(PreviousRequest request);
    }
}