namespace Challenge_12_Validate_Email_Phone_Number_and_Website
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var passport = new Passport();
            ButtonEnter.Click += passport.ButtonEnter_Click;
            DataContext = passport;
        }
    }
}
