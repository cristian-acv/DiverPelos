using DiverPelos.ViewModels.DetalleViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiverPelos.Views.Detalle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClienteDetallePage : ContentPage
    {
        public ClienteDetallePage(string item)
        {
            InitializeComponent();
            InitializeComponent();
            BindingContext = new ClienteDetalleViewModel(item);
        }
    }
}