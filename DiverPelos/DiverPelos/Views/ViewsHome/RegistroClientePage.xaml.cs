using DiverPelos.ViewModels;
using Xamarin.Forms;

namespace DiverPelos.Views.ViewsHome
{

    public partial class RegistroClientePage : ContentPage
    {
        public RegistroClientePage()
        {
            InitializeComponent();
            BindingContext = new RegistroClienteViewModel();
        }
    }
}