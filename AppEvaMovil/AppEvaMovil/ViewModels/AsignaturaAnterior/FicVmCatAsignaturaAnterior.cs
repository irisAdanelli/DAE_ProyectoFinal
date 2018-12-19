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
        private string _FicLabelIdInv;

        public FicVmCatAsignaturaAnterior(IFicSrvNavigation FicPaSrvNavigation, IFicSrvAsignaturaAnterior FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public ObservableCollection<eva_reticula_asignatura_ant> _SfDataGrid_ItemSource_AsignaturaAnterior;
        public ObservableCollection<eva_reticula_asignatura_ant> SfDataGrid_ItemSource_AsignaturaAnterior
        {
            get { return _SfDataGrid_ItemSource_AsignaturaAnterior; }
            set
            {
                _SfDataGrid_ItemSource_AsignaturaAnterior = value;
                RaisePropertyChanged();
            }
        }

        private eva_reticula_asignatura_ant _SfDataGrid_SelectItem_AsignaturaAnterior;
        public eva_reticula_asignatura_ant SfDataGrid_SelectItem_AsignaturaAnterior
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

        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var resultadoAsignaturaAnterior = await FicLoSrvApp.FicMetGetListAsignaturaAnterior();

            SfDataGrid_ItemSource_AsignaturaAnterior = new ObservableCollection<eva_reticula_asignatura_ant>();

            foreach (var asignaturaanterior in resultadoAsignaturaAnterior)
            {
                SfDataGrid_ItemSource_AsignaturaAnterior.Add(asignaturaanterior);
            }
        }

    }
}
