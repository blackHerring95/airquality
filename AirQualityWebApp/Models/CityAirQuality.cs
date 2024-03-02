using System.Text;
using static AirQualityWebApp.Models.CityAirQuality;

namespace AirQualityWebApp.Models
{
    public class CityAirQuality
    {
        public string GetName() 
        {
            return data?.city?.name!;    
        }

        public List<string> ListOutLeves()
        {
            var list = new List<string>();

            list.Add($"Air quality index    {data?.aqi}");
            list.Add($"Idx  {data?.idx}");


            list.Add($"CO   {data?.iaqi?.co?.v}");
            list.Add($"Dew  {data?.iaqi?.dew?.v}");
            list.Add($"H    {data?.iaqi?.h?.v}");
            list.Add($"No2  {data?.iaqi?.no2?.v}");
            list.Add($"O3   {data?.iaqi?.o3?.v}");
            list.Add($"P    {data?.iaqi?.p?.v}");
            list.Add($"Pm10 {data?.iaqi?.pm10?.v}");
            list.Add($"Pm25 {data?.iaqi?.pm25?.v}");
            list.Add($"So2  {data?.iaqi?.so2?.v}");
            list.Add($"T    {data?.iaqi?.t?.v}");
            list.Add($"W    {data?.iaqi?.w?.v}");
            list.Add($"Wg   {data?.iaqi?.wg?.v}");

            return list;
    }

        public string status { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public float aqi { get; set; }
            public float idx { get; set; }
            public Attribution[] attributions { get; set; }
            public City city { get; set; }
            public string dominentpol { get; set; }
            public Iaqi iaqi { get; set; }
            public Time time { get; set; }
            public Forecast forecast { get; set; }
            public Debug debug { get; set; }
        }

        public class City
        {
            public float[] geo { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string location { get; set; }
        }

        public class Iaqi
        {
            public Co co { get; set; }
            public Dew dew { get; set; }
            public H h { get; set; }
            public No2 no2 { get; set; }
            public O3 o3 { get; set; }
            public P p { get; set; }
            public Pm10 pm10 { get; set; }
            public Pm25 pm25 { get; set; }
            public So2 so2 { get; set; }
            public T t { get; set; }
            public W w { get; set; }
            public Wg wg { get; set; }
        }

        public class Co
        {
            public float v { get; set; }
        }

        public class Dew
        {
            public float v { get; set; }
        }

        public class H
        {
            public float v { get; set; }
        }

        public class No2
        {
            public float v { get; set; }
        }

        public class O3
        {
            public float v { get; set; }
        }

        public class P
        {
            public float v { get; set; }
        }

        public class Pm10
        {
            public float v { get; set; }
        }

        public class Pm25
        {
            public float v { get; set; }
        }

        public class So2
        {
            public float v { get; set; }
        }

        public class T
        {
            public float v { get; set; }
        }

        public class W
        {
            public float v { get; set; }
        }

        public class Wg
        {
            public float v { get; set; }
        }

        public class Time
        {
            public string s { get; set; }
            public string tz { get; set; }
            public float v { get; set; }
            public DateTime iso { get; set; }
        }

        public class Forecast
        {
            public Daily daily { get; set; }
        }

        public class Daily
        {
            public O31[] o3 { get; set; }
            public Pm101[] pm10 { get; set; }
            public Pm251[] pm25 { get; set; }
        }

        public class O31
        {
            public float avg { get; set; }
            public string day { get; set; }
            public float max { get; set; }
            public float min { get; set; }
        }

        public class Pm101
        {
            public float avg { get; set; }
            public string day { get; set; }
            public float max { get; set; }
            public float min { get; set; }
        }

        public class Pm251
        {
            public float avg { get; set; }
            public string day { get; set; }
            public float max { get; set; }
            public float min { get; set; }
        }

        public class Debug
        {
            public DateTime sync { get; set; }
        }

        public class Attribution
        {
            public string url { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
        }

    }
}
