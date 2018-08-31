using System;
using System.Net;
using System.Windows.Forms;

namespace Challenge_11_Develop_a_Windows_Form_Project_to_Display_HTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDowload_Click(object sender, EventArgs e)
        {
            DownloadHtml(textBoxUrl.Text);
        }

        private async void DownloadHtml(string url)
        {
            string result;
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    result = await webClient.DownloadStringTaskAsync(new Uri(url));
                    BeginInvoke(new MethodInvoker(() => { labelViewHtml.Text = result; }));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Ooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
