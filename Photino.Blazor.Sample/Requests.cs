using System;
using System.Text.Json.Serialization;

namespace Photino.Blazor.Sample
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    [JsonSerializable(typeof(WeatherForecast[]))]
    internal partial class WeatherForecastContext : JsonSerializerContext
    {
    }
}