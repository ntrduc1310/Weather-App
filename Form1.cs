using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WeatherForecast.Properties;
using GenerativeAI.Methods;
using GenerativeAI.Models;
using GenerativeAI.Types;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private Form3 form3;
        private string originalLblCity;
        private string originalLblWeather;
        private string originalLblDegree;
        private string originalLabel1;
        private string originalLabel2;
        private string originalLabel3;
        private string originalLabel4;
        private string originalLabel5;
        private string originalLabel6;
        private string originalLabel7;
        private string originalLabel9;
        private string originalBtnExit;
        private string originalBtnSwitch;
        private string originalButton1;
        private string selectedLanguage;
        private WeatherData currentWeatherData;
        private string currentCity = "";
        private string currentCountry = "";
        public Form1()
        {
            InitializeComponent();
            InitializeThemeToggle();
            InitializeLanguageComboBox();
            SaveOriginalTexts();

            cboxCountry.Enabled = false;
            cboxCity.Enabled = false;
        }

        private void InitializeLanguageComboBox()
        {
            cboxLanguage.SelectedIndexChanged += CboxLanguage_SelectedIndexChanged;
        }

        private void SaveOriginalTexts()
        {
            originalLblCity = lblCity.Text;
            originalLblWeather = lblWeather.Text;
            originalLblDegree = lblDegree.Text;
            originalLabel1 = label1.Text;
            originalLabel2 = label2.Text;
            originalLabel3 = label3.Text;
            originalLabel4 = label4.Text;
            originalLabel5 = label5.Text;
            originalLabel6 = label6.Text;
            originalLabel7 = label7.Text;
            originalLabel9 = label9.Text;
            originalBtnExit = btnExit.Text;
            originalBtnSwitch = btn_Switch.Text;
            originalButton1 = button1.Text;
        }

        private async void CboxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLanguage = cboxLanguage.SelectedItem.ToString();
            string languageCode = GetLanguageCode(selectedLanguage);
            if (!string.IsNullOrEmpty(selectedLanguage))
            {
                cboxCountry.Enabled = true;
                cboxCity.Enabled = true;
            }

            if (languageCode == "en")
            {
                RestoreOriginalTexts();
                lblCity.Text = $"{currentCity}, {currentCountry}";
            }
            else
            {
                await TranslateAllTextsAsync(languageCode);
                lblCity.Text = $"{await TranslateTextAsync(currentCity, languageCode)}, {await TranslateTextAsync(currentCountry, languageCode)}";
            }

            if (!string.IsNullOrEmpty(cboxCity.Text))
            {
                await RefreshWeatherData();
            }
        }

        private void RestoreOriginalTexts()
        {
            lblCity.Text = originalLblCity;
            lblWeather.Text = originalLblWeather;
            lblDegree.Text = originalLblDegree;
            label1.Text = originalLabel1;
            label2.Text = originalLabel2;
            label3.Text = originalLabel3;
            label4.Text = originalLabel4;
            label5.Text = originalLabel5;
            label6.Text = originalLabel6;
            label7.Text = originalLabel7;
            label9.Text = originalLabel9;
            btnExit.Text = originalBtnExit;
            btn_Switch.Text = originalBtnSwitch;
            button1.Text = originalButton1;
        }

        private string GetLanguageCode(string language)
        {
            Dictionary<string, string> languageMap = new Dictionary<string, string>
            {
                { "English", "en" },
                { "Vietnamese", "vi" },
                { "Chinese (Simplified)", "zh-CN" },
                { "Chinese (Traditional)", "zh-TW" },
                { "French", "fr" },
                { "Spanish", "es" },
                { "Indonesian", "id" },
                { "Italian", "it" },
                { "German", "de" },
                { "Ukrainian", "uk" },
                { "Russian", "ru" },
                { "Armenian", "hy" },
                { "Japanese", "ja" },
                { "Thailand", "th" },
                { "Korean", "ko" },
            };

            return languageMap.ContainsKey(language) ? languageMap[language] : "en";
        }

        private async Task TranslateAllTextsAsync(string targetLanguage)
        {
            Console.WriteLine($"Original lblWeather text: {originalLblWeather}");

            string[] textsToTranslate = {
                originalLblCity, originalLblWeather, originalLblDegree,
                originalLabel1, originalLabel2, originalLabel3, originalLabel4,
                originalLabel5, originalLabel6, originalLabel7, originalLabel9,
                originalBtnExit, originalBtnSwitch, originalButton1
            };

            string[] translatedTexts = await TranslateTextsAsync(textsToTranslate, targetLanguage);

            Console.WriteLine($"Translated lblWeather text: {translatedTexts[1]}");

            lblCity.Text = translatedTexts[0];
            lblWeather.Text = translatedTexts[1];
            lblDegree.Text = translatedTexts[2];
            label1.Text = translatedTexts[3];
            label2.Text = translatedTexts[4];
            label3.Text = translatedTexts[5];
            label4.Text = translatedTexts[6];
            label5.Text = translatedTexts[7];
            label6.Text = translatedTexts[8];
            label7.Text = translatedTexts[9];
            label9.Text = translatedTexts[10];
            btnExit.Text = translatedTexts[11];
            btn_Switch.Text = translatedTexts[12];
            button1.Text = translatedTexts[13];

            Console.WriteLine($"lblWeather.Text after assignment: {lblWeather.Text}");
        }

        private async Task<string[]> TranslateTextsAsync(string[] texts, string targetLanguage)
        {
            string apiKey = "AIzaSyDDJ4TksnOoLnREL_7yfxiKYz1yrvALfJM";
            string url = $"https://translation.googleapis.com/language/translate/v2?key={apiKey}";

            using (var client = new HttpClient())
            {
                var requestBody = new
                {
                    q = texts,
                    target = targetLanguage
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(jsonResponse);
                    var translations = data["data"]["translations"]
                                       .Select(t => (string)t["translatedText"])
                                       .ToArray();
                    return translations;
                }
                else
                {
                    MessageBox.Show($"Translation API call failed. Status code: {response.StatusCode}");
                    return texts; // Return original texts in case of failure
                }
            }
        }

        private ChatSession chatSession;
        public string apiKey = "AIzaSyDxjZEeSE5IiLB3yqigOVfDI6sfZrbSZuE";

        List<string> cityNames = new List<string>();

        private void InitializeThemeToggle()
        {
            btn_Switch.Text = "Toggle Dark/Light Mode";
            btn_Switch.Click += Btn_Switch_Click;
        }

        private void Btn_Switch_Click(object sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
            ApplyThemeToAllForms();
        }

        private void ApplyThemeToAllForms()
        {
            ThemeManager.ApplyTheme(this);

            if (form2 != null && !form2.IsDisposed)
                ThemeManager.ApplyTheme(form2);

            if (form3 != null && !form3.IsDisposed)
                ThemeManager.ApplyTheme(form3);
        }

        private async void cboxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (form2 != null && !form2.IsDisposed)
            {
                form2.Close();
            }

            cboxCity.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            cboxCity.Items.Clear();
            cityNames.Clear();

            string countryName = cboxCountry.Text;

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("apikey", "bxfF4nSrkpHHHjW8mWGThEP3IN5oNuWV");

            await Task.Run(() => CountryIsoToCities(request, CountryNameToCountryIso(request, countryName)));
            foreach (string item in cityNames)
            {
                if (!cboxCity.Items.Contains(item))
                    cboxCity.Items.Add(item);
            }

            cboxCity.Enabled = true;
            progressBar1.Visible = false;

            cboxCity.SelectedIndex = -1;
            cboxCity.Text = "";

            ClearWeatherInfo();
        }

        private void ClearWeatherInfo()
        {
            lblCity.Text = "";
            lblDegree.Text = "";
            lblWeather.Text = "";
            lblWind.Text = "";
            lblHumidity.Text = "";
            lblPressure.Text = "";
            lblSunRise.Text = "";
            lblSunSet.Text = "";
            pboxWeather.Image = null;
            gboxWeather.Visible = false;
            groupBox1.Visible = false;
        }

        private string CountryNameToCountryIso(RestRequest request, string countryName)
        {
            string countryIsoCode = "";

            try
            {
                RestClient countryToIsoClient = new RestClient("https://api.apilayer.com/geo/country/name/" + countryName);
                var response = countryToIsoClient.Execute(request);
                if (response.IsSuccessful)
                {
                    dynamic cityIsoResponse = JsonConvert.DeserializeObject(response.Content);
                    foreach (dynamic i in cityIsoResponse)
                    {
                        countryIsoCode = i.alpha3code;
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve country ISO code. Status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving ISO code: " + ex.Message);
            }

            return countryIsoCode;
        }

        private void CountryIsoToCities(RestRequest request, string countryIsoCode)
        {
            try
            {
                RestClient isoToCityClient = new RestClient("https://api.apilayer.com/geo/country/cities/" + countryIsoCode);
                var response = isoToCityClient.Execute(request);
                if (response.IsSuccessful)
                {
                    dynamic cityResponse = JsonConvert.DeserializeObject(response.Content);
                    foreach (dynamic i in cityResponse)
                    {
                        try
                        {
                            string cityName = i.state_or_region;
                            cityNames.Add(cityName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred while extracting city name: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve cities. Status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving cities: " + ex.Message);
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

            try
            {
                XDocument weather = XDocument.Parse(weatherData);

                var temperatures = weather.Descendants("temperature").ToList();
                if (temperatures.Any() && temperatures[0].Attribute("value") != null)
                {
                    string degree = temperatures[0].Attribute("value").Value;
                    lblDegree.Text = degree + "°";
                }
                else
                {
                    lblDegree.Text = "N/A";
                    Console.WriteLine("Temperature data not found.");
                }

                var weatherElements = weather.Descendants("weather").ToList();
                if (weatherElements.Any() && weatherElements[0].Attribute("value") != null)
                {
                    string state = weatherElements[0].Attribute("value").Value;
                    lblWeather.Text = state;
                }
                else
                {
                    lblWeather.Text = "N/A";
                    Console.WriteLine("Weather state data not found.");
                }

                var windElements = weather.Descendants("speed").ToList();
                if (windElements.Any() && windElements[0].Attribute("value") != null)
                {
                    string wind = windElements[0].Attribute("value").Value;
                    lblWind.Text = wind + " m/s";
                }
                else
                {
                    lblWind.Text = "N/A";
                    Console.WriteLine("Wind speed data not found.");
                }

                var humidityElements = weather.Descendants("humidity").ToList();
                if (humidityElements.Any() && humidityElements[0].Attribute("value") != null)
                {
                    string humidity = humidityElements[0].Attribute("value").Value;
                    lblHumidity.Text = humidity + " %";
                }
                else
                {
                    lblHumidity.Text = "N/A";
                    Console.WriteLine("Humidity data not found.");
                }

                var pressureElements = weather.Descendants("pressure").ToList();
                if (pressureElements.Any() && pressureElements[0].Attribute("value") != null)
                {
                    string pressure = pressureElements[0].Attribute("value").Value;
                    lblPressure.Text = pressure + " hPa";
                }
                else
                {
                    lblPressure.Text = "N/A";
                    Console.WriteLine("Pressure data not found.");
                }

                var sunRiseElements = weather.Descendants("sun").ToList();
                if (sunRiseElements.Any() && sunRiseElements[0].Attribute("rise") != null)
                {
                    string sunRiseValue = sunRiseElements[0].Attribute("rise").Value;
                    DateTime sunRise = DateTime.Parse(sunRiseValue);
                    lblSunRise.Text = $"{sunRise.ToLocalTime():HH:mm}";
                }
                else
                {
                    lblSunRise.Text = "N/A";
                    Console.WriteLine("Sunrise data not found.");
                }

                var sunSetElements = weather.Descendants("sun").ToList();
                if (sunSetElements.Any() && sunSetElements[0].Attribute("set") != null)
                {
                    string sunSetValue = sunSetElements[0].Attribute("set").Value;
                    DateTime sunSet = DateTime.Parse(sunSetValue);
                    lblSunSet.Text = $"{sunSet.ToLocalTime():HH:mm}";
                }
                else
                {
                    lblSunSet.Text = "N/A";
                    Console.WriteLine("Sunset data not found.");
                }

                // Store the current weather data
                currentWeatherData = new WeatherData
                {
                    Temperature = lblDegree.Text.TrimEnd('°'),
                    WeatherState = lblWeather.Text,
                    WindSpeed = lblWind.Text.Split(' ')[0],
                    Humidity = lblHumidity.Text.Split(' ')[0],
                    Pressure = lblPressure.Text.Split(' ')[0],
                    SunriseTime = lblSunRise.Text,
                    SunsetTime = lblSunSet.Text
                };

                UpdateWeatherImage(lblWeather.Text);

                // Translate weather state if a non-English language is selected
                if (selectedLanguage != "English")
                {
                    await TranslateWeatherState();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing weather data: " + ex.Message);
            }
        }

        private async Task TranslateWeatherState()
        {
            string languageCode = GetLanguageCode(selectedLanguage);
            string translatedWeatherState = await TranslateTextAsync(lblWeather.Text, languageCode);
            lblWeather.Text = translatedWeatherState;
        }

        private async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            string[] result = await TranslateTextsAsync(new[] { text }, targetLanguage);
            return result[0];
        }

        private void UpdateWeatherImage(string weatherState)
        {
            if (weatherState.Contains("broken"))
                pboxWeather.Image = Resources.broken;
            else if (weatherState.Contains("cloud"))
                pboxWeather.Image = Resources.cloudly;
            else if (weatherState.Contains("snow"))
                pboxWeather.Image = Resources.snowy;
            else if (weatherState.Contains("rain"))
                pboxWeather.Image = Resources.rainy;
            else if (weatherState.Contains("wind"))
                pboxWeather.Image = Resources.windy;
            else if (weatherState.Contains("storm"))
                pboxWeather.Image = Resources.storm;
            else
                pboxWeather.Image = Resources.clear;
        }

        private async Task RefreshWeatherData()
        {
            if (currentWeatherData != null)
            {
                lblDegree.Text = currentWeatherData.Temperature + "°";
                lblWeather.Text = currentWeatherData.WeatherState;
                lblWind.Text = currentWeatherData.WindSpeed + " m/s";
                lblHumidity.Text = currentWeatherData.Humidity + " %";
                lblPressure.Text = currentWeatherData.Pressure + " hPa";
                lblSunRise.Text = currentWeatherData.SunriseTime;
                lblSunSet.Text = currentWeatherData.SunsetTime;

                UpdateWeatherImage(currentWeatherData.WeatherState);

                // Translate weather state if a non-English language is selected
                if (selectedLanguage != "English")
                {
                    await TranslateWeatherState();
                }
            }
        }

        private void cboxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (form2 != null && !form2.IsDisposed)
            {
                form2.Close();
            }

            string cityName = cboxCity.Text;
            string countryName = cboxCountry.Text;
            currentCity = cityName;
            currentCountry = countryName;
            lblCity.Text = $"{cityName}, {countryName}";
            gboxWeather.Visible = true;
            groupBox1.Visible = true;
            CityToWeatherForecast(cityName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCountry = cboxCountry.SelectedItem.ToString();
            string selectedCity = cboxCity.SelectedItem.ToString();
            string selectedLanguage = cboxLanguage.SelectedItem?.ToString();

            if (form2 != null && !form2.IsDisposed)
            {
                form2.Close();
            }

            form2 = new Form2(selectedCountry, selectedCity, selectedLanguage);

            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(form2);
            ThemeManager.ApplyTheme(form2);

            form2.Show();
        }

        private void ShowForm3(List<WeatherDetail> details)
        {
            form3 = new Form3(details, selectedLanguage);
            ThemeManager.ApplyTheme(form3);
            form3.Show();
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblWeather_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblWind_Click(object sender, EventArgs e) { }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }

    public class WeatherData
    {
        public string Temperature { get; set; }
        public string WeatherState { get; set; }
        public string WindSpeed { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string SunriseTime { get; set; }
        public string SunsetTime { get; set; }
    }
}