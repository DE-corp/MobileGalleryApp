using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGalleryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageListPage : ContentPage
    {
        public ObservableCollection<Image> Photos { get; set; } = new ObservableCollection<Image>();
        Image SelectedImage;
        public ImageListPage()
        {
            InitializeComponent();
            Photos.Add(new Image() { Source = "Multivarka.jpg" });
            Photos.Add(new Image() { Source = "Samogonnyy_apparat.jpg" });
            Photos.Add(new Image() { Source = "Stiralnaya_mashina.jpg" });
            Photos.Add(new Image() { Source = "Chaynik_elektricheskiy.jpg" });
            Photos.Add(new Image() { Source = "Chaynik.jpg" });
            BindingContext = this;
        }
        private void imageList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedImage = (Image)e.SelectedItem;
        }
        private async void OpenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImagePage(SelectedImage));
        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var path = SelectedImage.Source.ToString().Replace("File: ", "");
            var fullPath = Path.Combine("/MobileGalleryApp", "MobileGalleryApp", "MobileGalleryApp.Android", "Resources", "drawable", path);
            try
            {

                DisplayAlert("Удаление!", fullPath, "Ok");
                File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка!", ex.Message, "Ok");
            }
        }
    }
}