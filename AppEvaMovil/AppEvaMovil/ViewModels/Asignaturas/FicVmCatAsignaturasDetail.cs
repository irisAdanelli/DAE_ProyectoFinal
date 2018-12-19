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
using AppEvaMovil.ViewModels.Asignaturas;

namespace AppEvaMovil.ViewModels.Asignaturas
{
    public  class FicVmCatAsignaturasDetail : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatAsignaturas FicLoSrvApp;//INTERFAZ CRUD

        private eva_cat_asignaturas _Asignatura;
        public eva_cat_asignaturas Asignatura
        {
            get { return _Asignatura; }
            set
            {
                _Asignatura = value;
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

        private ICommand EditAsignatura;
        public ICommand FicMetEditCommand
        {
            get { return EditAsignatura = EditAsignatura ?? new FicVmDelegateCommand(EditAsignaturaExecute); }
        }
        private void EditAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturasUpdate>(Asignatura);
        }

        public FicVmCatAsignaturasDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            Asignatura = navigationContext as eva_cat_asignaturas;
        }

    }
}
