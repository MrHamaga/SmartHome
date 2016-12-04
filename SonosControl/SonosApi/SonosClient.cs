using SonosApi.Requests;
using System;

namespace SonosApi
{
    public class SonosClient
    {
        private string _ip;
        public SonosClient(string sonosIp)
        {
            _ip = sonosIp;
            
        }
        private IContentDirectoryService GetContentDirectoryClient()
        {
            return new ContentDirectoryService(string.Format("http://{0}:1400/MediaServer/ContentDirectory/Control", _ip));
        }
        private IAVTransportService GetAvTransportClient() {
            return new AVTransportService(string.Format("http://{0}:1400/MediaRenderer/AVTransport/Control", _ip));
        }
        public void Seek(int instanceId)
        {
            using (var client = GetAvTransportClient())
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
            using (var client = GetAvTransportClient())
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

        public void Browse(string objectId)
        {
            using (var client = GetContentDirectoryClient())
            {
              var result = client.Browse(new BrowseRequest {
                    BrowseFlag = BrowseFlag.BrowseDirectChildren,
                    Filter = "dc:title,res,dc:creator,upnp:artist,upnp:album,upnp:albumArtURI",
                    ObjectID = objectId,
                    RequestedCount = 100,
                    SortCriteria = "",
                    StartingIndex = 0
                });
            }
        }

        public void Play(int instanceId)
        {
            using (var client = GetAvTransportClient())
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
            using (var client = GetAvTransportClient())
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

