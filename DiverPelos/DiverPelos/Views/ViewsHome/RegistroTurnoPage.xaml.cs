using DiverPelos.ViewModels;
using Xamarin.Forms;

namespace DiverPelos.Views.ViewsHome
{
    public partial class RegistroTurnoPage : ContentPage
    {
        RegistroTurnoViewModel vm;
        public RegistroTurnoPage()
        {
            InitializeComponent();
            vm = new RegistroTurnoViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadPerson();
        }
    }
}