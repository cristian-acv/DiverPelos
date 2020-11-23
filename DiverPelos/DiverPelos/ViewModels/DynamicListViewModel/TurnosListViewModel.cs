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
    class TurnosListViewModel : BaseViewModel
    {
        private bool isLoading;

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        private List<Turno> turno;

        public List<Turno> Turno
        {
            get { return turno; }
            set { turno = value; OnPropertyChanged(); }
        }


        public async Task LoadPerson()
        {

            IsLoading = true;

            Turno = await firebaseHelper.GetAllTurno();

            IsLoading = false;
        }

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
