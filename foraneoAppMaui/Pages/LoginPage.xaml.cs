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

	private async void OnLoinClicked(object sender, EventArgs e)
	{
		string emailLogin = EmailEntryLogin.Text;
		string password = PasswordEntryLogin.Text;

		var loginRequest = new LoginRequest { Email = emailLogin, Password = password };

		var (success, message, userId) = await _authService.LoginUserAsync(loginRequest);

        if (success)
        {
			await DisplayAlert("Succesfully Login", "", "OK");
		}
		else
		{
			await DisplayAlert("Login Failed", "Try Again", "OK");
		}

    }
	private async void OnRegisterClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}




}