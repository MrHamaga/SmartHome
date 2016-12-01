using SonosApi.Helpers;

namespace SonosApi
{
    public class SonosRequestHelper
    {
        SonosSoapClient s;
        public SonosRequestHelper()
        {
            s = new SonosSoapClient(string.Format("http://{0}/MediaRenderer/AVTransport/Control", ConfigurationHelper.GetSonosIp()));
        }

        public void Pause()
        {
            s.Pause(0);
        }
       
        public void Play() {
            s.Play(0);
        }
    }
}
