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
using AppEvaMovil.ViewModels.Reticulas;
using AppEvaMovil.ViewModels.Asignaturas;
using AppEvaMovil.ViewModels.AsignaturaAnterior;

namespace AppEvaMovil.ViewModels.AsignaturaAnterior
{
    public class FicVmCatAsignaturaAnteriorDetail : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvAsignaturaAnterior FicLoSrvApp;//INTERFAZ CRUD
        private IFicSrvCatReticulas FicLoCatReticulas;//PARA OBTENER LOS CATALOGO Y YA HACER EL REEMPLAZO DEL ID POR LA DESCRIPCION
        private IFicSrvCatAsignaturas FicLoCatAsignaturas; 
        /// <summary>
        /// 
        /// </summary>

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

        private String _AsignaturaAnt;
        public String AsignaturaAnt
        {
            get { return _AsignaturaAnt; }
            set
            {
                _AsignaturaAnt = value;
                RaisePropertyChanged();
            }
        }

        private String _Asignatura;
        public String Asignatura
        {
            get { return _Asignatura; }
            set
            {
                _Asignatura = value;
                RaisePropertyChanged();
            }
        }

        private String _Reticula;
        public String Reticula
        {
            get { return _Reticula; }
            set
            {
                _Reticula = value;
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

        public FicVmCatAsignaturaAnteriorDetail(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp, IFicSrvCatReticulas CatReticulas, IFicSrvCatAsignaturas CatAsignaturas, IFicSrvCatAsignaturas CatAsignaturaAnt)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoCatReticulas = CatReticulas;
            FicLoCatAsignaturas = CatAsignaturas;
            FicLoCatAsignaturas = CatAsignaturaAnt;

        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            AsignaturaAnterior = navigationContext as eva_reticula_asignatura_ant;

            //OBTENER LOS REGISTROS
            var cat_reticulas = await FicLoCatReticulas.FicMetGetListReticulas();//CATALOGO DE reticulas
            foreach (eva_cat_reticulas temporal in cat_reticulas)
            {
                if (temporal.IdReticula == AsignaturaAnterior.IdReticula)
                {
                    Reticula = temporal.DesReticula;
                }
            }
            var cat_asignaturas = await FicLoCatAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE asignaturas
            foreach (eva_cat_asignaturas temporal in cat_asignaturas)
            {
                if (temporal.IdAsignatura == AsignaturaAnterior.IdAsignatura)
                {
                    Asignatura = temporal.DesAsignatura;
                }
            }

            var cat_asignaturaAnt = await FicLoCatAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE asignaturas anterior
            foreach (eva_cat_asignaturas temporal in cat_asignaturaAnt)
            {
                if (temporal.IdAsignatura == AsignaturaAnterior.IdAsignaturaAnterior)
                {
                    AsignaturaAnt = temporal.DesAsignatura;
                }
            }
        }
    }
}
