using AppEvaMovil.Data;
using AppEvaMovil.Services;
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

namespace AppEvaMovil.ViewModels.AsignaturaAnterior
{
    public class FicVmCatAsignaturaAnteriorUpdate : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvAsignaturaAnterior FicLoSrvApp;//INTERFAZ CRUD
        private FicDBContext dBContext;

        private eva_reticula_asignatura_ant _AsignaturasAnterior;
        public eva_reticula_asignatura_ant AsignaturaAnterior
        {
            get { return _AsignaturasAnterior; }
            set
            {
                _AsignaturasAnterior = value;
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

        private ICommand UpdateAsignaturaAnterior;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateAsignaturaAnterior = UpdateAsignaturaAnterior ?? new FicVmDelegateCommand(UpdateAsignaturaAnteriorExecute); }
        }
        private void UpdateAsignaturaAnteriorExecute()
        {
            AsignaturaAnterior.FechaUltMod = DateTime.Now;
            FicLoSrvApp.FicMetUpdateAsignaturaAnterior(AsignaturaAnterior);
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        public FicVmCatAsignaturaAnteriorUpdate(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            AsignaturaAnterior = (navigationContext as eva_reticula_asignatura_ant);
        }

    }
}
