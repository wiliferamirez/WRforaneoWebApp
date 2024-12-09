using foraneoAppMaui.Models;

namespace foraneoAppMaui;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _authService;

    public LoginPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        var loginRequest = new LoginRequest
        {
            Email = email,
            Password = password
        };

        var (success, message, userId) = await _authService.LoginUserAsync(loginRequest);

        if (success)
        {

            await Navigation.PushAsync(new WelcomePage(email));
        }
        else
        {

            await DisplayAlert("Login Failed", message, "OK");
        }
    }
    private async void OnRegisterTapped(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new RegisterPage(_authService));
    }
}
