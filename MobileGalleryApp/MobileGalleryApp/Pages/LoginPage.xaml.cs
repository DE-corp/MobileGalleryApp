using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGalleryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login_Click(object sender, EventArgs e)
        {
            if (Code.Text == null)
            {
                await DisplayAlert("Ошибка!", "Поле кода пустое!", "Ok");
                return;
            }
            if (Code.Text.Length != 4)
            {
                await DisplayAlert("Ошибка!", "Длина кода должна быть равна 4 символам!", "Ok");
                return;
            }
            if (!Preferences.ContainsKey("password"))
            {
                Preferences.Set("password", Code.Text);
            }
            if (Code.Text != Preferences.Get("password", "password"))
            {
                await DisplayAlert("Ошибка!", "Не верный код!", "Ok");
                return;
            }
            loginButton.Text = "Выполняется вход..";
            //await Task.Delay(60);
            await Navigation.PushAsync(new ImageListPage());
        }
    }
}