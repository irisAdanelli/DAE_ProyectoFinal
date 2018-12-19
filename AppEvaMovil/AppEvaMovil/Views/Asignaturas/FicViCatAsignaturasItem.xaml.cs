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
using AppEvaMovil.ViewModels.Asignaturas;

namespace AppEvaMovil.Views.Asignaturas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatAsignaturasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        FicSrvCatAsignaturas service { get; set; }

        public FicViCatAsignaturasItem(object FicParameter)
        {
            InitializeComponent();
            service = new FicSrvCatAsignaturas();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturasDetail;
        }

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatAsignaturasDetail;
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveAsignaturas(context.Asignatura);
                context.BackNavgExecute();
            }
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasDetail;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasDetail;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}