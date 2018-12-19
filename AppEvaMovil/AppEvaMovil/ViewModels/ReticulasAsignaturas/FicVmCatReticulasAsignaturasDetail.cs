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
using AppEvaMovil.ViewModels.ReticulasAsignaturas;

namespace AppEvaMovil.ViewModels.ReticulasAsignaturas
{
    public  class FicVmCatReticulasAsignaturasDetail : FicViewModelBase
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
        public void BackNavgExecute()
        {
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        private ICommand EditReticulasAsignatura;
        public ICommand FicMetEditCommand
        {
            get { return EditReticulasAsignatura = EditReticulasAsignatura ?? new FicVmDelegateCommand(EditReticulasAsignaturaExecute); }
        }
        private void EditReticulasAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturasUpdate>(ReticulasAsignaturas);
        }

        public FicVmCatReticulasAsignaturasDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulasAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            ReticulasAsignaturas = navigationContext as eva_reticulas_asignaturas;
        }

    }
}
