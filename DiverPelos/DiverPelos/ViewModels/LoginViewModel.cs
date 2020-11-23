using DiverPelos.Data;
using DiverPelos.Views.MasterDetail;
using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string email;
        private string password;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        #endregion

        #region Commads
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand RecordarCommand
        {
            get
            {
                return new RelayCommand(ResetPasswordEmail);
            }
        }

        #endregion

        #region Methods
        public async void Login()
        {
            FirebaseHelper firebaseHelper = new FirebaseHelper();

            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password.",
                    "Accept");
                return;
            }



            string WebAPIkey = "AIzaSyBBHGucGmH1SDw36s7qYVvu_58v2NFbqt0";

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(EmailTxt.ToString(), PasswordTxt.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);

                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new MyMasterDetailPage());




            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
            /*
            if (EmailTxt.ToString()=="cristian@gmail.com" && PasswordTxt.ToString() == "12345")
            {
                Application.Current.MainPage.DisplayAlert("Correto", "Logrado", "ok");
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Incorrecto", "No fue log", "ok");
            }
            

            List<User> e = App.Database.GetUsersValidate(email, password).Result;

            if (e.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Error",
                  "Email or Password Incorrect.",
                  "Accept");
            }
            else if (e.Count > 0)
            {
        
                await Application.Current.MainPage.Navigation.PushAsync(new AgendaPage());
                
            }
            */


        }

        public async void ResetPasswordEmail()
        {
            string WebAPIkey = "AIzaSyBBHGucGmH1SDw36s7qYVvu_58v2NFbqt0";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                await authProvider.SendPasswordResetEmailAsync(email);
                await App.Current.MainPage.DisplayAlert("Alerta", "Contraseña enviada al correo", "OK");

            }
            catch (Exception ex)
            {

            }
            #endregion

            #region Constructor
            #endregion
        }
    }
}
