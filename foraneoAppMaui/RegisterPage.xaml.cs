using foraneoAppMaui.Models;
namespace foraneoAppMaui;

public partial class RegisterPage : ContentPage
{
    private readonly AuthService _authService;

    public RegisterPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string cedula = CedulaEntry.Text;
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string province = ProvinceEntry.Text;
        string program = ProgramEntry.Text;
        DateOnly birthDate = DateOnly.FromDateTime(BirthDayPicker.Date);

        var registerRequest = new RegisterRequest
        {
            Email = email,
            Password = password,
            UserCedula = cedula,
            UserFirstName = firstName,
            UserLastName = lastName,
            UserProvince = province,
            UserProgram = program,
            UserBirthDate = birthDate
        };

        bool success = await _authService.RegisterUserAsync(registerRequest);

        if (success)
        {
            // Navigate to the login page or show a success message
            await DisplayAlert("Registration Successful", "You can now log in.", "OK");
            await Navigation.PushAsync(new LoginPage(_authService));
        }
        else
        {
            // Show error message
            await DisplayAlert("Registration Failed", "There was an error with registration.", "OK");
        }
    }
}
