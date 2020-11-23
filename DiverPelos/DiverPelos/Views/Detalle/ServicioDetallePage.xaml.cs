using DiverPelos.ViewModels.DetalleViewModel;

using Xamarin.Forms;

namespace DiverPelos.Views.Detalle
{
    public partial class ServicioDetallePage : ContentPage
    {
        public ServicioDetallePage(string item)
        {
            InitializeComponent();
            BindingContext = new ServicioDetalleViewModel(item);
        }


    }
}