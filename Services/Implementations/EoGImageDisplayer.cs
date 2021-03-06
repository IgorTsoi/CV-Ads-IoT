using CV.Ads_Client.Services.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CV.Ads_Client.Services.Implementations
{
    public class EoGImageDisplayer : IImageDisplayer
    {
        public void Display(string imagePath, int durationInSeconds)
        {
            if (!File.Exists(imagePath))
            {
                throw new ArgumentException("The path to file is invalid.");
            }

            using var showImageProcess = Process.Start("eog", $"{imagePath} --fullscreen");
            Task.Delay(durationInSeconds * 1000).Wait();
            showImageProcess.Kill();
        }
    }
}