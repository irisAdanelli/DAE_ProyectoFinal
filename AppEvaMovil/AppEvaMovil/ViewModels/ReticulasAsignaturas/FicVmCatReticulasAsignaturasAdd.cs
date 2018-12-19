using AppEvaMovil.Data;
using AppEvaMovil.Services.Navigation;
using AppEvaMovil.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces;
using AppEvaMovil.Services;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.ReticulasAsignaturas
{
    public  class FicVmCatReticulasAsignaturasAdd : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulasAsignaturas FicLoSrvApp;//INTERFAZ CRUD

        private eva_reticulas_asignaturas _ReticulasAsignaturas;
        public eva_reticulas_asignaturas ReticulasAsignaturas
        {
            get { return _ReticulasAsignaturas; }
            set
            {
                _ReticulasAsignaturas = value;
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

        private ICommand AddReticulasAsignaturas;
        public ICommand FicMetAddCommand
        {
            get { return AddReticulasAsignaturas = AddReticulasAsignaturas ?? new FicVmDelegateCommand(AddReticulasAsignaturasExecute); }
        }
        private async void AddReticulasAsignaturasExecute()
        {
            ReticulasAsignaturas.UsuarioMod = ReticulasAsignaturas.UsuarioReg;
            await FicLoSrvApp.FicMetInsertReticulasAsignaturas(ReticulasAsignaturas);
            //validar entradas
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturas>(null);
            await Application.Current.MainPage.DisplayAlert("Se Agrego Con Exito", "Para continuar da clic en ok", "OK");
            ReticulasAsignaturas = new eva_reticulas_asignaturas();
        }

        public FicVmCatReticulasAsignaturasAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulasAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _ReticulasAsignaturas = new eva_reticulas_asignaturas();
        }

    }
}
