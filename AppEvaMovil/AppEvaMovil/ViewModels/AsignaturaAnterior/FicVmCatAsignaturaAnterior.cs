using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Interfaces; 
using AppEvaMovil.Models;

namespace AppEvaMovil.ViewModels.AsignaturaAnterior 
{
    public class FicVmCatAsignaturaAnterior : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvAsignaturaAnterior FicLoSrvApp;//INTERFAZ CRUD
        private IFicSrvCatReticulas FicLoReticulas; //Inventario Reticulas
        private IFicSrvCatAsignaturas FicLoAsignaturas; //Inventario Asignaturas
        private string _FicLabelIdInv;
        //DesReticula , DesAsignatura

        public FicVmCatAsignaturaAnterior(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp, IFicSrvCatReticulas FicReticulas, IFicSrvCatAsignaturas FicAsignaturas)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoReticulas = FicReticulas;
            FicLoAsignaturas = FicAsignaturas;
        }

        private String _DesReticulas;
        public String DesReticulas
        {
            get { return _DesReticulas; }
            set
            {
                _DesReticulas = value;
                RaisePropertyChanged();
            }
        }
        private String _DesAsignaturas;
        public String DesAsignaturas
        {
            get { return _DesAsignaturas; }
            set
            {
                _DesAsignaturas = value;
                RaisePropertyChanged();
            }
        }
        private String _DesAsignaturaAnterior;
        public String DesAsignaturaAnterior
        {
            get { return _DesAsignaturaAnterior; }
            set
            {
                _DesAsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<eva_reticula_asignatura_ant_aux> _SfDataGrid_ItemSource_AsignaturaAnterior;
        public ObservableCollection<eva_reticula_asignatura_ant_aux> SfDataGrid_ItemSource_AsignaturaAnterior
        {
            get { return _SfDataGrid_ItemSource_AsignaturaAnterior; }
            set
            {
                _SfDataGrid_ItemSource_AsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

        private eva_reticula_asignatura_ant_aux _SfDataGrid_SelectItem_AsignaturaAnterior;
        public eva_reticula_asignatura_ant_aux SfDataGrid_SelectItem_AsignaturaAnterior
        {
            get { return _SfDataGrid_SelectItem_AsignaturaAnterior; }
            set
            {
                _SfDataGrid_SelectItem_AsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

        private ICommand AddNewAsignaturaAnterior;
        public ICommand FicMetAddCommand
        {
            get { return AddNewAsignaturaAnterior = AddNewAsignaturaAnterior ?? new FicVmDelegateCommand(AddNewAsignaturaAnteriorExecute); }
        }
        private void AddNewAsignaturaAnteriorExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturaAnteriorAdd>(null);
        }

        private ICommand EditAsignaturaAnterior;
        public ICommand FicMetEditCommand
        {
            get { return EditAsignaturaAnterior = EditAsignaturaAnterior ?? new FicVmDelegateCommand(EditAsignaturaAnteriorExecute); }
        }
        private void EditAsignaturaAnteriorExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturaAnteriorUpdate>(SfDataGrid_SelectItem_AsignaturaAnterior);
        }

        private ICommand DetailAsignaturaAnterior;
        public ICommand FicMetDetailsCommand
        {
            get { return DetailAsignaturaAnterior = DetailAsignaturaAnterior ?? new FicVmDelegateCommand(DetailAsignaturaAnteriorExecute); }
        }
        private void DetailAsignaturaAnteriorExecute()
        {
            var temp = _SfDataGrid_SelectItem_AsignaturaAnterior;
            if (temp != null)
            {
                FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturaAnteriorDetail>(temp);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alerta", "Por favor seleccione una Asignatura. ", "OK");
            }

        }

        private ICommand DeleteAsignaturaAnterior;
        public ICommand FicMetDeleteCommand
        {
            get { return DeleteAsignaturaAnterior = DeleteAsignaturaAnterior ?? new FicVmDelegateCommand(DeleteAsignaturaAnteriorExecute); }
        }
        private void DeleteAsignaturaAnteriorExecute()
        {

        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var resultadoAsignaturaAnterior = await FicLoSrvApp.FicMetGetListAsignaturaAnterior();

            //SfDataGrid_ItemSource_AsignaturaAnterior = new ObservableCollection<eva_reticula_asignatura_ant_aux>();
            SfDataGrid_ItemSource_AsignaturaAnterior = new ObservableCollection<eva_reticula_asignatura_ant_aux>();

            //foreach (var asignaturaanterior in resultadoAsignaturaAnterior)
            //{
            //    SfDataGrid_ItemSource_AsignaturaAnterior.Add(asignaturaanterior);
            //}

            //OBTENER LOS REGISTROS DE LA TABLA
            var cat_reticulas = await FicLoReticulas.FicMetGetListReticulas();//CATALOGO DE Reticulas
            var cat_asignaturas = await FicLoAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE Asignaturas
            var cat_asignatura_anterior = await FicLoAsignaturas.FicMetGetListAsignaturas();//CATALOGO DE Asig Anterior
            foreach (var reticula in resultadoAsignaturaAnterior)
            {
                eva_reticula_asignatura_ant_aux temporal = new eva_reticula_asignatura_ant_aux()
                {
                    IdAsignatura = reticula.IdAsignatura,
                    IdAsignaturaAnterior = reticula.IdAsignaturaAnterior,
                    IdReticula = reticula.IdReticula,
                    FechaReg = reticula.FechaReg,
                    UsuarioReg = reticula.UsuarioReg,
                    FechaUltMod = reticula.FechaUltMod,
                    UsuarioMod = reticula.UsuarioMod,
                    Activo = reticula.Activo,
                    Borrado = reticula.Borrado,
                    DesReticulas = cat_reticulas.First<eva_cat_reticulas>(cg => cg.IdReticula == reticula.IdReticula).DesReticula,
                    DesAsignaturas = cat_asignaturas.First<eva_cat_asignaturas>(cg => cg.IdAsignatura == reticula.IdAsignatura).DesAsignatura,
                    DesAsignaturaAnterior = cat_asignatura_anterior.First<eva_cat_asignaturas>(cg => cg.IdAsignatura == reticula.IdAsignaturaAnterior).DesAsignatura,
                };
                SfDataGrid_ItemSource_AsignaturaAnterior.Add(temporal);
            }
        }

    }
}
