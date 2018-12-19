using AppEvaMovil.Data;
using AppEvaMovil.Models;
using AppEvaMovil.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Interfaces;
using AppEvaMovil.Services;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.AsignaturaAnterior
{
    public class FicVmCatAsignaturaAnteriorAdd : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvAsignaturaAnterior FicLoSrvApp;//INTERFAZ CRUD

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

        private ICommand AddAsignaturaAnterior;
        public ICommand FicMetAddCommand
        {
            get { return AddAsignaturaAnterior = AddAsignaturaAnterior ?? new FicVmDelegateCommand(AddAsignaturaAnteriorExecute); }
        }
        private async void AddAsignaturaAnteriorExecute()
        {
            AsignaturaAnterior.UsuarioMod = AsignaturaAnterior.UsuarioReg;
            await FicLoSrvApp.FicMetInsertAsignaturaAnterior(AsignaturaAnterior);
            //validar entradas
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturaAnteriorAdd>(null);
            await Application.Current.MainPage.DisplayAlert("Se Agrego Con Exito", "Para continuar da clic en ok", "OK");
            AsignaturaAnterior = new eva_reticula_asignatura_ant();
        }

        public FicVmCatAsignaturaAnteriorAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _AsignaturasAnterior = new eva_reticula_asignatura_ant();
        }

    }
}
