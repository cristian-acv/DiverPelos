using DiverPelos.ViewModels.DetalleViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiverPelos.Views.Detalle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TurnoDetallePage : ContentPage
    {
        public TurnoDetallePage(string item)
        {
            InitializeComponent();
            BindingContext = new TurnoDetalleViewModel(item);
        }
    }
}