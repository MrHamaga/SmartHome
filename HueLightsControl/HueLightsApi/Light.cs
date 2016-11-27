using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HueLightsApi
{
    public class Light
    {
        private JToken item;

        public Light(JToken item)
        {
            this.item = item;
        }

        public Light()
        {
        }

        public string id { get; set; }
        public State state { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string modelid { get; set; }
        public string manufacturername { get; set; }
        public string uniqueid { get; set; }
        public string swversion { get; set; }
        public RgbColor color { get {
                //var c = ColorHelper.GetRgbFromXy(state.xy, modelid, state.bri);
                //var xy = ColorHelper.RgbToXY(c);
                return ColorHelper.GetRgbFromXy(state.xy, modelid, state.bri);
            }
        }
        public int brightness { get { return state.bri; } }
    }

    public static class ColorHelper {

        public static List<double> RgbToXY(RgbColor color)
        {
            var red = (double)color.Red;
            var green = (double)color.Green;
            var blue = (double)color.Blue;
            //Gamma correctie
            red = (red > 0.04045) ? Math.Pow((red + 0.055) / (1.0 + 0.055), 2.4) : (red / 12.92);
            green = (green > 0.04045) ? Math.Pow((green + 0.055) / (1.0 + 0.055), 2.4) : (green / 12.92);
            blue = (blue > 0.04045) ? Math.Pow((blue + 0.055) / (1.0 + 0.055), 2.4) : (blue / 12.92);

            //Apply wide gamut conversion D65
            var X = red * 0.664511 + green * 0.154324 + blue * 0.162028;
            var Y = red * 0.283881 + green * 0.668433 + blue * 0.047685;
            var Z = red * 0.000088 + green * 0.072310 + blue * 0.986039;

            var fx = X / (X + Y + Z);
            var fy = Y / (X + Y + Z);
            //if (isnan(fx))
            //{
            //    fx = 0.0f;
            //}
            //if (isnan(fy))
            //{
            //    fy = 0.0f;
            //}

            return new List<double> {fx, fy};
        }

        public static RgbColor GetRgbFromXy(List<double> xy, string modelid, int bri)
        {
            if (xy==null)
            {
                return new RgbColor(255, 255, 255);
            }
            //var gamut = GetGamut(modelid);

            var x = xy.First(); // the given x value
            var y = xy.Last(); // the given y value

            var z = 1.0 - x - y;
            var Y = bri / 255.0; // Brightness of lamp
            var X = (Y / y) * x;
            var Z = (Y / y) * z;
            var r = X * 1.612 - Y * 0.203 - Z * 0.302;
            var g = -X * 0.509 + Y * 1.412 + Z * 0.066;
            var b = X * 0.026 - Y * 0.072 + Z * 0.962;
            r = r <= 0.0031308 ? 12.92 * r : (1.0 + 0.055) * Math.Pow(r, (1.0 / 2.4)) - 0.055;
            g = g <= 0.0031308 ? 12.92 * g : (1.0 + 0.055) * Math.Pow(g, (1.0 / 2.4)) - 0.055;
            b = b <= 0.0031308 ? 12.92 * b : (1.0 + 0.055) * Math.Pow(b, (1.0 / 2.4)) - 0.055;
            var maxValue = Math.Max(r, Math.Max(g, b));
            r /= maxValue;
            g /= maxValue;
            b /= maxValue;
            r = r * 255; if (r < 0) { r = 255; }
            g = g * 255; if (g < 0) { g = 255; }
            b = b * 255; if (b < 0) { b = 255; }

            return new RgbColor(r,g,b);
        }
      
        public static Gamut GetGamut(string modelid) {
            switch (modelid)
            {
                case "LCT007":
                    return new Gamut
                    {
                        Red = new Point { x = 0.675m, y = 0.322m },
                        Green = new Point { x = 0.409m, y = 0.518m },
                        Blue = new Point { x = 0.167m, y = 0.04m },
                    };
                case "LWB004":
                case "LWB006":
                default:
                    return new Gamut
                    {
                        Red = new Point { x = 1, y = 0 },
                        Green = new Point { x = 0, y = 1 },
                        Blue = new Point { x = 0, y = 0 },
                    };
            }
        }
    }

    public class Gamut {
        public Point Red { get; set; }
        public Point Green { get; set; }
        public Point Blue { get; set; }
    }

    public class Point {
        public decimal x { get; set; }
        public decimal y { get; set; }
    }

    public class RgbColor {
        public RgbColor(double r, double g, double b)
        {
            Red = (int)r;
            Green = (int)g;
            Blue = (int)b;
        }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public override string ToString()
        {
            return string.Format("R: {0} G: {1} B: {2}", Red, Green, Blue);
        }
    }
    public class State
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
        public bool reachable { get; set; }

        public override string ToString()
        {
            return reachable? (on?"On":"Off"):"Unreachable";
        }
    }

}
