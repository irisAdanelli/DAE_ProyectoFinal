using AppEvaMovil.Views.Reticulas;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
//using AppEvaMovil.Views.WebApi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEvaMovil.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public FicMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new FicMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMasterPageMenuItem> MenuItems { get; }

            public FicMasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<FicMasterPageMenuItem>(new[]
                {
                    new FicMasterPageMenuItem { Id = 0, FicPageName = "FicViCatReticulasList", Title = "Lista de Reticulas"},
                    new FicMasterPageMenuItem { Id = 1, FicPageName="FicViCatAsignaturasList" , Title = "Lista de Asignaturas" },
                    //new FicMasterPageMenuItem { Id = 0, Title = "Importacion Web Api",
                    //                            Icon ="ficAlmacen20x20.png",
                    //                            FicPageName ="FicViImportarWebApi",
                    //                            TargetType = typeof(FicViImportarWebApi)
                    //                            },
                    //new FicMasterPageMenuItem { Id = 0, Title = "Exportar Web Api",
                    //                            Icon ="ficAlmacen20x20.png",
                    //                            FicPageName ="FicViExportarWebApi",
                    //                            TargetType = typeof(FicViExportarWebApi)
                    //                            }

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