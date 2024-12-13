using foraneoAppMaui.Models;

namespace foraneoAppMaui.Pages;

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
        string cedula = CedulaEntry.Text;
        string name = NameEntry.Text;
        string lastName = LastNameEntry.Text;
        string email = EmailEntry.Text;
        string province = ProvinceEntry.Text;
        string program = ProgramEntry.Text;
        DateTime birthday = BirthdayPickerRegister.Date;
        DateOnly birthdayUser = DateOnly.FromDateTime(birthday);
        string password = PasswordEntry.Text;

        var registerRequest = new RegisterRequest
        {
            Email = email,
            Password = password,
            UserCedula = cedula,
            UserFirstName = name,
            UserLastName = lastName,
            UserProvince = province,
            UserProgram = program,
            UserBirthDate = birthdayUser
        };

        var (success, message) = await _authService.RegisterUserAsync(registerRequest);

        if (success)
        {
            await DisplayAlert("Registration Successful", message, "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Registration Failed", message, "OK");
        }
    }
}