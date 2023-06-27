using Newtonsoft.Json.Linq;

namespace API_weather
{
    public class ApiResponse
    {
        public object? data { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; } = string.Empty;

    }
}
