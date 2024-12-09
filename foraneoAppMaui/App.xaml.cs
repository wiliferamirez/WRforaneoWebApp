using foraneoAppMaui.Pages;
namespace foraneoAppMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
