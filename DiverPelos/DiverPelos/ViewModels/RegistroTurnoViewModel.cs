using DiverPelos.Data;
using DiverPelos.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    public class RegistroTurnoViewModel : BaseViewModel
    {
        private bool isLoading;

        private DateTime fecha;
        private TimePicker hora = new TimePicker();

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public DateTime SelectedDate
        {
            get { return this.fecha; }
            set { SetValue(ref this.fecha, value); }
        }


        public TimePicker SelectedHour
        {
            get { return this.hora; }
            set { SetValue(ref this.hora, value); }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }
        private IList<Cliente> cliente;
        public IList<Cliente> Monkeys
        {
            get { return cliente; }
            set { cliente = value; OnPropertyChanged(); }
        }

        private IList<Servicio> servicio;
        public IList<Servicio> Servicios
        {
            get { return servicio; }
            set { servicio = value; OnPropertyChanged(); }
        }

        public async Task LoadPerson()
        {

            IsLoading = true;

            Monkeys = (IList<Cliente>)await firebaseHelper.GetClienteModel();
            Servicios = (IList<Servicio>)await firebaseHelper.GetAllServicio();

            IsLoading = false;
        }

        Cliente selectedMonkey;
        public Cliente SelectedMonkey
        {
            get { return selectedMonkey; }
            set
            {
                if (selectedMonkey != value)
                {
                    selectedMonkey = value;
                    OnPropertyChanged();
                }
            }
        }


        Servicio selectedServicio;
        public Servicio SelectedServicio
        {
            get { return selectedServicio; }
            set
            {
                if (selectedServicio != value)
                {
                    selectedServicio = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RegistroTurnoCommand
        {
            get
            {
                return new RelayCommand(Turno);
            }
        }

        private async void Turno()
        {
            await firebaseHelper.AddTurno(selectedMonkey.Nombre, selectedServicio.Nombre, fecha.Date, hora.Time,
                true);
            await Application.Current.MainPage.DisplayAlert("Exitoso", "Turno Agendado", "OK");

        }
    }
}
