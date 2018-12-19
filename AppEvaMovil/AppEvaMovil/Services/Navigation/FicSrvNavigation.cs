using System;
using System.Collections.Generic;
using System.Text;
using AppEvaMovil.Interfaces.Navigation;
using Xamarin.Forms;
using AppEvaMovil.ViewModels;
using AppEvaMovil.Views;

using AppEvaMovil.ViewModels.AsignaturaAnterior;
using AppEvaMovil.Views.AsignaturaAnterior;

using AppEvaMovil.ViewModels.Asignaturas;
using AppEvaMovil.Views.Asignaturas;

using AppEvaMovil.ViewModels.Reticulas;
using AppEvaMovil.Views.Reticulas;

using AppEvaMovil.ViewModels.ReticulasAsignaturas;
using AppEvaMovil.Views.ReticulasAsignaturas;


//Por cada vista se tiene view, view model, services, navegation 
namespace AppEvaMovil.Services.Navigation
{
    public class FicSrvNavigation : IFicSrvNavigation
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            // Registrar la relación ViewModel - Vista en el siguiente formato para cada vista
            // { typeof(FicVmCatBeaconsList), typeof(FicViCpCatBeaconsList) },
            //por cada vista se realiza esta linea de codigo
            { typeof(FicVmCatAsignaturaAnterior), typeof(FicViCatAsignaturaAnteriorList) },
            { typeof(FicVmCatAsignaturaAnteriorAdd), typeof(FicViCatAsignaturaAnteriorInsert) }, //falta la viewmodel
            { typeof(FicVmCatAsignaturaAnteriorDetail), typeof(FicViCatAsignaturaAnteriorItem) },
            { typeof(FicVmCatAsignaturaAnteriorUpdate), typeof(FicViCatAsignaturaAnteriorUpdate) },

            { typeof(FicVmCatAsignaturas), typeof(FicViCatAsignaturasList) },
            { typeof(FicVmCatAsignaturasAdd), typeof(FicViCatAsignaturasInsert) }, //falta la viewmodel
            { typeof(FicVmCatAsignaturasDetail), typeof(FicViCatAsignaturasItem) },
            { typeof(FicVmCatAsignaturasUpdate), typeof(FicViCatAsignaturasUpdate) },

            { typeof(FicVmCatReticulas), typeof(FicViCatReticulasList) },
            { typeof(FicVmCatReticulasAdd), typeof(FicViCatReticulasInsert) }, //falta la viewmodel
            { typeof(FicVmCatReticulasDetail), typeof(FicViCatReticulasItem) },
            { typeof(FicVmCatReticulasUpdate), typeof(FicViCatReticulasUpdate) },

            { typeof(FicVmCatReticulasAsignaturas), typeof(FicViCatReticulasAsignaturasList) },
            { typeof(FicVmCatReticulasAsignaturasAdd), typeof(FicViCatReticulasAsignaturasInsert) }, //falta la viewmodel
            { typeof(FicVmCatReticulasAsignaturasDetail), typeof(FicViCatReticulasAsignaturasItem) },
            { typeof(FicVmCatReticulasAsignaturasUpdate), typeof(FicViCatReticulasAsignaturasUpdate) },


            { typeof(FicVmMenuPrincipal), typeof(FicMenuPrincipal)}
            //{ typeof (FicVmExportarWebApi), typeof(FicViExportarWebApi)},
            //{ typeof (FicVmImportarWebApi), typeof(FicViImportarWebApi)},
            
        };

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page); 
            /*if (page != null)
            {
                var m = Application.Current.MainPage as MasterDetailPage;
                m.Detail.Navigation.PushAsync(page);
            }*/

            //Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void FicMetNavigateTo<TDestinationViewModel>(object navigationContext = null, bool show = true)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext, show) as Page;
           
            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
            /*if (page != null)
            {
                var m = Application.Current.MainPage as MasterDetailPage;
                m.Detail.Navigation.PushAsync(page);
            }*/
        }

        public void FicMetNavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                 Application.Current.MainPage.Navigation.PushAsync(page);
            /*if (page != null)
            {
                var m = Application.Current.MainPage as MasterDetailPage;
                m.Detail.Navigation.PushAsync(page);
            }*/
        }

        public void FicMetNavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
            
                //var m = Application.Current.MainPage as MasterDetailPage;
                //m.Detail.Navigation.PopAsync();
            
        }
    }
}