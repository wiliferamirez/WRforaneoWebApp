using foraneoAppMaui.Pages;
namespace foraneoAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage(new AuthService(new HttpClient())));
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = new Window();
            window.MaximumHeight = 850;
            window.MaximumWidth = 375;
            window.MinimumHeight = 850;
            window.MinimumWidth = 375;
            window.Page = new NavigationPage(new LoginPage(new AuthService(new HttpClient())));
            return window;
        }
    }
}
