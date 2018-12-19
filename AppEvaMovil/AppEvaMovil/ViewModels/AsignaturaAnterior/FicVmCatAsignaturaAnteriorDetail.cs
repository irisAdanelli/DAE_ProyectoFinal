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
using AppEvaMovil.ViewModels;

namespace AppEvaMovil.ViewModels.AsignaturaAnterior
{
    public class FicVmCatAsignaturaAnteriorDetail : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvAsignaturaAnterior FicLoSrvApp;//INTERFAZ CRUD

        private eva_reticula_asignatura_ant _AsignaturaAnterior;
        public eva_reticula_asignatura_ant AsignaturaAnterior
        {
            get { return _AsignaturaAnterior; }
            set
            {
                _AsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

        private ICommand BackNavigation;
        public ICommand BackNavgCommand
        {
            get { return BackNavigation = BackNavigation ?? new FicVmDelegateCommand(BackNavgExecute); }
        }
        public void BackNavgExecute()
        {
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        private ICommand EditAsignaturaAnterior;
        public ICommand FicMetEditCommand
        {
            get { return EditAsignaturaAnterior = EditAsignaturaAnterior ?? new FicVmDelegateCommand(EditAsignaturaAnteriorExecute); }
        }
        private void EditAsignaturaAnteriorExecute()
        {
            //FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturasUpdate>(AsignaturaAnterior);
        }

        public FicVmCatAsignaturaAnteriorDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            AsignaturaAnterior = navigationContext as eva_reticula_asignatura_ant;
        }
    }
}
