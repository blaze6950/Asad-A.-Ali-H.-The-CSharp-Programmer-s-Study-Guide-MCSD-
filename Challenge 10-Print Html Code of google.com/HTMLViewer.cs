using System;
using System.Net;

namespace Challenge_10_Print_Html_Code_of_google.com
{
    public class HtmlViewer : IDisposable
    {
        private Uri _url;
        private string _html;
        private WebClient _webClient;

        public HtmlViewer(string url)
        {
            _url = new Uri(url);
        }

        public Uri Url
        {
            get { return _url; }
            set
            {
                _url = value;
            }
        }

        public void Show()
        {
            Load();
            Print();
        }

        private void Print()
        {
            Console.WriteLine(_html);
        }

        private void Load()
        {
            if (_url != null)
            {
                _webClient = new WebClient();
                _html = _webClient.DownloadString(_url);
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _webClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HtmlViewer()
        {
            Dispose(false);
        }
    }
}