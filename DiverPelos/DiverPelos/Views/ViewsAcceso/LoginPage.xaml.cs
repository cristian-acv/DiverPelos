using DiverPelos.ViewModels;
using Xamarin.Forms;

namespace DiverPelos.Views.ViewsAcceso
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}