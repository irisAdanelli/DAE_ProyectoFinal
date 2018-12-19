using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaMovil.Views.Navegacion;
using AppEvaMovil.Views.Reticulas;
using AppEvaMovil.Views.AsignaturaAnterior;
using AppEvaMovil.Views.Asignaturas;
using AppEvaMovil.Views.ReticulasAsignaturas;

namespace AppEvaMovil.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPage : MasterDetailPage
    {
        public FicMasterPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var FicItemMenu = e.SelectedItem as FicMasterPageMenuItem;
                if (FicItemMenu == null)
                    return;

                var FicPagina = FicItemMenu.FicPageName as string;
                switch (FicPagina)
                {
                    case "FicViCatReticulasList":
                        FicItemMenu.TargetType = typeof(FicViCatReticulasList);
                        break;
                    case "FicViCatAsignaturasList":
                        FicItemMenu.TargetType = typeof(FicViCatAsignaturasList);
                        break;
                    case "FicViCatReticulasAsignaturasList":
                        FicItemMenu.TargetType = typeof(FicViCatReticulasAsignaturasList);
                        break;
                    case "FicViCatAsignaturaAnteriorList":
                        FicItemMenu.TargetType = typeof(FicViCatAsignaturaAnteriorList);
                        break;
                    //case "FicViImportarWebApi":
                    //    FicItemMenu.TargetType = typeof(FicViImportarWebApi);
                    //    break;
                    //case "FicViExportarWebApi":
                    //    FicItemMenu.TargetType = typeof(FicViExportarWebApi);
                    //    break;

                    default:
                        break;
                }

                object[] FicObjeto = new object[1];
                //FIC: Sin enviar parametro
                var FicPageOpen = (Page)Activator.CreateInstance(FicItemMenu.TargetType);
                //var FicPageOpen = Activator.CreateInstance(typeof(FicViInventarioList)) as Page;

                //FIC: Enviando como parametro un objeto vacio
                FicPageOpen.Title = FicItemMenu.Title;

                Detail = new NavigationPage(FicPageOpen);
                IsPresented = false;
                MasterPage.ListView.SelectedItem = null;
            }
            catch (Exception ex)
            {
                new Page().DisplayAlert("ERROR", ex.Message.ToString(), "OK");
            }

        }
    }
}