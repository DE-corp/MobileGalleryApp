using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGalleryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Image image;
        public ImagePage(Image selectedImage)
        {
            InitializeComponent();
            image = selectedImage;
            Photo.Source = image.Source;
            Name.Text = image.Source.ToString();
        }
    }
}