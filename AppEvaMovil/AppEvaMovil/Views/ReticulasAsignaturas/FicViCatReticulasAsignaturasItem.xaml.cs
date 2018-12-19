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

namespace AppEvaMovil.Views.ReticulasAsignaturas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatReticulasAsignaturasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        FicSrvReticulasAsignaturas service { get; set; }

        public FicViCatReticulasAsignaturasItem(object FicParameter)
        {
            InitializeComponent();
            service = new FicSrvReticulasAsignaturas();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatReticulasAsignaturasDetail;
        }
        
        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatReticulasAsignaturasDetail;
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveReticulasAsignaturas(context.ReticulasAsignaturas);
                context.BackNavgExecute();
            }
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturasDetail;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturasDetail;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}