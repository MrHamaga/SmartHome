using SonosApi.Requests;
using System;

namespace SonosApi
{
    public class SonosClient
    {
        private string _baseAddress;

        public SonosClient(string sonosIp)
        {
            _baseAddress = string.Format("http://{0}:1400/MediaRenderer/AVTransport/Control", sonosIp);
        }

        private IAVTransportService GetClient() {
            return new AVTransportService(_baseAddress);
        }
        public void Seek(int instanceId)
        {
            using (var client = GetClient())
            {
                try
                {
                    client.Seek(new SeekRequest
                    {
                        InstanceID = instanceId,
                        Target = 2, 
                        Unit = Unit.TRACK_NR

                    });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public void GetPositionInfo(int instanceId)
        {
            using (var client = GetClient())
            {
                try
                {
                    client.GetPositionInfo(new GetPositionInfoRequest
                    {
                        InstanceID = instanceId,                        
                    });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
        public void Play(int instanceId)
        {
            using (var client = GetClient())
            {
                try
                {
                    client.Play(new PlayRequest
                    {
                        InstanceID = instanceId,
                        Speed = 1
                    });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public void Pause(int instanceId)
        {
            using (var client = GetClient())
            {
                try
                {
                    client.Pause(new PauseRequest
                    {
                        InstanceID = instanceId
                    });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
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

