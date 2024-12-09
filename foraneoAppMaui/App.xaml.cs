namespace foraneoAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage(new AuthService(new HttpClient())));
        }
    }
}
