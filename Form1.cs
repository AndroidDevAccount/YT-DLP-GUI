using System.Diagnostics;

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a YouTube URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Run yt-dlp.exe with a visible command window
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/k yt-dlp_x86.exe -f bestvideo+bestaudio \"{url}\"",
                UseShellExecute = true // This allows the command window to be visible
            };

            Process.Start(psi);

        }
    }
}
