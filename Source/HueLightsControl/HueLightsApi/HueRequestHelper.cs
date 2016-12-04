using HueLightsApi.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HueLightsApi
{
    public class HueRequestHelper
    {
        #region To configure
        string address = ConfigurationHelper.GetHueBridgeApiUri();
        string user = ConfigurationHelper.GetHueAuthenticatedUser();
        #endregion

        #region Statics 
        string LightsKeyword = "lights";
        string GroupsKeyword = "groups";
        #endregion

        string _baseLightsUri;
        string _baseGroupsUri;

        public HueRequestHelper()
        {
            _baseLightsUri = string.Format("{0}{1}/{2}", address, user, LightsKeyword);
            _baseGroupsUri = string.Format("{0}{1}/{2}", address, user, GroupsKeyword);
        }
//        public bool LightsStateChanged { get; set; }

        List<Light> _lights = new List<Light>();
        private List<Group> _groups;

        public List<Light> Lights
        {
            get
            {
                return _lights;
            }

            set
            {
                _lights = value;
            }
        }
        private void HandleResponse(IRestResponse resp)
        {
            LogResponse(resp);
            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(string.Format("Statuscode was {0} with the description {1}", resp.StatusCode, resp.StatusDescription));
            }
        }

        private void LogResponse(IRestResponse resp)
        {
            Console.WriteLine(resp.Content);
        }

        private void PopulateGroupsList(IRestResponse resp)
        {
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                _groups = new List<Group>();
                var json = JsonConvert.DeserializeObject<JObject>(resp.Content);
                foreach (var item in json.AsJEnumerable())
                {
                    var group = JsonConvert.DeserializeObject<Group>(item.First().ToString());
                    group.id = item.Path;
                    _groups.Add(group);
                }
            }
            else
            {
                LogResponse(resp);
                throw new Exception(string.Format("Statuscode was {0} with the description {1}", resp.StatusCode, resp.StatusDescription));
            }
        }

        private void PopulateLightList(IRestResponse resp) {
           
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                 _lights = new List<Light>();
                var json = JsonConvert.DeserializeObject<JObject>(resp.Content);
                foreach (var item in json.AsJEnumerable())
                {
                    var light = JsonConvert.DeserializeObject<Light>(item.First().ToString());
                    light.id = item.Path;
                    _lights.Add(light);
                }
            }
            else
            {
                LogResponse(resp);
                throw new Exception(string.Format("Statuscode was {0} with the description {1}", resp.StatusCode, resp.StatusDescription));
            }
        }
        public void PopulateGroupsList()
        {
            var client = new RestClient(_baseGroupsUri);
            var request = new RestRequest();

            client.ExecuteAsync(request, response => {
                PopulateGroupsList(response);
            });
        }

        public void PopulateLightList()
        {
            var client = new RestClient(_baseLightsUri);
            var request = new RestRequest();

            client.ExecuteAsync(request, response => {
                PopulateLightList(response);
            });
        }
        public void TurnOffAll()
        {
            TurnAllOff();
        }

        public void TurnOff(Light light)
        {
            SetState(light.id, false);
        }

        public void Blink(Light light) {
            ExecuteRequest(string.Format("{0}/{1}/state", _baseLightsUri, light.id), new { alert = "lselect" });
        }

        public void TurnOn(Light light)
        {
            SetState(light.id, true);
        }
        public void SetColor(Light light, RgbColor color) {
            SetColor(light.id, color);
        }
        private void SetColor(string lightId, RgbColor color) {
            ExecuteRequest(string.Format("{0}/{1}/state", _baseLightsUri, lightId), new { xy = ColorHelper.RgbToXY(color) });
        }

        private void SetState(string lightId, bool state)
        {
            ExecuteRequest(string.Format("{0}/{1}/state", _baseLightsUri, lightId), new { on = state });
        }
        private void TurnAllOff()
        {
            var body = new { on = false };
            var uri = string.Format("{0}/0/action", _baseGroupsUri);
            ExecuteRequest(uri, body);
        }

        private void ExecuteRequest(string uri, object body)
        {
            var client = new RestClient(uri);
            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);
            Console.WriteLine(JsonConvert.SerializeObject(request));
            client.ExecuteAsync(request, response => {
                HandleResponse(response);
            });
        }

      
    }
}
