using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System;
using System.Drawing;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WeatherForecast
{
    public partial class Form2 : Form
    {
        private Label lblHeading;
        private string selectedLanguage;
        private const string API_KEY = "03d51b5f379243d0758fcdd762a1f37a";
        private const string GOOGLE_TRANSLATE_API_KEY = "AIzaSyDDJ4TksnOoLnREL_7yfxiKYz1yrvALfJM"; 
        public delegate void UpdatePanelHandler(string data);
        public event UpdatePanelHandler OnUpdatePanel;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=@LOC@&mode=xml&units=metric&APPID=" + API_KEY;
        private List<Button> btnDetailList = new List<Button>();

        private string[] QueryCodes = { "q", "zip", "id", };

        public void ApplyTheme()
        {
            ThemeManager.ApplyTheme(this);
        }

        public Form2(string country, string city, string language)
        {
            InitializeComponent();
            InitializeHeadingLabel(); 
            selectedLanguage = language;
            ApplyTranslations(); 
            InitializeAsync(country, city);

            // Ẩn tất cả các control
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }

            // Hiển thị loading
            Label loadingLabel = new Label
            {
                Text = "Loading forecast...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(this.Font.FontFamily, 14, FontStyle.Bold),
                Visible = true
            };
            this.Controls.Add(loadingLabel);

            InitializeAsync(country, city);
        }

        private async void InitializeAsync(string country, string city)
        {
            txtCountry.Text = country;
            txtCity.Text = city;
            txtLocation.Text = city;

            await FetchAndDisplayForecast("q", city);

            // Gỡ bỏ loading
            foreach (Control control in this.Controls)
            {
                if (control is Label lbl && lbl.Text == "Đang tải dự báo...")
                {
                    this.Controls.Remove(control);
                    break;
                }
            }

            // Hiển thị tất cả control
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }
        }
        private void InitializeHeadingLabel()
        {
            lblHeading = new Label
            {
                Text = "Forecast for the next 5 days",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            this.Controls.Add(lblHeading); 

            
            for (int i = 0; i < 5; i++)
            {
                Button btnDetail = new Button
                {
                    Text = "Show details", 
                    Location = new Point(10, 160),
                    Size = new Size(120, 30)
                };
                this.Controls.Add(btnDetail);
            }
        }
        private async void ApplyTranslations()
        {
            string languageCode = GetLanguageCode(selectedLanguage);

            if (lblHeading != null)
            {
                lblHeading.Text = await TranslateText(lblHeading.Text, languageCode);
            }

            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Text == "Show details" )
                {
                    btn.Text = await TranslateText(btn.Text, languageCode);
                }
                else if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is Label lbl)
                        {
                            lbl.Text = await TranslateText(lbl.Text, languageCode);
                        }
                        else if (panelControl is Button panelBtn)
                        {
                            panelBtn.Text = await TranslateText(panelBtn.Text, languageCode);
                        }
                    }
                }
            }
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
                { "Korean", "ko" }
            };

            return languageMap.ContainsKey(language) ? languageMap[language] : "en";
        }

        private async Task<string> TranslateText(string text, string targetLanguage)
        {
            var client = new RestClient("https://translation.googleapis.com/language/translate/v2");
            var request = new RestRequest(Method.POST);
            request.AddParameter("key", "AIzaSyDDJ4TksnOoLnREL_7yfxiKYz1yrvALfJM");
            request.AddParameter("q", text);
            request.AddParameter("target", targetLanguage);

            IRestResponse response = await client.ExecuteAsync(request);
            JObject jsonResponse = JObject.Parse(response.Content);
            return jsonResponse["data"]["translations"][0]["translatedText"].ToString();
        }

        private async Task FetchAndDisplayForecast(string queryType, string location)
        {
            string url = ForecastUrl.Replace("@LOC@", location).Replace("@QUERY@", queryType);

            using (var client = new WebClient())
            {
                try
                {
                    string result = await client.DownloadStringTaskAsync(new Uri(url));
                    DisplayForecast(result);
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }

        private void DisplayForecast(string xml)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.Text = loc_node.SelectSingleNode("name").InnerText;
            txtCountry.Text = loc_node.SelectSingleNode("country").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.Text = geo_node.Attributes["latitude"].Value;
            txtLong.Text = geo_node.Attributes["longitude"].Value;
            txtId.Text = geo_node.Attributes["geobaseid"].Value;

            List<WeatherDetail> forecastDetails = new List<WeatherDetail>();

            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                DateTime time = DateTime.Parse(time_node.Attributes["from"].Value, null, DateTimeStyles.AssumeUniversal);
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                XmlNode condition_node = time_node.SelectSingleNode("symbol");
                string condition = condition_node.Attributes["name"].Value;

                forecastDetails.Add(new WeatherDetail
                {
                    Date = time.Date,
                    Time = time,
                    Temperature = double.Parse(temp),
                    Condition = condition
                });
            }

            InitializePanel(forecastDetails);
        }

        private void InitializePanel(List<WeatherDetail> forecastDetails)
        {
            
            this.Controls.Clear();

            
            Label lblHeading = new Label
            {
                Text = "Forecast for the next 5 days",
                Font = new Font("Arial", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            this.Controls.Add(lblHeading);

           
            for (int i = 0; i < 5; i++)
            {
                DateTime currentDate = forecastDetails[i * 8].Date;

                double rawTemperature = forecastDetails[i * 8].Temperature;
                var temperature = string.Format(CultureInfo.InvariantCulture, "{0:F2} °C", rawTemperature);

                string condition = forecastDetails[i * 8].Condition;

                Panel dayPanel = new Panel
                {
                    Size = new Size(200, 250),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(10 + i * 160 + i * 100, 50)
                };

                Label lblDate = new Label
                {
                    Text = currentDate.ToString("dd/MM/yyyy"),
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    BackColor = Color.LightBlue,
                    Margin = new Padding(10)
                };

                Label lblTemperature = new Label
                {
                    Text = temperature,
                    Font = new Font("Arial", 14, FontStyle.Regular),
                    Location = new Point(10, 50),
                    AutoSize = true
                };

                PictureBox picWeather = new PictureBox
                {
                    Size = new Size(50, 50),
                    Location = new Point(10, 90),
                    Image = GetWeatherImage(condition),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                Button btnDetail = new Button
                {
                    Text = "Show details",
                    Location = new Point(10, 160),
                    Size = new Size(120, 30)
                };
                btnDetailList.Add(btnDetail);
                int dayIndex = i; 
                btnDetail.Click += (sender, e) => ShowDetails(dayIndex, forecastDetails);

                dayPanel.Controls.Add(lblDate);
                dayPanel.Controls.Add(lblTemperature);
                dayPanel.Controls.Add(picWeather);
                dayPanel.Controls.Add(btnDetail);
                // Áp dụng theme
                ThemeManager.ApplyTheme(dayPanel);
                this.Controls.Add(dayPanel);
                ApplyTranslations();

            }
        }

        private Image GetWeatherImage(string condition)
        {
            // Lấy ảnh theo tình trạng thời tiết
            if (condition.Contains("rain"))
            {
                return Properties.Resources.rainy;
            }
            else if (condition.Contains("cloud"))
            {
                return Properties.Resources.cloudly;
            }
            else
            {
                return Properties.Resources.clear;
            }
        }

        private void ShowDetails(int dayIndex, List<WeatherDetail> forecastDetails)
        {
            var dayDetails = forecastDetails.GetRange(dayIndex * 8, 8);
            Form3 detailForm = new Form3(dayDetails, selectedLanguage);
            ThemeManager.ApplyTheme(detailForm);
            detailForm.ShowDialog();
        }

        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
            }
        }


    }

    public class WeatherDetail
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
    }
}
