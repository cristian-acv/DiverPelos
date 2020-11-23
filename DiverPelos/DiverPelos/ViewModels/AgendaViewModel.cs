using DiverPelos.Views.ViewsHome;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    class AgendaViewModel : BaseViewModel
    {
        public ICommand RegistroTurnoCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }

        private async void Registro()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroTurnoPage());
        }
    }
}
