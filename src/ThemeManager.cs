using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public static class ThemeManager
    {
        public static bool IsDarkMode { get; private set; } = false;

        public static Color LightBackColor = Color.FromArgb(255, 253, 245, 230);  // Peach color
        public static Color LightForeColor = Color.Black;
        public static Color DarkBackColor = Color.FromArgb(255, 44, 62, 80);  // Dark blue
        public static Color DarkForeColor = Color.White;

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }

        public static void ApplyTheme(Control control)
        {
            control.BackColor = IsDarkMode ? DarkBackColor : LightBackColor;
            control.ForeColor = IsDarkMode ? DarkForeColor : LightForeColor;

            foreach (Control child in control.Controls)
            {
                ApplyTheme(child);
            }

            if (control is Form form)
            {
                foreach (DataGridView dgv in form.Controls.OfType<DataGridView>())
                {
                    ApplyThemeToDataGridView(dgv);
                }
            }
        }

        private static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = IsDarkMode ? DarkBackColor : LightBackColor;
            dgv.ForeColor = IsDarkMode ? DarkForeColor : LightForeColor;
            dgv.DefaultCellStyle.BackColor = IsDarkMode ? DarkBackColor : LightBackColor;
            dgv.DefaultCellStyle.ForeColor = IsDarkMode ? DarkForeColor : LightForeColor;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = IsDarkMode ? DarkBackColor : LightBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = IsDarkMode ? DarkForeColor : LightForeColor;
        }
    }
}
