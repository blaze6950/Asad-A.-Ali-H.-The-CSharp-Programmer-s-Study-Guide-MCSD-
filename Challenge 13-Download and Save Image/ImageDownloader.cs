using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace Challenge_13_Download_and_Save_Image
{
    public class ImageDownloader
    {
        private string _url;
        private string _path = @"E:\GoogleDrive\Программовня\Work\FirstProgram\Challenge 13-Download and Save Image\image.png";

        public void SaveImage(string url)
        {
            _url = url;
            GetImage();
            WriteToFileByte();
            ReadFromFileByte();
        }

        private void WriteToFileByte()
        {
            var bytes = File.ReadAllBytes(_path);
            ByteArrayToFile(_path.Substring(0, _path.Length - 9) + "ImageData.bin", bytes);
        }

        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    fs.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        private void ReadFromFileByte()
        {
            try
            {
                using (var fs = new FileStream(_path.Substring(0, _path.Length - 9) + "ImageData.bin", FileMode.Open, FileAccess.Read))
                {
                    Image image = Image.FromStream(fs);
                    image.Save(_path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
            }
        }

        private void GetImage()
        {
            var image = DownloadImageFromUrl(_url.Trim());
            image.Save(_path);
        }

        public Image DownloadImageFromUrl(string imageUrl)
        {
            Image image;
            WebResponse webResponse = null;

            try
            {
                var webRequest =
                    (HttpWebRequest) WebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                webResponse = webRequest.GetResponse();
                var stream = webResponse.GetResponseStream();
                image = Image.FromStream(stream ?? throw new InvalidOperationException());
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (webResponse != null) webResponse.Close();
            }

            return image;
        }
    }
}