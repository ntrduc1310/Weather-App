using System;
using System.Windows.Forms;
using System.Drawing;
using WeatherForecast;

namespace WeatherForecast
{
    public partial class Form5 : Form
    {
        private Button startForm1Button;
        private Button exitButton;

        public Form5()
        {
            InitializeComponent();

            // Set the form size (adjust as needed)
            this.Size = new Size(1200, 720);

            // Set the background image
            this.BackgroundImage = Image.FromFile(@"D:\background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Create and style the start button
            CreateStartButton();

            // Create and style the exit button
            CreateExitButton();

            // Add the buttons to the form
            this.Controls.Add(startForm1Button);
            this.Controls.Add(exitButton);
        }

        private void CreateStartButton()
        {
            startForm1Button = new Button();
            startForm1Button.Text = "Start Form1";
            startForm1Button.Size = new Size(200, 80);
            startForm1Button.Location = new Point(
                (this.ClientSize.Width - startForm1Button.Width) / 2,
                (this.ClientSize.Height - startForm1Button.Height) / 2
            );
            startForm1Button.Click += StartForm1Button_Click;

            // Style the start button
            startForm1Button.FlatStyle = FlatStyle.Flat;
            startForm1Button.FlatAppearance.BorderSize = 0;
            startForm1Button.BackColor = Color.Transparent;
            startForm1Button.Font = new Font("Consolas", 14, FontStyle.Regular);
            startForm1Button.ForeColor = Color.Black;

            // Add hover effect
            startForm1Button.MouseEnter += StartForm1Button_MouseEnter;
            startForm1Button.MouseLeave += StartForm1Button_MouseLeave;
        }

        private void CreateExitButton()
        {
            exitButton = new Button();
            exitButton.Text = "Exit";
            exitButton.Size = new Size(80, 40);
            exitButton.Location = new Point(
                this.ClientSize.Width - exitButton.Width - 10,
                this.ClientSize.Height - exitButton.Height - 10
            );
            exitButton.Click += ExitButton_Click;

            // Style the exit button (similar to start button)
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.BackColor = Color.Transparent;
            exitButton.Font = new Font("Consolas", 14, FontStyle.Bold);
            exitButton.ForeColor = Color.White;

            // Add hover effect
            exitButton.MouseEnter += ExitButton_MouseEnter;
            exitButton.MouseLeave += ExitButton_MouseLeave;
        }

        private void StartForm1Button_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            // If No, do nothing and return to the form
        }
        private void StartForm1Button_MouseEnter(object sender, EventArgs e)
        {
            startForm1Button.BackColor = Color.LightBlue;
        }

        private void StartForm1Button_MouseLeave(object sender, EventArgs e)
        {
            startForm1Button.BackColor = Color.Transparent;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.LightBlue;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Transparent;
        }
        public void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}