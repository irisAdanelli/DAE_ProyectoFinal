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
	public partial class FicViCatAsignaturasInsert : ContentPage
	{
        private object FicLoParameter;
        public FicViCatAsignaturasInsert()
        {
            InitializeComponent();
            FicLoParameter = null;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturasAdd;
        }

        public FicViCatAsignaturasInsert(object FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatAsignaturasAdd;
        }

        //public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        //{
        //    (BindingContext as FicVmCatAsignaturaAdd).Asignatura.Prioridad = Int16.Parse(e.Value.ToString());
        //}

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasAdd;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatAsignaturasAdd;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}