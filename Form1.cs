using Newtonsoft.Json;
using RestSharp;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using WeatherForecast.Properties;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> cityNames = new List<string>();

        private async void cboxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxCity.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            cboxCity.Items.Clear();

            string countryName = cboxCountry.Text;

            RestRequest request = new RestRequest(Method.GET); //creating get RestRequest
            request.AddHeader("apikey", "bxfF4nSrkpHHHjW8mWGThEP3IN5oNuWV"); //apikey for authentication

            await Task.Run(()=> CountryIsoToCities(request, CountryNameToCountryIso(request, countryName))); //run methods for get cities
            foreach (string item in cityNames) //add cities to combobox
            {
                if (!cboxCity.Items.Contains(item))
                    cboxCity.Items.Add(item);
            }

            cboxCity.Enabled = true;
            progressBar1.Visible = false;
        }

        private string CountryNameToCountryIso(RestRequest request,string countryName)
        {
            string countryIsoCode = "";

            RestClient countryToIsoClient = new RestClient("https://api.apilayer.com/geo/country/name/" + countryName); //country name to
                                                                                                                        //iso codes
                                                                                                                        //restclient for api
            dynamic cityIsoResponse = JsonConvert.DeserializeObject(countryToIsoClient.Execute(request).Content);
            foreach (dynamic i in cityIsoResponse)
            {
                //try
                //{
                    countryIsoCode = i.alpha3code; //getting iso code by country
                //}
                //catch { }
            }
            return countryIsoCode;
        }

        private void CountryIsoToCities(RestRequest request,string countryIsoCode)
        {
            
            string cityName = "";

            RestClient isoToCityClient = new RestClient("https://api.apilayer.com/geo/country/cities/" + countryIsoCode); //iso code to cities
                                                                                                                          //restclient for api
            dynamic cityResponse = JsonConvert.DeserializeObject(isoToCityClient.Execute(request).Content); //getting and editing data
            foreach (dynamic i in cityResponse) //selecting data required(city names)
            {
                try
                {
                    cityName = i.state_or_region; //getting cities by country iso code
                    cityNames.Add(cityName);
                }
                catch { }
            }
        }

        private async Task<string> GetWeatherDataAsync(string cityName)
        {
            string apiKey = "ade8d3238fea9c28b48cfdbcf3dbcefb";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&mode=xml&lang=en&units=metric&appid={apiKey}";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }

        private async void CityToWeatherForecast(string cityName)
        {
            string weatherData = await GetWeatherDataAsync(cityName);

            XDocument weather = XDocument.Parse(weatherData);

            var temperatures = weather.Descendants("temperature").ToList();
            if (temperatures.Any())
            {
                string degree = temperatures[0].Attribute("value").Value;
                lblDegree.Text = degree + "°";
            }
            else
            {
                // Handle the case where there are no temperature elements
                Console.WriteLine("No temperature elements found.");
            }

            string state = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            lblWeather.Text = state;

            string wind = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
            lblWind.Text = wind + " m/s";

            string humidity = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            lblHumidity.Text = humidity + " %";

            string feelsLike = weather.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
            lblFeelsLike.Text = feelsLike + "°";

            string pressure = weather.Descendants("pressure").ElementAt(0).Attribute("value").Value;
            lblPressure.Text = pressure + " hPa";

            // Set weather image based on the state
            if (state.Contains("broken"))
                pboxWeather.Image = Resources.broken;
            else if (state.Contains("cloud"))
                pboxWeather.Image = Resources.cloudly;
            else if (state.Contains("snow"))
                pboxWeather.Image = Resources.snowy;
            else if (state.Contains("rain"))
                pboxWeather.Image = Resources.rainy;
            else if (state.Contains("wind"))
                pboxWeather.Image = Resources.windy;
            else if (state.Contains("storm"))
                pboxWeather.Image = Resources.storm;
            else
                pboxWeather.Image = Resources.clear;
        }

        private void cboxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cityName = cboxCity.Text;
            string countryName = cboxCountry.Text;
            gboxWeather.Visible = true;
            lblCity.Text = cityName + ", " + countryName;
            CityToWeatherForecast(cityName);
        }
    }
}
