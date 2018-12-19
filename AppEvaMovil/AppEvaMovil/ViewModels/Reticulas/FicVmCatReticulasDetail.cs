using AppEvaMovil.Interfaces;
using AppEvaMovil.Services;
using AppEvaMovil.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.ViewModels.Reticulas;

namespace AppEvaMovil.ViewModels.Reticulas
{
    public class FicVmCatReticulasDetail : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulas FicLoSrvApp;//INTERFAZ CRUD

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
        public void BackNavgExecute()
        {
            FicLoSrvNavigation.FicMetNavigateBack();
        }

        private ICommand EditReticula;
        public ICommand FicMetEditCommand
        {
            get { return EditReticula = EditReticula ?? new FicVmDelegateCommand(EditReticulaExecute); }
        }
        private void EditReticulaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasUpdate>(Reticulas);
        }

        public FicVmCatReticulasDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            Reticulas = navigationContext as eva_cat_reticulas;
        }
    }
}
