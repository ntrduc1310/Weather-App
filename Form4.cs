using GenerativeAI.Methods;
using GenerativeAI.Models;
using GenerativeAI.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Form4 : Form
    {
        private ChatSession chatSession;
        public string apiKey = "AIzaSyDxjZEeSE5IiLB3yqigOVfDI6sfZrbSZuE"; // Thay thế bằng API key của bạn

        public Form4()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync(txtMessage.Text.Trim());
        }

        private async  Task  SendMessageAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            if (chatSession == null)
            {
                MessageBox.Show("Chat session is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Your existing code to send the message
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AppendMessage(string sender, string message, Color color, HorizontalAlignment alignment)
        {
            txtBody.SelectionColor = color;
            txtBody.SelectionAlignment = alignment;
            txtBody.AppendText($"{sender}: {message}\n");
            txtBody.ScrollToCaret();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var model = new GenerativeModel(apiKey);
            chatSession = model.StartChat(new StartChatParams());
        }

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await SendMessageAsync(txtMessage.Text.Trim());
            }
        }
    }
}