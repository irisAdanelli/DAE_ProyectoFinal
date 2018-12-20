using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Data.Common; 
using AppEvaMovil.Interfaces.SQLite;
using AppEvaMovil.Models;
using AppEvaMovil.Services;
using AppEvaMovil.Data;
using AppEvaMovil.ViewModels.Reticulas;
using Syncfusion.XForms.ComboBox;

namespace AppEvaMovil.Views.Reticulas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatReticulasInsert : ContentPage
    //FicMetAddCommand
    {
        private object FicLoParameter;
        public FicViCatReticulasInsert()
        {
            InitializeComponent();
            FicLoParameter = null;
            BindingContext = App.FicMetLocator.FicVmCatReticulasAdd;
        }

        public FicViCatReticulasInsert(object FicParameter)
        {
            InitializeComponent();
            FicLoParameter = FicParameter;
            BindingContext = App.FicMetLocator.FicVmCatReticulasAdd;
        }

        //public void Handle_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        //{
        //    (BindingContext as FicVmCatReticulasAdd).Reticulas.Clave = Int16.Parse(e.Value.ToString());
        //}

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAdd;
            if (viewModel != null)
            {
                viewModel.OnAppearing(FicLoParameter);
            }

        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulasAdd;
            if (viewModel != null) viewModel.OnDisappearing();
        }

       
    }
}




