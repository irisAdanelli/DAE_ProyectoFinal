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
using AppEvaMovil;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.Asignaturas
{
    public  class FicVmCatAsignaturasUpdate : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatAsignaturas FicLoSrvApp;//INTERFAZ CRUD
        private FicDBContext dBContext;

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

        private ICommand UpdateAsignatura;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateAsignatura = UpdateAsignatura ?? new FicVmDelegateCommand(UpdateAsignaturaExecute); }
        }
        private void UpdateAsignaturaExecute()
        {
            Asignatura.FechaUltMod = DateTime.Now;
            FicLoSrvApp.FicMetUpdateAsignatura(Asignatura);
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        public FicVmCatAsignaturasUpdate(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            Asignatura = (navigationContext as eva_cat_asignaturas);
        }

    }
}
