using System.Collections.Generic;

namespace HueLightsApi
{
    internal class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> lights { get; set; }
        public string type { get; set; }
        public GroupState state { get; set; }
        public bool recycle { get; set; }
        public GroupAction action { get; set; }
    }

    public class GroupState
    {
        public bool all_on { get; set; }
        public bool any_on { get; set; }
    }

    public class GroupAction
    {
        public bool on { get; set; }
        public int bri { get; set; }
        public int hue { get; set; }
        public int sat { get; set; }
        public string effect { get; set; }
        public List<double> xy { get; set; }
        public int ct { get; set; }
        public string alert { get; set; }
        public string colormode { get; set; }
    }
}