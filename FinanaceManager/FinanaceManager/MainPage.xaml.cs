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
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7028/api/UserAccount");
            //request.Headers.Add("Content-Type", "application/json");
            //request.Content = new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            // Check if the response was successful (status code 200-299)
            if (response.IsSuccessStatusCode) {
                var message = await response.Content.ReadAsStringAsync();
                await DisplayAlert("OK", message, "OK");
            } else {
                // Login failed, show an error message
                var errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", errorMessage, "OK");
            }
        } catch (HttpRequestException ex) {
            // An error occurred while sending the request
            await DisplayAlert("Error", "Failed to connect to server: " + ex.Message, "OK");
        } catch (Exception ex) {
            // Some other error occurred
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }

        //await DisplayAlert("login", "credentials: " + credentials, "OK");

    }

    private async void OnSignUpTapped(object sender, EventArgs e) {

        await DisplayAlert("sign up", "sign up", "ok");

    }
}

