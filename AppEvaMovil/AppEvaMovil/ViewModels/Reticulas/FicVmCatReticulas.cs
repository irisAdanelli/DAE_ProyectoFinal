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

namespace AppEvaMovil.ViewModels.Reticulas
{
    public class FicVmCatReticulas : FicViewModelBase 
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulas FicLoSrvApp;//INTERFAZ CRUD
        private IFicSrvCatGenerales FicLoCatGenerales;//PARA OBTENER LOS CATALOGO Y YA HACER EL REEMPLAZO DEL ID POR LA DESCRIPCION
        private IFicSrvCatTipoGenerales FicLoCatTipoGenerales;
        private string _FicLabelIdInv;

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

        public FicVmCatReticulas(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp, IFicSrvCatTipoGenerales TiposCatalogos, IFicSrvCatGenerales Catalogos)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoCatGenerales = Catalogos;
            FicLoCatTipoGenerales = TiposCatalogos;
        }

        public ObservableCollection<eva_cat_reticulas_aux> _SfDataGrid_ItemSource_Reticulas;
        public ObservableCollection<eva_cat_reticulas_aux> SfDataGrid_ItemSource_Reticulas
        {
            get { return _SfDataGrid_ItemSource_Reticulas; }
            set
            {
                _SfDataGrid_ItemSource_Reticulas = value;
                RaisePropertyChanged();
            }
        }

        private eva_cat_reticulas_aux _SfDataGrid_SelectItem_Reticulas;
        public eva_cat_reticulas_aux SfDataGrid_SelectItem_Reticulas
        {
            get { return _SfDataGrid_SelectItem_Reticulas; }
            set
            {
                _SfDataGrid_SelectItem_Reticulas = value;
                RaisePropertyChanged();
            }
        }

        private ICommand AddNewReticulas;
        public ICommand FicMetAddCommand
        {
            get { return AddNewReticulas = AddNewReticulas ?? new FicVmDelegateCommand(AddNewReticulasExecute); }
        }
        private void AddNewReticulasExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAdd>(null);
        }

        private ICommand EditReticulas;
        public ICommand FicMetEditCommand
        {
            get { return EditReticulas = EditReticulas ?? new FicVmDelegateCommand(EditReticulasExecute); }
        }
        private void EditReticulasExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasUpdate>(SfDataGrid_SelectItem_Reticulas);
        }

        private ICommand DetailsReticulas;
        public ICommand FicMetDetailsCommand
        {
            get { return DetailsReticulas = DetailsReticulas ?? new FicVmDelegateCommand(DetailsReticulasExecute); }
        }
        private void DetailsReticulasExecute()
        {
            var temp = _SfDataGrid_SelectItem_Reticulas;
            if (temp != null)
            {
                FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasDetail>(temp);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alerta", "Por favor seleccione una Reticula. ", "OK");
            }

        }

        private ICommand DeleteReticulas;
        public ICommand FicMetDeleteCommand
        {
            get { return DeleteReticulas = DeleteReticulas ?? new FicVmDelegateCommand(DeleteReticulasExecute); }
        }
        private void DeleteReticulasExecute()
        {

        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var resultadoReticulas = await FicLoSrvApp.FicMetGetListReticulas();

            SfDataGrid_ItemSource_Reticulas = new ObservableCollection<eva_cat_reticulas_aux>();

            //OBTENER LOS REGISTROS DE LA TABLA
            var cat_tipos_gener = await FicLoCatTipoGenerales.FicMetGetListTipoGenerales();//CATALOGO DE TIPOS
            
            var cat_gen = await FicLoCatGenerales.FicMetGetListGenerales();//CATALOGO DE GENERALES
            
            foreach (var reticula in resultadoReticulas)
            {
                eva_cat_reticulas_aux temporal = new eva_cat_reticulas_aux()
                {
                    IdTipoGenPlanEstudios = reticula.IdTipoGenPlanEstudios,
                    IdGenPlanEstudios = reticula.IdGenPlanEstudios,
                    IdReticula = reticula.IdReticula,
                    Clave = reticula.Clave,
                    DesReticula = reticula.DesReticula,
                    Actual = reticula.Actual,
                    FechaIni = reticula.FechaIni,
                    FechaFin = reticula.FechaFin,
                    FechaReg = reticula.FechaReg,
                    UsuarioReg = reticula.UsuarioReg,
                    FechaUltMod = reticula.FechaUltMod,
                    UsuarioMod = reticula.UsuarioMod,
                    Activo = reticula.Activo,
                    Borrado = reticula.Borrado,
                    DesGenPlanEstudios = cat_gen.First<cat_generales>(cg => cg.IdGeneral == reticula.IdGenPlanEstudios).DesGeneral,
                    DesTipoGenPlanEstudios = cat_tipos_gener.First<cat_tipo_generales>(cg => cg.IdTipoGeneral == reticula.IdTipoGenPlanEstudios).DesTipo
                };
                SfDataGrid_ItemSource_Reticulas.Add(temporal);
            }

            

        }
    }
}
