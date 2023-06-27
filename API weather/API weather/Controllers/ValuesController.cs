using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API_weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public ValuesController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> GetApiData()
        {
            string apiUrl = "http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587%20923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a"; // URL của API bạn muốn gọi

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the JSON object
                JObject obj = JObject.Parse(responseBody);

                JArray list = obj["list"] as JArray;

                JArray resultArray = new JArray();

                foreach (JObject item in list!)
                {
                    int cityId = item["id"]!.ToObject<int>();
                    string cityName = item["name"]!.ToString();
                    string weatherMain = item["weather"]![0]!["main"]!.ToString();
                    string weatherDescription = item["weather"]![0]!["description"]!.ToString();
                    string weatherIcon = $"http://openweathermap.org/img/wn/{item["weather"]![0]!["icon"]!.ToString()}@2x.png";
                    double mainTemp = item["main"]!["temp"]!.ToObject<double>();
                    int mainHumidity = item["main"]!["humidity"]!.ToObject<int>();

                    JObject resultItem = new JObject(
                        new JProperty("cityId", cityId),
                        new JProperty("cityName", cityName),
                        new JProperty("weatherMain", weatherMain),
                        new JProperty("weatherDescription", weatherDescription),
                        new JProperty("weatherIcon", weatherIcon),
                        new JProperty("mainTemp", mainTemp),
                        new JProperty("mainHumidity", mainHumidity)
                    );

                    // Add the transformed object to the result array
                    resultArray.Add(resultItem);
                }

                // Convert the result array to string
                string resultJson = resultArray.ToString();


                return Ok(resultJson) ;
            }

            return BadRequest(new ApiResponse
            {
                data = null,
                statusCode = 400,
                message = "Fail"
            }); 
        }
    }
}
