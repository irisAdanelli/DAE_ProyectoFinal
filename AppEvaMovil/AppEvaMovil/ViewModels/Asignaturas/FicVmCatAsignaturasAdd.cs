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
using AppEvaMovil;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.Asignaturas
{
    public  class FicVmCatAsignaturasAdd : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatAsignaturas FicLoSrvApp;//INTERFAZ CRUD

        private eva_cat_asignaturas _Asignaturas;
        public eva_cat_asignaturas Asignatura
        {
            get { return _Asignaturas; }
            set
            {
                _Asignaturas = value;
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

        private ICommand AddAsignatura;
        public ICommand FicMetAddCommand
        {
            get { return AddAsignatura = AddAsignatura ?? new FicVmDelegateCommand(AddAsignaturaExecute); }
        }
        private async void AddAsignaturaExecute()
        {
            Asignatura.UsuarioMod = Asignatura.UsuarioReg;
            await FicLoSrvApp.FicMetInsertAsignaturas(Asignatura);
            //validar entradas
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturas>(null);
            await Application.Current.MainPage.DisplayAlert("Se Agrego Con Exito", "Para continuar da clic en ok", "OK");
            Asignatura = new eva_cat_asignaturas();
        }

        public FicVmCatAsignaturasAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _Asignaturas = new eva_cat_asignaturas();
        }

    }
}
