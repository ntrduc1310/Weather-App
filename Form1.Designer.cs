
namespace WeatherForecast
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cboxCountry = new System.Windows.Forms.ComboBox();
            this.cboxCity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gboxWeather = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFeelsLike = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.lblDegree = new System.Windows.Forms.Label();
            this.pboxWeather = new System.Windows.Forms.PictureBox();
            this.gboxWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxWeather)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxCountry
            // 
            this.cboxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCountry.ForeColor = System.Drawing.Color.Navy;
            this.cboxCountry.FormattingEnabled = true;
            this.cboxCountry.Items.AddRange(new object[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Central African Rep",
            "Colombia",
            "Comoros",
            "Congo",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Chad",
            "Chile",
            "China",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Ivory Coast",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Montenegro",
            "Mongolia",
            "Morocco",
            "Mozambique",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Poland",
            "Portugal",
            "Philippines",
            "Qatar",
            "Romania",
            "Russian Federation",
            "Rwanda",
            "Samoa",
            "San Marino",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Togo",
            "Tonga",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Thailand",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.cboxCountry.Location = new System.Drawing.Point(38, 37);
            this.cboxCountry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboxCountry.Name = "cboxCountry";
            this.cboxCountry.Size = new System.Drawing.Size(146, 21);
            this.cboxCountry.Sorted = true;
            this.cboxCountry.TabIndex = 0;
            this.cboxCountry.SelectedIndexChanged += new System.EventHandler(this.cboxCountry_SelectedIndexChanged);
            // 
            // cboxCity
            // 
            this.cboxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCity.Enabled = false;
            this.cboxCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboxCity.ForeColor = System.Drawing.Color.Navy;
            this.cboxCity.FormattingEnabled = true;
            this.cboxCity.Location = new System.Drawing.Point(194, 37);
            this.cboxCity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboxCity.Name = "cboxCity";
            this.cboxCity.Size = new System.Drawing.Size(146, 21);
            this.cboxCity.Sorted = true;
            this.cboxCity.TabIndex = 1;
            this.cboxCity.SelectedIndexChanged += new System.EventHandler(this.cboxCity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(88, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Country";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(241, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "City/State";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 68);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 19);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // gboxWeather
            // 
            this.gboxWeather.Controls.Add(this.label7);
            this.gboxWeather.Controls.Add(this.label6);
            this.gboxWeather.Controls.Add(this.lblFeelsLike);
            this.gboxWeather.Controls.Add(this.lblHumidity);
            this.gboxWeather.Controls.Add(this.label5);
            this.gboxWeather.Controls.Add(this.lblPressure);
            this.gboxWeather.Controls.Add(this.lblWind);
            this.gboxWeather.Controls.Add(this.label3);
            this.gboxWeather.Controls.Add(this.lblCity);
            this.gboxWeather.Controls.Add(this.lblWeather);
            this.gboxWeather.Controls.Add(this.lblDegree);
            this.gboxWeather.Controls.Add(this.pboxWeather);
            this.gboxWeather.Location = new System.Drawing.Point(9, 92);
            this.gboxWeather.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxWeather.Name = "gboxWeather";
            this.gboxWeather.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gboxWeather.Size = new System.Drawing.Size(359, 284);
            this.gboxWeather.TabIndex = 8;
            this.gboxWeather.TabStop = false;
            this.gboxWeather.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(182, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Feels Like";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(182, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pressure";
            // 
            // lblFeelsLike
            // 
            this.lblFeelsLike.AutoSize = true;
            this.lblFeelsLike.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeelsLike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFeelsLike.Location = new System.Drawing.Point(269, 240);
            this.lblFeelsLike.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFeelsLike.Name = "lblFeelsLike";
            this.lblFeelsLike.Size = new System.Drawing.Size(56, 17);
            this.lblFeelsLike.TabIndex = 14;
            this.lblFeelsLike.Text = "00.00°";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumidity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblHumidity.Location = new System.Drawing.Point(110, 240);
            this.lblHumidity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(44, 17);
            this.lblHumidity.TabIndex = 15;
            this.lblHumidity.Text = "00 %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(43, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Humidity";
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPressure.Location = new System.Drawing.Point(259, 211);
            this.lblPressure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(77, 17);
            this.lblPressure.TabIndex = 17;
            this.lblPressure.Text = "0000 hPa";
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWind.Location = new System.Drawing.Point(87, 211);
            this.lblWind.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(70, 17);
            this.lblWind.TabIndex = 18;
            this.lblWind.Text = "0.00 m/s";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(43, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Wind";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCity.Location = new System.Drawing.Point(195, 38);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(93, 18);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City, Country";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeather.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblWeather.Location = new System.Drawing.Point(230, 131);
            this.lblWeather.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(56, 20);
            this.lblWeather.TabIndex = 11;
            this.lblWeather.Text = "Snowy";
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDegree.Location = new System.Drawing.Point(189, 69);
            this.lblDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(147, 51);
            this.lblDegree.TabIndex = 9;
            this.lblDegree.Text = "00.00°";
            // 
            // pboxWeather
            // 
            this.pboxWeather.Image = global::WeatherForecast.Properties.Resources.clear;
            this.pboxWeather.Location = new System.Drawing.Point(15, 17);
            this.pboxWeather.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pboxWeather.Name = "pboxWeather";
            this.pboxWeather.Size = new System.Drawing.Size(160, 154);
            this.pboxWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxWeather.TabIndex = 8;
            this.pboxWeather.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(377, 386);
            this.Controls.Add(this.gboxWeather);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxCity);
            this.Controls.Add(this.cboxCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weather Forecast";
            this.gboxWeather.ResumeLayout(false);
            this.gboxWeather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxWeather)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxCountry;
        private System.Windows.Forms.ComboBox cboxCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox gboxWeather;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFeelsLike;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.PictureBox pboxWeather;
    }
}

