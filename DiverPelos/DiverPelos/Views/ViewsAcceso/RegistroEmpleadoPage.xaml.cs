using DiverPelos.ViewModels;

using Xamarin.Forms;

namespace DiverPelos.Views.ViewsAcceso
{
    public partial class RegistroEmpleadoPage : ContentPage
    {
        public RegistroEmpleadoPage()
        {
            InitializeComponent();
            BindingContext = new RegistroEmpleadoViewModel();
        }
    }
}