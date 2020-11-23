using DiverPelos.Data;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    class RegistroClienteViewModel : BaseViewModel
    {
        #region Attributes
        private string cedula;
        private string nombre;
        private string telefono;
        private string direcccion;
        private string email;
        #endregion

        #region Properties

        public string CedulaTxt
        {
            get { return this.cedula; }
            set { SetValue(ref this.cedula, value); }
        }
        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string TelefonoTxt
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }
        public string DireccionTxt
        {
            get { return this.direcccion; }
            set { SetValue(ref this.direcccion, value); }
        }
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        #endregion

        #region Commads
        public ICommand RegistroClienteCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }

        #endregion

        #region Methods
        private async void Registro()
        {
            FirebaseHelper firebaseHelper = new FirebaseHelper();

            if (string.IsNullOrEmpty(this.CedulaTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese la Cedula",
                     "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.NombreTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el nombre",
                     "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.TelefonoTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el telefono",
                     "Aceptar"
                    );
                return;
            }
            if (string.IsNullOrEmpty(this.EmailTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el email",
                     "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.DireccionTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el contraseña",
                     "Aceptar"
                    );
                return;
            }

            await firebaseHelper.AddCliente(cedula, nombre, telefono, direcccion,
                email, DateTime.UtcNow.Date);
            await Application.Current.MainPage.DisplayAlert("Exitoso", "Cliente Registrado " + NombreTxt, "OK");

            CedulaTxt = "";
            NombreTxt = "";
            TelefonoTxt = "";
            DireccionTxt = "";
            EmailTxt = "";


            #endregion

            #region Constructor
            #endregion
        }
    }

}