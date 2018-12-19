using AppEvaMovil.Interfaces;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels.Reticulas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.Data;

namespace AppEvaMovil.ViewModels.Reticulas
{
    public class FicVmCatReticulasUpdate : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulas FicLoSrvApp;//INTERFAZ CRUD
        private FicDBContext dBContext;
    
        private eva_cat_reticulas _Reticulas;
        public eva_cat_reticulas Reticulas
        {
            get { return _Reticulas; }
            set
            {
                _Reticulas = value;
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

        private ICommand UpdateReticula;
        public ICommand FicMetUpdateCommand
        {
            get { return UpdateReticula = UpdateReticula ?? new FicVmDelegateCommand(UpdateReticulaExecute); }
        }
        private void UpdateReticulaExecute()
        {
            Reticulas.FechaUltMod = DateTime.Now;
            FicLoSrvApp.FicMetUpdateReticula(Reticulas);
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        public FicVmCatReticulasUpdate(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            Reticulas = (navigationContext as eva_cat_reticulas);
        }
    }
}
