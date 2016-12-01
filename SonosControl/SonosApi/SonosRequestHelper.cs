using SonosApi.Helpers;

namespace SonosApi
{
    public class SonosRequestHelper
    {
        SonosClient s;
        public SonosRequestHelper()
        {
            s = new SonosClient(ConfigurationHelper.GetSonosIp());
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
