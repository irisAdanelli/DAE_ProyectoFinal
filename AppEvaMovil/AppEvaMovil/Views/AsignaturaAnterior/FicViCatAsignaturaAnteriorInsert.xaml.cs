using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaMovil.ViewModels;
using AppEvaMovil.Models;
using AppEvaMovil.Services;
using AppEvaMovil.ViewModels.AsignaturaAnterior;

namespace AppEvaMovil.Views.AsignaturaAnterior
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatAsignaturaAnteriorInsert : ContentPage
	{
        private object FicLoParameter;
        public FicViCatAsignaturaAnteriorInsert()
        {
            InitializeComponent();
            FicLoParameter = null;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturaAnteriorAdd;
        }


        public FicViCatAsignaturaAnteriorInsert(object FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturaAnteriorAdd;
        }

        //public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        //{
        //    (BindingContext as FicVmCatAsignaturaAnteriorAdd).AsignaturaAnterior.Prioridad = Int16.Parse(e.Value.ToString());
        //}

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnteriorAdd;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturaAnteriorAdd;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}