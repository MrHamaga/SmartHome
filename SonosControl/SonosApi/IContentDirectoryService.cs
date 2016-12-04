using SonosApi.Requests;
using System;
using System.ServiceModel;

namespace SonosApi
{
    [ServiceContract(Namespace = "urn:schemas-upnp-org:service:ContentDirectory:1")]
    internal interface IContentDirectoryService : IDisposable
    {
        [OperationContract(Action = "urn:schemas-upnp-org:service:ContentDirectory:1#Browse")]
        BrowseResponse Browse(BrowseRequest request);
    }
}
