using AppEvaMovil.Services;
using AppEvaMovil.ViewModels.Reticulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEvaMovil.Views.Reticulas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FicViCatReticulasList : ContentPage
	{
        public FicViCatReticulasList()
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCatReticulas;
            this.FicParameter = null;
            service = new FicSrvCatReticulas();
        }


        //private readonly FicDBContext FicLoBDContext;
        private object FicParameter { get; set; }
        FicSrvCatReticulas service { get; set; }


        public FicViCatReticulasList(object ficParameter)
        {
            InitializeComponent();
            BindingContext = App.FicMetLocator.FicVmCatReticulas;
            this.FicParameter = ficParameter;
            service = new FicSrvCatReticulas();
        }

        //Command="{Binding FicMetDeleteCommand}"
        protected async void FicMetDeleteCommand(object sender, EventArgs e)
        {
            var context = BindingContext as FicVmCatReticulas;
            if (context.SfDataGrid_SelectItem_Reticulas == null)
            {
                return;
            }
            bool conf = await new Page().DisplayAlert("Cuidado", "¿Desea eliminar este elemento?", "Sí", "No");
            if (conf)
            {
                await service.FicMetRemoveReticula(context.SfDataGrid_SelectItem_Reticulas);
                context.SfDataGrid_ItemSource_Reticulas.Remove(context.SfDataGrid_SelectItem_Reticulas);
            }
            dataGrid.View.Refresh();
        }

        protected async void FicSearchButtonPressed(object sender, EventArgs e)
        {
            string filtro = FicSearchBar.Text;
            var source = BindingContext as FicVmCatReticulas;
            if (filtro == null || source.SfDataGrid_ItemSource_Reticulas == null)
            {
                return;
            }
            filtro = filtro.ToLower();
            var resultReticulas = await service.FicMetGetListReticulas();
            source.SfDataGrid_ItemSource_Reticulas.Clear();
            foreach (var Reticulas in resultReticulas)
            {
                if ((Reticulas.IdReticula + "").ToLower().Contains(filtro) || (Reticulas.DesReticula + "").ToLower().Contains(filtro) ||
                    (Reticulas.Clave + "").ToLower().Contains(filtro) || (Reticulas.UsuarioMod + "").ToLower().Contains(filtro))
                {
                    source.SfDataGrid_ItemSource_Reticulas.Add(Reticulas);
                }
            }
            dataGrid.View.Refresh();
        }


        protected override void OnAppearing()
        {
            var viewModel = BindingContext as FicVmCatReticulas;
            if (viewModel != null) viewModel.OnAppearing(FicParameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as FicVmCatReticulas;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}