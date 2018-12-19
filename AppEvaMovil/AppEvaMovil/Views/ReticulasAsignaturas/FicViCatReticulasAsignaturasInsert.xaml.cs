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
	public partial class FicViCatReticulasAsignaturasInsert : ContentPage
	{
        private object FicLoParameter;
        public FicViCatReticulasAsignaturasInsert()
        {
            InitializeComponent();
            FicLoParameter = null;
            BindingContext = App.FicMetLocator.FicVmCatReticulasAsignaturasAdd;
        }

        public FicViCatReticulasAsignaturasInsert(object FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatReticulasAsignaturasAdd;
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturasAdd;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAsignaturasAdd;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}