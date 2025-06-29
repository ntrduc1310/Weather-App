using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Form3 : Form
    {
        private string selectedLanguage;

        public Form3(List<WeatherDetail> details, string language)
        {
            InitializeComponent();
            selectedLanguage = language;
            PopulateDetails(details);
            ApplyTranslations();
            ThemeManager.ApplyTheme(this);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private async void ApplyTranslations()
        {
            string languageCode = GetLanguageCode(selectedLanguage);

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Text = await TranslateText(lbl.Text, languageCode);
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
        private void PopulateDetails(List<WeatherDetail> details)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = details.Count + 1;

            // Set column styles
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            // Add column headers
            AddLabelToTable("Time", 0, 0, true);
            AddLabelToTable("Temperature", 1, 0, true);
            AddLabelToTable("Condition", 2, 0, true);
            AddLabelToTable("", 3, 0, true);

            for (int i = 0; i < details.Count; i++)
            {
                var detail = details[i];

                AddLabelToTable(detail.Time.ToString("HH:mm"), 0, i + 1);

                double formattedTemperature = detail.Temperature;
                AddLabelToTable(string.Format(CultureInfo.InvariantCulture, "{0:F2} °C", formattedTemperature), 1, i + 1);

                AddLabelToTable(detail.Condition, 2, i + 1);

                PictureBox picWeather = new PictureBox
                {
                    Image = GetWeatherImage(detail.Condition),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 5, 0, 5)
                };
                tableLayoutPanel1.Controls.Add(picWeather, 3, i + 1);
            }

            tableLayoutPanel1.AutoSize = true;
            ThemeManager.ApplyTheme(tableLayoutPanel1);

        }

        private void AddLabelToTable(string text, int column, int row, bool isHeader = false)
        {
            Label label = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(5),
                AutoSize = true
            };

            if (isHeader)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            }

            tableLayoutPanel1.Controls.Add(label, column, row);
        }

        private Image GetWeatherImage(string condition)
        {
            condition = condition.ToLower();
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
    }
}