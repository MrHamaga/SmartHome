using SonosApi.Requests;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SonosApi
{

    internal class ContentDirectoryService : IContentDirectoryService
    {
     
        private ChannelFactory<IContentDirectoryService> factory;
        private IContentDirectoryService service;

        public ContentDirectoryService(string baseAddress)
        {
            factory = new ChannelFactory<IContentDirectoryService>(GetBinding(), new EndpointAddress(baseAddress));
            service = factory.CreateChannel();
        }
        static Binding GetBinding()
        {
            return new BasicHttpBinding();
        }

        public BrowseResponse Browse(BrowseRequest request)
        {
            return service.Browse(request);
        }

        public void Dispose()
        {
            ((IClientChannel)service).Close();
        }
    }
}
