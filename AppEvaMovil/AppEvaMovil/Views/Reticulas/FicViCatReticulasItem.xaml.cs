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
using AppEvaMovil.ViewModels.Reticulas;

namespace AppEvaMovil.Views.Reticulas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatReticulasItem : ContentPage
	{
        private object FicLoParameter { get; set; }
        FicSrvCatReticulas service { get; set; }

        public FicViCatReticulasItem(object FicParameter)
        {
            InitializeComponent();
            service = new FicSrvCatReticulas();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatReticulasDetail;
        }


        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatReticulasDetail;
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveReticula(context.Reticulas);
                context.BackNavgExecute();
            }
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasDetail;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasDetail;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}