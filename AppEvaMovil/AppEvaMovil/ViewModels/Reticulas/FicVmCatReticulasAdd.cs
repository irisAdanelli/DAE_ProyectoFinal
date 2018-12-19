using AppEvaMovil.Data;
using AppEvaMovil.Interfaces;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels.Reticulas;
using System; 
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.Reticulas
{
    public class FicVmCatReticulasAdd : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulas FicLoSrvApp;//INTERFAZ CRUD

        private eva_cat_reticulas _Reticulas;
        public eva_cat_reticulas Reticulas
        {
            get { return _Reticulas; }
            set
            {
                _Reticulas = value;
                RaisePropertyChanged();
            }
        }

        private ICommand BackNavigation;
        public ICommand BackNavgCommand
        {
            get { return BackNavigation = BackNavigation ?? new FicVmDelegateCommand(BackNavgExecute); }
        }
        private void BackNavgExecute()
        {
            FicLoSrvNavigation.FicMetNavigateBack();
        }
        //FicMetAddCommand
        private ICommand AddReticula;
        public ICommand FicMetAddCommand
        {
            get { return AddReticula = AddReticula ?? new FicVmDelegateCommand(AddReticulaExecute); }
        }
        private async void AddReticulaExecute()
        {
            Reticulas.UsuarioMod = Reticulas.UsuarioReg;
            await FicLoSrvApp.FicMetInsertReticula(Reticulas);
            //validar entradas
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulas>(null);
            await Application.Current.MainPage.DisplayAlert("Se Agrego Con Exito", "Para continuar da clic en ok", "OK");
            Reticulas = new eva_cat_reticulas();
        }

        public FicVmCatReticulasAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _Reticulas = new eva_cat_reticulas();
        }

    }
}
