namespace Challenge_10_Print_Html_Code_of_google.com
{
    class Program
    {
        static void Main()
        {
            using (HtmlViewer viewer = new HtmlViewer(@"http://www.google.com"))
            {
                viewer.Show();
            }
        }
    }
}
