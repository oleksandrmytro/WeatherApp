using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWheatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "Oy9YcFrLWZAqzMttp8AiPzhZr7jyuAxH";

        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);

            using(HttpClient client = new HttpClient())
            {
                var respons = await client.GetAsync(url);
                string json = await respons.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentCoditions> GetCurrentCoditions(string cityKey)
        {
            CurrentCoditions currentCoditions = new CurrentCoditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var respons = await client.GetAsync(url);
                string json = await respons.Content.ReadAsStringAsync();

                currentCoditions = (JsonConvert.DeserializeObject<List<CurrentCoditions>>(json)).FirstOrDefault();
            }

            return currentCoditions;
        }
    }
}
