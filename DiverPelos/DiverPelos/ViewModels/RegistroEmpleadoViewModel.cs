using DiverPelos.Data;
using DiverPelos.Views.ViewsAcceso;
using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    public class RegistroEmpleadoViewModel : BaseViewModel
    {
        #region Attributes
        private string nombre;
        private string cedula;
        private string telefono;
        private string email;
        private string contraseña;
        #endregion

        #region Properties
        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string CedulaTxt
        {
            get { return this.cedula; }
            set { SetValue(ref this.cedula, value); }
        }
        public string TelefonoTxt
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string ContraseñaTxt
        {
            get { return this.contraseña; }
            set { SetValue(ref this.contraseña, value); }
        }
        #endregion

        #region Commads
        public ICommand RegistroCommand
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

            if (string.IsNullOrEmpty(this.NombreTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el nombre",
                     "Aceptar"
                    );
                return;
            }
            if (string.IsNullOrEmpty(this.CedulaTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese la cedula",
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

            if (string.IsNullOrEmpty(this.ContraseñaTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el contraseña",
                     "Aceptar"
                    );
                return;
            }

            await firebaseHelper.AddEmpleado(cedula, nombre, telefono, email,
                 contraseña, DateTime.UtcNow.Date);
            await Application.Current.MainPage.DisplayAlert("Success", "Person Added Successfully", "OK");

            string WebAPIkey = "AIzaSyBBHGucGmH1SDw36s7qYVvu_58v2NFbqt0";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(EmailTxt.ToString(), ContraseñaTxt.ToString());
                string gettoken = auth.FirebaseToken;

                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

            #endregion

            #region Constructor
            #endregion
        }
    }
}
