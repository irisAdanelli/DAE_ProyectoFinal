using AppEvaMovil.Interfaces;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels.Reticulas;
using AppEvaMovil.ViewModels.AsignaturaAnterior;
using AppEvaMovil.ViewModels.Asignaturas;
using AppEvaMovil.ViewModels.ReticulasAsignaturas;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels
{
    public class FicVmMenuPrincipal : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private string _FicLabelIdInv;

        public FicVmMenuPrincipal(IFicSrvNavigation FicPaSrvNavigation)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
        }

        // =============== FicMetListReticulaCommand =============== 
        private ICommand NavigateToReticulaList;
        public ICommand FicMetListReticulaCommand
        {
            get { return NavigateToReticulaList = NavigateToReticulaList ?? new FicVmDelegateCommand(NavigateToReticulaListExecute); }
        }
        private void NavigateToReticulaListExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulas>(null);
        }

        // =============== FicMetListAsignaturaCommand =============== 
        private ICommand NavigateToAsignatura;
        public ICommand FicMetListAsignaturaCommand
        {
            get { return NavigateToAsignatura = NavigateToAsignatura ?? new FicVmDelegateCommand(NavigateToAsignaturaListExecute); }
        }
        private void NavigateToAsignaturaListExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturas>(null);
        }

        // =============== FicMetListAsigAnterioirCommand =============== 
        private ICommand NavigateToAsigAnterioir;
        public ICommand FicMetListAsigAnterioirCommand
        {
            get { return NavigateToAsigAnterioir = NavigateToAsigAnterioir ?? new FicVmDelegateCommand(NavigateToAsigAnterioirListExecute); }
        }
        private void NavigateToAsigAnterioirListExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturaAnterior>(null);
        }

        // =============== FicMetRetAsignaturaCommand =============== 
        private ICommand NavigateToRetAsignatura;
        public ICommand FicMetRetAsignaturaCommand
        {
            get { return NavigateToRetAsignatura = NavigateToRetAsignatura ?? new FicVmDelegateCommand(NavigateToRetAsignaturaListExecute); }
        }
        private void NavigateToRetAsignaturaListExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturas>(null);
        }



        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
        }

    }
}
