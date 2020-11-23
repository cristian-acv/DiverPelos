using DiverPelos.ViewModels;
using Xamarin.Forms;

namespace DiverPelos.Views.ViewsHome
{

    public partial class RegistarServicioPage : ContentPage
    {
        public RegistarServicioPage()
        {
            InitializeComponent();
            BindingContext = new RegistarServicioViewModel();
        }
    }
}