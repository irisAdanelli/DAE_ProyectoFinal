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
        private IFicSrvCatAsignaturas FicLoAsignaturas;
        private IFicSrvCatReticulas FicLoReticulas;

        private ObservableCollection<eva_cat_asignaturas> _AsignaturaDesAsignatura;
        public ObservableCollection<eva_cat_asignaturas> AsignaturaDesAsignatura
        {
            get { return _AsignaturaDesAsignatura; }
            set
            {
                _AsignaturaDesAsignatura = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<eva_cat_reticulas> _ReticulaDesReticula;
        public ObservableCollection<eva_cat_reticulas> ReticulaDesReticula
        {
            get { return _ReticulaDesReticula; }
            set
            {
                _ReticulaDesReticula = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<eva_cat_asignaturas> _AsignaturaDesAsignaturaAnterior;
        public ObservableCollection<eva_cat_asignaturas> AsignaturaDesAsignaturaAnterior
        {
            get { return _AsignaturaDesAsignaturaAnterior; }
            set
            {
                _AsignaturaDesAsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

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


        //selected
        private eva_cat_asignaturas _Selected_Asignatura;
        public eva_cat_asignaturas Selected_Asignatura
        {
            get { return _Selected_Asignatura; }
            set
            {
                _Selected_Asignatura = value;
                RaisePropertyChanged();
            }
        }

        private eva_cat_reticulas _Selected_Reticula;
        public eva_cat_reticulas Selected_Reticula
        {
            get { return _Selected_Reticula; }
            set
            {
                _Selected_Reticula = value;
                RaisePropertyChanged();
            }
        }

        private eva_cat_asignaturas _Selected_AsignaturaAnterior;
        public eva_cat_asignaturas Selected_AsignaturaAnterior
        {
            get { return _Selected_AsignaturaAnterior; }
            set
            {
                _Selected_AsignaturaAnterior = value;
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

        public FicVmCatAsignaturaAnteriorAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp, IFicSrvCatAsignaturas FicAsignaturas, IFicSrvCatReticulas FicReticulas)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoAsignaturas = FicAsignaturas;
            FicLoReticulas = FicReticulas;
            
        }
        //-------//-------//-------//
        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _AsignaturasAnterior = new eva_reticula_asignatura_ant();


            //||||
            //OBTENER LOS REGISTROS DE LA TABLA
            AsignaturaDesAsignatura = new ObservableCollection<eva_cat_asignaturas>();
            var tempList = await FicLoAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE ASIGNATURAS
            foreach (eva_cat_asignaturas ctg in tempList)
            {
                AsignaturaDesAsignatura.Add(ctg);
            }

            ReticulaDesReticula = new ObservableCollection<eva_cat_reticulas>();
            var cat_asg = await FicLoReticulas.FicMetGetListReticulas();//CATALOGO DE RETICULAS
            foreach (eva_cat_reticulas cg in cat_asg)
            {
                ReticulaDesReticula.Add(cg);
            }
            //AsignaturaDesAsignaturaAnterior
            AsignaturaDesAsignaturaAnterior = new ObservableCollection<eva_cat_asignaturas>();
            var tempListAnt = await FicLoAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE ASIGNATURAS ANT
            foreach (eva_cat_asignaturas ctg in tempListAnt)
            {
                AsignaturaDesAsignaturaAnterior.Add(ctg);
            }
        }

    }
}
