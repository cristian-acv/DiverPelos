using DiverPelos.ViewModels.DynamicListViewModel;
using DiverPelos.Views.Detalle;
using System;
using Xamarin.Forms;

namespace DiverPelos.Views.MasterDetail
{

    public partial class MyMasterDetailPageDetail : ContentPage
    {
        TurnosListViewModel vm;
        public MyMasterDetailPageDetail()
        {
            InitializeComponent();
            vm = new TurnosListViewModel();
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
            await Navigation.PushAsync(new TurnoDetallePage(item));

        }
    }
}