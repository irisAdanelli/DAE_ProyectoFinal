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
        private IFicSrvCatGenerales FicLoCatGenerales;//PARA OBTENER LOS CATALOGO Y YA HACER EL REEMPLAZO DEL ID POR LA DESCRIPCION
        private IFicSrvCatTipoGenerales FicLoCatTipoGenerales;

        private String _TipoPlanEstudiosDes;
        public String TipoPlanEstudiosDes 
        {
            get { return _TipoPlanEstudiosDes; }
            set
            {
                _TipoPlanEstudiosDes = value;
                RaisePropertyChanged();
            }
        }
        private String _PlanEstudiosDes;
        public String PlanEstudiosDes
        {
            get { return _PlanEstudiosDes; }
            set
            {
                _PlanEstudiosDes = value;
                RaisePropertyChanged();
            }
        }

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

        public FicVmCatReticulasDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp, IFicSrvCatTipoGenerales TiposCatalogos, IFicSrvCatGenerales Catalogos)
        {
           
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoCatGenerales = Catalogos;
            FicLoCatTipoGenerales = TiposCatalogos;
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            Reticulas = navigationContext as eva_cat_reticulas;
            //OBTENER LOS REGISTROS DE LA TABLA
            var cat_tipos_gener = await FicLoCatTipoGenerales.FicMetGetListTipoGenerales();//CATALOGO DE TIPOS
            foreach (cat_tipo_generales temporal in cat_tipos_gener)
            {
                if (temporal.IdTipoGeneral == Reticulas.IdTipoGenPlanEstudios)
                {
                    TipoPlanEstudiosDes = temporal.DesTipo;
                }
            }
            var cat_gen = await FicLoCatGenerales.FicMetGetListGenerales();//CATALOGO DE GENERALES
            foreach (cat_generales temporal in cat_gen)
            {
                if (temporal.IdGeneral == Reticulas.IdGenPlanEstudios)
                {
                    PlanEstudiosDes = temporal.DesGeneral;
                }
            }
        }
    }
}
