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
        private async void OnCategoriesClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Categories());
        }
        private async void OnEventsClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Events());
        }
    }
}
