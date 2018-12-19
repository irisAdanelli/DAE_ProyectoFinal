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
	public partial class FicViCatAsignaturasUpdate : ContentPage
	{
        private object FicLoParameter;
        public FicViCatAsignaturasUpdate(object FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            //Prior.Value = (FicParameter as eva_reticula_asignatura_ant).Prioridad;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturasUpdate;
        }

   
        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasUpdate;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasUpdate;
            if (viewModel != null)
            {
                viewModel.OnDisappearing();
            }
        }
    }
}