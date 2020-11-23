using DiverPelos.Views.DynamicListView;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DiverPelos.Views.MasterDetail
{
    public partial class MyMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MyMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyMasterDetailPageMasterMenuItem> MenuItems { get; set; }

            public MyMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyMasterDetailPageMasterMenuItem>(new[]
                {
                     new MyMasterDetailPageMasterMenuItem { Id = 0, Title = "Agenda" ,TargetType = typeof(MyMasterDetailPageDetail), Icon="agenda.png" },
                    new MyMasterDetailPageMasterMenuItem { Id = 0, Title = "Clientes" ,TargetType = typeof(ClientesListViewPage), Icon="cliente2.png" },
                    new MyMasterDetailPageMasterMenuItem { Id = 0, Title = "Servicios" ,TargetType = typeof(ServiciosListViewPage), Icon="servicio.png" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}