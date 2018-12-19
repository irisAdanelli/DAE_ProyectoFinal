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
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.ReticulasAsignaturas
{
    public  class FicVmCatReticulasAsignaturasUpdate : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulasAsignaturas FicLoSrvApp;//INTERFAZ CRUD
        private FicDBContext dBContext;

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

        private ICommand UpdateReticulasAsignatura;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateReticulasAsignatura = UpdateReticulasAsignatura ?? new FicVmDelegateCommand(UpdateReticulasAsignaturaExecute); }
        }
        private void UpdateReticulasAsignaturaExecute()
        {
            ReticulasAsignaturas.FechaUltMod = DateTime.Now;
            FicLoSrvApp.FicMetUpdateReticulasAsignaturas(ReticulasAsignaturas);
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        public FicVmCatReticulasAsignaturasUpdate(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulasAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            ReticulasAsignaturas = (navigationContext as eva_reticulas_asignaturas);
        }

    }
}
