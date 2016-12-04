using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SonosApi.Requests
{
    enum BrowseFlag
    {
        BrowseDirectChildren
    }

    [MessageContract(WrapperName = "Browse", WrapperNamespace = "urn:schemas-upnp-org:service:ContentDirectory:1", IsWrapped = true)]
    class BrowseRequest
    {
        [MessageBodyMember(Namespace = "")]
        public string ObjectID { get; set; }

        [MessageBodyMember(Namespace = "")]
        public BrowseFlag BrowseFlag { get; set; }

        [MessageBodyMember(Namespace = "")]
        public string Filter { get; set; }

        [MessageBodyMember(Namespace = "")]
        public int StartingIndex { get; set; }

        [MessageBodyMember(Namespace = "")]
        public int RequestedCount { get; set; }

        [MessageBodyMember(Namespace = "")]
        public string SortCriteria { get; set; }
    }
    [MessageContract(WrapperName = "BrowseResponse", WrapperNamespace = "urn:schemas-upnp-org:service:ContentDirectory:1", IsWrapped = true)]
    class BrowseResponse
    {
        [MessageBodyMember(Namespace = "")]
        public string Result { get; set; }
        [MessageBodyMember(Namespace = "")]
        public int NumberReturned { get; set; }
        [MessageBodyMember(Namespace = "")]
        public int TotalMatches { get; set; }
        [MessageBodyMember(Namespace = "")]
        public int UpdateID { get; set; }        	
    }
}
/*
       <s:Envelope
  xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
  s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
  <s:Body>
      <u:Browse
          xmlns:u="urn:schemas-upnp-org:service:ContentDirectory:1">
          <ObjectID>
              Q:0
              </ObjectID>
          <BrowseFlag>
              BrowseDirectChildren
              </BrowseFlag>
          <Filter>
              dc:title,res,dc:creator,upnp:artist,upnp:album,upnp:albumArtURI
              </Filter>
          <StartingIndex>
              0
              </StartingIndex>
          <RequestedCount>
              100
              </RequestedCount>
          <SortCriteria>
              </SortCriteria>
          </u:Browse>
      </s:Body>
  </s:Envelope>

       */
