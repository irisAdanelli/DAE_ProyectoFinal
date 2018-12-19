using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaMovil.ViewModels.AsignaturaAnterior;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces;
using AppEvaMovil.Services;

namespace AppEvaMovil.Views.AsignaturaAnterior
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatAsignaturaAnteriorItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        FicSrvAsignaturaAnterior service { get; set; }

        public FicViCatAsignaturaAnteriorItem(object FicParameter)
        {
            InitializeComponent();
            service = new FicSrvAsignaturaAnterior();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturaAnteriorDetail;
        }


        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatAsignaturaAnteriorDetail;
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveAsignaturaAnterior(context.AsignaturaAnterior);
                context.BackNavgExecute();
            }
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnteriorDetail;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnteriorDetail;
            if (viewModel != null) viewModel.OnDisappearing();
        }

    }
}