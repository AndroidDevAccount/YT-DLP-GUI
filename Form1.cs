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
            string currentDir = Environment.CurrentDirectory;
            string downloadFormat = "\"bv*[ext=mp4]+ba*[ext=m4a]/b[ext=mp4]\"";

            // Step 1: Download Video with yt-dlp
            ProcessStartInfo ytDlpProcess = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/k yt-dlp_x86.exe -f {downloadFormat} --output \"{currentDir}\\%(title)s.%(ext)s\" \"{url}\"",
                UseShellExecute = true
            };

            Process ytProcess = Process.Start(ytDlpProcess);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;

            // Step 2: Find the Downloaded File
            DirectoryInfo di = new DirectoryInfo(currentDir);
            FileInfo latestFile = di.GetFiles()
                                    .Where(f => f.Extension == ".mp4" || f.Extension == ".m4a")
                                    .OrderByDescending(f => f.LastWriteTime)
                                    .FirstOrDefault();

            if (latestFile == null)
            {
                MessageBox.Show("File not found for conversion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string inputFile = latestFile.FullName;
            string outputFile = Path.Combine(currentDir, Path.GetFileNameWithoutExtension(inputFile) + "_converted.mp4");

            // Step 3: Convert Video with ffmpeg
            ProcessStartInfo ffmpegProcess = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c ffmpeg -i \"{inputFile}\" -c:v libx264 -preset fast -crf 23 -c:a aac -b:a 128k \"{outputFile}\"",
                UseShellExecute = true
            };

            Process ffProcess = Process.Start(ffmpegProcess);
   
            // Step 4: Open the Folder
            Process.Start("explorer.exe", currentDir);

        }
    }
}
