using System;
using Xamarin.Forms;

namespace DiverPelos.Views.ViewsAcceso
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void RegisterNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEmpleadoPage());
        }
        private void LoginNav_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new LoginPage());
        }
    }
}