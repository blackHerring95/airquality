using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static AirQualityWebApp.Models.CityAirQuality;
using static AirQualityWebApp.Models.CityAirQuality.PollutantMetaData;

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
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("Air quality index", data?.aqi.ToString());

            list.Add($"    {data?.aqi}");
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

        public Dictionary<string, string> GetAirIndexDictionary()
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("Air quality index", data?.aqi.ToString());
            dictionary.Add("Idx"  ,data?.idx.ToString());
            dictionary.Add("CO" ,data?.iaqi?.co?.v.ToString());
            dictionary.Add("Dew" ,data?.iaqi?.dew?.v.ToString());
            dictionary.Add("H" ,data?.iaqi?.h?.v.ToString());
            dictionary.Add("No2" ,data?.iaqi?.no2?.v.ToString());
            dictionary.Add("O3" ,data?.iaqi?.o3?.v.ToString());
            dictionary.Add("P " ,data?.iaqi?.p?.v.ToString());
            dictionary.Add("Pm10" ,data?.iaqi?.pm10?.v.ToString());
            dictionary.Add("Pm25" ,data?.iaqi?.pm25?.v.ToString());
            dictionary.Add("So2" ,data?.iaqi?.so2?.v.ToString());
            dictionary.Add("T" ,data?.iaqi?.t?.v.ToString());
            dictionary.Add("W" ,data?.iaqi?.w?.v.ToString());
            dictionary.Add("Wg" ,data?.iaqi?.wg?.v.ToString());

            return dictionary;
        }


        public List<PollutantMetaData> GetPollutantList()
        {
            var list = new List<PollutantMetaData>();

            list.Add(new PollutantMetaData { Name = "Air quality index", MaxValue = 400, Value = (decimal)data?.aqi, MesuringUnit = ""});
            list.Add(new PollutantMetaData { Name = "CO", MaxValue = 35, Value = (decimal)data?.iaqi?.co?.v });
            list.Add(new PollutantMetaData { Name = "No2", MaxValue = 200, Value = (decimal)data?.iaqi?.no2?.v, MesuringUnit = "µg/m3" });
            list.Add(new PollutantMetaData { Name = "O3", MaxValue = 20, Value = (decimal)data?.iaqi?.o3?.v });
            list.Add(new PollutantMetaData { Name = "Pm10", MaxValue = 150, Value = (decimal)data?.iaqi?.pm10?.v });
            list.Add(new PollutantMetaData { Name = "Pm25", MaxValue = 20, Value = (decimal)data?.iaqi?.pm25?.v });
            list.Add(new PollutantMetaData { Name = "So2", MaxValue = 40, Value = (decimal)data?.iaqi?.so2?.v });

            return list;
        }

        public class PollutantMetaData
        {
            public string MesuringUnit { get; set; }
            public string Name { get; set; }
            public decimal MaxValue { get; set; }
            public decimal? Value { get; set; }

            public decimal GetPercentage()
            {
                if(Value != null)
                {

                    var th = (Value / MaxValue) * 100;
                    return Decimal.Round(th.Value,2);
                }

                return 0;
            }

            public string GetStatus()
            {
                var getPercentage = GetPercentage();
                if (GetPercentage() < 25) return "bg-" + PolutantStatus.success.ToString();
                if (GetPercentage() >= 25 && GetPercentage() < 75) return "bg-" + PolutantStatus.warning.ToString();
                return "bg-" + PolutantStatus.danger.ToString();
            }
        }

        public Dictionary<string, string> GetDictionaryAdvanced()
        {
            var type = this.data.iaqi.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var dictionary = properties.ToDictionary(prop => prop.Name, prop => prop.GetValue(this.data?.iaqi, null).ToString());
            
            return dictionary;
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
            /// <summary>
            /// Carbon monoxide
            /// </summary>
            public Co co { get; set; }
            public Dew dew { get; set; }
            public H h { get; set; }

            /// <summary>
            /// Some kind of nitrogen oxide
            /// </summary>
            /// <remarks>Nitrogen dioxide forms when fossil fuels such as coal, oil, methane gas (natural gas) or diesel are burned at high temperatures.</remarks>
            public No2 no2 { get; set; }

            /// <summary>
            /// Ozon
            /// </summary>
            /// <remarks>Ozone high in the Earth's atmosphere protects us from the sun's harmful radiation. But at ground level, ozone is an air pollutant that harms people and plants. Ground-level ozone forms when nitrogen oxides and volatile organic compounds react with each other in sunlight and hot temperatures.</remarks>
            public O3 o3 { get; set; }
            public P p { get; set; }
            /// <summary>
            /// Particle matter
            /// </summary>
            /// <remarks>inhalable particles, with diameters that are generally 10 micrometers and smaller</remarks>
            public Pm10 pm10 { get; set; }
            /// <summary>
            /// Particle matter
            /// </summary>
            /// <remarks>fine inhalable particles, with diameters that are generally 2.5 micrometers and smaller</remarks>
            public Pm25 pm25 { get; set; }
            /// <summary>
            /// sulfur oxide
            /// </summary>
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
