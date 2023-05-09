using Newtonsoft.Json;
using System.Text;

namespace FinanaceManager;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private readonly HttpClient _httpClient = new HttpClient();

    private async void onLoginClicked(object sender, EventArgs e) {
        var credentials = new {
            email = EmailEntry.Text,
            password = PasswordEntry.Text
        };

        try {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7028/api/UserAccess/login");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClient");
            request.Content = new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode) {
                var message = await response.Content.ReadAsStringAsync();
                await DisplayAlert("OK", message, "OK");
            } else {
                //failed login
                var errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", errorMessage, "OK");

            }
        } catch (HttpRequestException ex) {

            await DisplayAlert("Error", "Failed to connect to server: " + ex.Message, "OK");

        } catch (Exception ex) {

            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }

    }

    private async void OnSignUpTapped(object sender, EventArgs e) {

        await DisplayAlert("sign up", "sign up", "ok");

    }
}

