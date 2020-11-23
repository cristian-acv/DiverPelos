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
    class ClientesListViewModel : BaseViewModel
    {
        private bool isLoading;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        private List<Cliente> cliente;

        public List<Cliente> Cliente
        {
            get { return cliente; }
            set { cliente = value; OnPropertyChanged(); }
        }


        public async Task LoadPerson()
        {

            IsLoading = true;

            Cliente = await firebaseHelper.GetClienteModel();

            IsLoading = false;
        }

        public ICommand RegistroClienteCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }

        private async void Registro()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroClientePage());
        }
    }
}
