using DiverPelos.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiverPelos.ViewModels.DetalleViewModel
{
    class TurnoDetalleViewModel : BaseViewModel
    {
        private string item;
        private string cliente;
        private string servicio;
        private string fecha;
        private string hora;

        FirebaseHelper firebaseHelper = new FirebaseHelper();


        public TurnoDetalleViewModel(string item)
        {
            this.item = item;
            _ = LoadPerson();

        }

        public string ClienteTxt
        {
            get { return this.cliente; }
            set { SetValue(ref this.cliente, value); }
        }

        public string ServicioTxt
        {
            get { return this.servicio; }
            set { SetValue(ref this.servicio, value); }
        }

        public string FechaTxt
        {
            get { return this.fecha; }
            set { SetValue(ref this.fecha, value); }
        }

        public string HoraTxt
        {
            get { return this.hora; }
            set { SetValue(ref this.hora, value); }
        }


        public async Task LoadPerson()
        {
            List<Models.Turno> Turno = await firebaseHelper.GetAllTurno();

            for (int i = 0; i < Turno.Count; i++)
            {

                if (i == Convert.ToInt32(item))
                {
                    ClienteTxt = Turno[i].Cliente;
                    ServicioTxt = Turno[i].Servicio;
                    FechaTxt = Turno[i].Fecha.ToString();
                    HoraTxt = Turno[i].Hora.ToString();
                }


            }

        }
    }
}
