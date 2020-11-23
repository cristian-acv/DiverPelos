using DiverPelos.ViewModels.DynamicListViewModel;
using DiverPelos.Views.Detalle;
using System;
using Xamarin.Forms;

namespace DiverPelos.Views.DynamicListView
{

    public partial class ClientesListViewPage : ContentPage
    {
        ClientesListViewModel vm;
        public ClientesListViewPage()
        {
            InitializeComponent();
            vm = new ClientesListViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadPerson();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            string item = e.ItemIndex.ToString();
            await Navigation.PushAsync(new ClienteDetallePage(item));

        }

    }
}