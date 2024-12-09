using System;
using Microsoft.Maui.Controls;
using foraneoAppMaui.Models;

namespace foraneoAppMaui
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage(string userName)
        {
            InitializeComponent();


            UserNameLabel.Text = $"Hello, {userName}!";
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {

            await Navigation.PopToRootAsync(); 
        }
    }
}
