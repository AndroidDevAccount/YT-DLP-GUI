# YT-DLP GUI
A lightweight Windows GUI for [`yt-dlp`](https://github.com/yt-dlp/yt-dlp) built using C# WinForms.

## Features
- Paste a YouTube URL and download the best quality video + audio.
- Uses `yt-dlp_x86.exe` for downloading.
- Opens a command window to show progress.
- No external dependencies except `yt-dlp` and `.NET`.

## Requirements
- Windows OS
- [yt-dlp](https://github.com/yt-dlp/yt-dlp) (`yt-dlp_x86.exe` must be in the same folder)
- .NET Runtime (if using the compiled `.exe`)

## How to Use
1. Download `yt-dlp_x86.exe` and place it in the same folder as the app.
2. Run `YTDownloader.exe`.
3. Paste a YouTube URL and click "Download".
4. A command window will show the download progress.

## Installation
### Running From Source
1. Clone the repository:
   ```sh
   git clone https://github.com/AndroidDevAccount/YT-DLP-GUI.git
