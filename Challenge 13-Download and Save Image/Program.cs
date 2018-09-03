namespace Challenge_13_Download_and_Save_Image
{
    class Program
    {
        static void Main()
        {
            ImageDownloader newDownloader = new ImageDownloader();
            newDownloader.SaveImage(@"https://www.bmw.ua/content/dam/bmw/common/all-models/x-series/x6/2014/model-card/bmw-mperformance-x6-m50d-flyout-890x501.png");
        }
    }
}
