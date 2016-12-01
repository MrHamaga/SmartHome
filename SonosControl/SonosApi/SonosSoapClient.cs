using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SonosApi
{
    public class SonosSoapClient
    {
        private ChannelFactory<IAVTransportService> factory;

        public SonosSoapClient(string baseAddress)
        {
            factory = new ChannelFactory<IAVTransportService>(GetBinding(), new EndpointAddress(baseAddress));
        }

        static Binding GetBinding()
        {
            return new BasicHttpBinding();
        }

        internal void Play(int instanceId)
        {
            using (var service = factory.CreateChannel())
            {
                try
                {
                    service.Play(new PlayRequest
                    {
                        InstanceID = instanceId,
                        Speed = 1
                    });
                }
                catch (Exception e)
                {
                    throw;
                }

             ((IClientChannel)service).Close();
            }
        }

        internal void Pause(int instanceId)
        {
            using (var service = factory.CreateChannel())
            {
                try
                {
                    service.Pause(new PauseRequest
                    {
                        InstanceID = instanceId
                    });
                }
                catch (Exception e)
                {
                    throw;
                }

              ((IClientChannel)service).Close();
            }
        }
    }

    [ServiceContract(Namespace = "urn:schemas-upnp-org:service:AVTransport:1")]
    internal interface IAVTransportService : IDisposable
    {
        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Play")]
        void Play(PlayRequest playRequest);

        [OperationContract(Action = "urn:schemas-upnp-org:service:AVTransport:1#Pause")]
        void Pause(PauseRequest playRequest);
    }

    [MessageContract(WrapperName = "Play", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class PlayRequest 
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }

        [MessageBodyMember(Namespace = "")]
        public int Speed { get; internal set; }
    }
    [MessageContract(WrapperName = "Pause", WrapperNamespace = "urn:schemas-upnp-org:service:AVTransport:1", IsWrapped = true)]
    internal class PauseRequest
    {
        [MessageBodyMember(Namespace = "")]
        public int InstanceID { get; set; }
    }



}

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

