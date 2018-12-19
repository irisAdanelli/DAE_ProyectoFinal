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
using AppEvaMovil.ViewModels;
using AppEvaMovil.Models;
using AppEvaMovil.Services;
using AppEvaMovil.Data;
using AppEvaMovil.ViewModels.AsignaturaAnterior;

namespace AppEvaMovil.Views.AsignaturaAnterior
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatAsignaturaAnteriorList : ContentPage
    {
		public FicViCatAsignaturaAnteriorList ()
		{
			InitializeComponent ();
            BindingContext = App.FicMetLocator.FicVmCatAsignaturaAnterior;
            this.FicParameter = null;
            service = new FicSrvAsignaturaAnterior();
        }
        

        //private readonly FicDBContext FicLoBDContext;
        private object FicParameter { get; set; }
        FicSrvAsignaturaAnterior service { get; set; }

        
        public FicViCatAsignaturaAnteriorList(object ficParameter)
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCatAsignaturaAnterior;
            this.FicParameter = ficParameter;
            service = new FicSrvAsignaturaAnterior();
        }

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatAsignaturaAnterior;
            if (context.SfDataGrid_SelectItem_AsignaturaAnterior == null)
            {
                return;
            }
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveAsignaturaAnterior(context.SfDataGrid_SelectItem_AsignaturaAnterior);
                context.SfDataGrid_ItemSource_AsignaturaAnterior.Remove(context.SfDataGrid_SelectItem_AsignaturaAnterior);
            }
            dataGrid.View.Refresh();
        }

        protected async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            var source = BindingContext as FicVmCatAsignaturaAnterior;
            if (filtro == null || source.SfDataGrid_ItemSource_AsignaturaAnterior == null)
            {
                return;
            }
            filtro = filtro.ToLower();
            var resultAsignaturaAnterior = await service.FicMetGetListAsignaturaAnterior();
            source.SfDataGrid_ItemSource_AsignaturaAnterior.Clear();
            foreach (var AsignaturaAnterior in resultAsignaturaAnterior)
            {
                if ((AsignaturaAnterior.IdAsignaturaAnterior + "").ToLower().Contains(filtro) || (AsignaturaAnterior.IdReticula + "").ToLower().Contains(filtro) ||
                    (AsignaturaAnterior.IdAsignatura + "").ToLower().Contains(filtro) || (AsignaturaAnterior.UsuarioMod + "").ToLower().Contains(filtro))
                {
                    source.SfDataGrid_ItemSource_AsignaturaAnterior.Add(AsignaturaAnterior);
                }
            }
            dataGrid.View.Refresh();
        }
        

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnterior;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnterior;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}