using DiverPelos.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiverPelos.ViewModels.DetalleViewModel
{
    class ClienteDetalleViewModel : BaseViewModel
    {
        #region Attributes
        private string item;
        private string nombre;
        private string cedula;
        private string telefono;
        private string dirrecion;
        private string email;

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        #endregion

        #region Properties
        public ClienteDetalleViewModel(string item)
        {
            _ = LoadCliente();
        }

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

        public string DireccionTxt
        {
            get { return this.dirrecion; }
            set { SetValue(ref this.dirrecion, value); }
        }

        public string EmailTxt
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        #endregion
        #region Commads
        #endregion

        #region Methods
        public async Task LoadCliente()
        {
            List<Models.Cliente> Cliente = await firebaseHelper.GetClienteModel();

            for (int i = 0; i < Cliente.Count; i++)
            {

                if (i == Convert.ToInt32(item))
                {
                    NombreTxt = Cliente[i].Nombre;
                    CedulaTxt = Cliente[i].Id;
                    TelefonoTxt = Cliente[i].Telefono;
                    EmailTxt = Cliente[i].Email;
                    DireccionTxt = Cliente[i].Direccion;
                }


            }

        }
        #endregion
    }
}
