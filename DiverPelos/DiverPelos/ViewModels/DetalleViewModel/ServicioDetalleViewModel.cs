using DiverPelos.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiverPelos.ViewModels.DetalleViewModel
{
    class ServicioDetalleViewModel : BaseViewModel
    {
        private string item;
        private string nombre;
        private string valor;
        private string duraccion;
        private string descripcion;

        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ServicioDetalleViewModel(string item)
        {
            _ = LoadPerson();
        }

        public string NombreTxt
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string ValorTxt
        {
            get { return this.valor; }
            set { SetValue(ref this.valor, value); }
        }

        public string DuraccionTxt
        {
            get { return this.duraccion; }
            set { SetValue(ref this.duraccion, value); }
        }

        public string DescripcionTxt
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
        }


        public async Task LoadPerson()
        {
            List<Models.Servicio> Servicio = await firebaseHelper.GetAllServicio();

            for (int i = 0; i < Servicio.Count; i++)
            {

                if (i == Convert.ToInt32(item))
                {
                    NombreTxt = Servicio[i].Nombre;
                    ValorTxt = Servicio[i].Valor;
                    DuraccionTxt = Servicio[i].Duraccion;
                    DescripcionTxt = Servicio[i].Descripcion;
                }


            }

        }
    }
}
