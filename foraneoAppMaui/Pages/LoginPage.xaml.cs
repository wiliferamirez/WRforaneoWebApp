using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;
using Microsoft.Maui.Controls;
using foraneoAppMaui.Models;

namespace foraneoAppMaui.Pages;

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
        string email = EmailEntryLogin.Text;
        string password = PasswordEntryLogin.Text;

        var loginRequest = new LoginRequest
        {
            Email = email,
            Password = password
        };

        var (success, message, userId) = await _authService.LoginUserAsync(loginRequest);

        if (success)
        {
            await DisplayAlert("Login successfull.", message, "Ok");
        }
        else
        {
            // Show the error message
            await DisplayAlert("Login Failed", message, "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage(_authService));
    }
}