using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppEvaMovil.Interfaces.SQLite;
using AppEvaMovil.Models;
using AppEvaMovil.Services;
using AppEvaMovil.Data;
using AppEvaMovil.ViewModels.ReticulasAsignaturas;
using System.Windows.Input;
using AppEvaMovil.ViewModels.Reticulas;

namespace AppEvaMovil.Views.ReticulasAsignaturas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatReticulasAsignaturasList : ContentPage
	{

        public FicViCatReticulasAsignaturasList()
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCatReticulasAsignaturas;
            this.FicParameter = null;
            service = new FicSrvReticulasAsignaturas();
        }


        //private readonly FicDBContext FicLoBDContext;
        private object FicParameter { get; set; }
        FicSrvReticulasAsignaturas service { get; set; }


        public FicViCatReticulasAsignaturasList(object ficParameter)
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCatReticulasAsignaturas;
            this.FicParameter = ficParameter;
            service = new FicSrvReticulasAsignaturas();
        }

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatReticulasAsignaturas;
            if (context.SfDataGrid_SelectItem_ReticulasAsignaturas == null)
            {
                return;
            }
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            { /*aqui es*/
                await service.FicMetRemoveReticulasAsignaturas(context.SfDataGrid_SelectItem_ReticulasAsignaturas);
                context.SfDataGrid_ItemSource_ReticulasAsignaturas.Remove(context.SfDataGrid_SelectItem_ReticulasAsignaturas);
            }
            dataGrid.View.Refresh();
        }

        protected async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            var source = BindingContext as FicVmCatReticulasAsignaturas;
            if (filtro == null || source.SfDataGrid_ItemSource_ReticulasAsignaturas == null)
            {
                return;
            }
            filtro = filtro.ToLower();
            var resultReticulasAsignaturas = await service.FicMetGetListReticulasAsignaturas();
            source.SfDataGrid_ItemSource_ReticulasAsignaturas.Clear();
            foreach (var ReticulasAsignaturas in resultReticulasAsignaturas)
            {
                if ((ReticulasAsignaturas.IdReticula + "").ToLower().Contains(filtro) || (ReticulasAsignaturas.OrderCertificado + "").ToLower().Contains(filtro) ||
                    (ReticulasAsignaturas.Semestre + "").ToLower().Contains(filtro) || (ReticulasAsignaturas.UsuarioMod + "").ToLower().Contains(filtro))
                {
                    source.SfDataGrid_ItemSource_ReticulasAsignaturas.Add(ReticulasAsignaturas);
                }
            }
            dataGrid.View.Refresh();
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturas;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturas;
            if (viewModel != null) viewModel.OnDisappearing();
        }

        


        //FicMetAddCommand


        //FicMetEditCommand



    }
}