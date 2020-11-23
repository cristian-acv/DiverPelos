using DiverPelos.Data;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiverPelos.ViewModels
{
    class ClienteViewModels : BaseViewModel
    {
        #region Attributes
        private string nombre;
        private string apellido;
        private string telefono;
        private string direcccion;
        private string email;
        public bool isRefreshing = false;
        public object listViewSource;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        #endregion

        #region Properties
        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string ApellidoTxt
        {
            get { return this.apellido; }
            set { SetValue(ref this.apellido, value); }
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

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public object ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        #endregion

        #region Commands
        public ICommand InsertCommand
        {
            get
            {
                return new RelayCommand(InsertMethod);
            }
        }
        #endregion

        #region Methods
        private async void InsertMethod()
        {

            await firebaseHelper.AddCliente(nombre, apellido, telefono, direcccion,
              email, DateTime.UtcNow.Date);

            this.IsRefreshing = true;

            await Task.Delay(1000);

            LoadData();

            this.IsRefreshing = false;
        }

        public async Task LoadData()
        {


            this.ListViewSource = await firebaseHelper.GetClienteModel();

        }

        #endregion


        #region Constructor
        public ClienteViewModels()
        {
            LoadData();
        }
        #endregion
    }
}
