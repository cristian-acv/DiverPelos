using DiverPelos.Data;
using DiverPelos.Models;
using DiverPelos.Views.ViewsHome;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels.DynamicListViewModel
{
    class ServiciosListViewModel : BaseViewModel
    {
        private bool isLoading;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        private List<Servicio> servicio;

        public List<Servicio> Servicio
        {
            get { return servicio; }
            set { servicio = value; OnPropertyChanged(); }
        }


        public async Task LoadPerson()
        {

            IsLoading = true;

            Servicio = await firebaseHelper.GetAllServicio();

            IsLoading = false;
        }

        public ICommand RegistroServicioCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }

        private async void Registro()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistarServicioPage());
        }

    }
}
