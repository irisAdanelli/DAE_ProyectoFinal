using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using AppEvaMovil.Interfaces.SQLite;
using AppEvaMovil.Models;
using AppEvaMovil.Services;
using AppEvaMovil.Data;
using AppEvaMovil.ViewModels.Asignaturas;

namespace AppEvaMovil.Views.Asignaturas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatAsignaturasList : ContentPage
    {
        public FicViCatAsignaturasList()
        {
            InitializeComponent();
             BindingContext = App.FicMetLocator.FicVmCatAsignaturas;
            this.FicParameter = null;
            service = new FicSrvCatAsignaturas();
        }

        //private readonly FicDBContext FicLoBDContext;
        private object FicParameter { get; set; }
        FicSrvCatAsignaturas service { get; set; }


        public FicViCatAsignaturasList(object ficParameter)
        {
            InitializeComponent();
             BindingContext = App.FicMetLocator.FicVmCatAsignaturas;
            this.FicParameter = ficParameter;
            service = new FicSrvCatAsignaturas();
        }

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            
            var context = BindingContext as FicVmCatAsignaturas;
            if (context.SfDataGrid_SelectItem_Asignatura == null)
            {
                return;
            }
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveAsignaturas(context.SfDataGrid_SelectItem_Asignatura);
                context.SfDataGrid_ItemSource_Asignaturas.Remove(context.SfDataGrid_SelectItem_Asignatura);
            }
            dataGrid.View.Refresh();
        }

        protected async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            var source = BindingContext as FicVmCatAsignaturas;
            if (filtro == null || source.SfDataGrid_ItemSource_Asignaturas == null)
            {
                return;
            }
            filtro = filtro.ToLower();
            var resultAsignatura = await service.FicMetGetListAsignaturas();
            source.SfDataGrid_ItemSource_Asignaturas.Clear();
            foreach (var Asignatura in resultAsignatura)
            {
                if ((Asignatura.IdAsignatura + "").ToLower().Contains(filtro) || (Asignatura.DesAsignatura + "").ToLower().Contains(filtro) ||
                    (Asignatura.Matricula + "").ToLower().Contains(filtro) || (Asignatura.NombreCorto + "").ToLower().Contains(filtro))
                {
                    source.SfDataGrid_ItemSource_Asignaturas.Add(Asignatura);
                }
            }
            dataGrid.View.Refresh();
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturas;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturas;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}