using DiverPelos.Data;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiverPelos.ViewModels
{
    class RegistarServicioViewModel : BaseViewModel
    {
        #region Attributes
        private string nombre;
        private string duraccion;
        private string descripccion;
        private string valor;
        #endregion

        #region Properties
        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string DuraccionTxt
        {
            get { return this.duraccion; }
            set { SetValue(ref this.duraccion, value); }
        }
        public string DescripcionTxt
        {
            get { return this.descripccion; }
            set { SetValue(ref this.descripccion, value); }
        }
        public string ValorTxt
        {
            get { return this.valor; }
            set { SetValue(ref this.valor, value); }
        }

        #endregion

        #region Commads
        public ICommand RegistroServicioCommand
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
            if (string.IsNullOrEmpty(this.DuraccionTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el Duraccion",
                     "Aceptar"
                    );
                return;
            }
            if (string.IsNullOrEmpty(this.DescripcionTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el Descripcion",
                     "Aceptar"
                    );
                return;
            }
            if (string.IsNullOrEmpty(this.ValorTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el email",
                     "Aceptar"
                    );
                return;
            }

            if (string.IsNullOrEmpty(this.ValorTxt))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                     "Ingrese el valor",
                     "Aceptar"
                    );
                return;
            }

            await firebaseHelper.AddServicio(nombre, duraccion, descripccion, valor);
            await Application.Current.MainPage.DisplayAlert("Exitoso", "Cliente Registrado", "OK");

            NombreTxt = "";
            DuraccionTxt = "";
            DescripcionTxt = "";
            ValorTxt = "";

            /*
            var cliente = new Cliente
            {
                
               
                Nombre = NombreTxt.ToLower(),
                Apellido = ApellidoTxt.ToLower(),
                Telefono = TelefonoTxt.ToLower(),
                Direccion = DireccionTxt.ToLower(),
                Email = EmailTxt.ToLower(),
                Creation_Date = DateTime.UtcNow.Date
            };

            await App.Database.SaveClienteAsync(cliente);
            await Application.Current.MainPage.DisplayAlert
                    ("Alerta",
                     "Registro Exitoso",
                     "Aceptar"
                   );
        }
            */
            #endregion

            #region Constructor
            #endregion
        }
    }
}
