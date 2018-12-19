using AppEvaMovil.Interfaces;
using AppEvaMovil.Services.Navigation;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels;
using AppEvaMovil.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.ViewModels.Asignaturas;

namespace AppEvaMovil.ViewModels.Asignaturas
{
    public  class FicVmCatAsignaturas : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatAsignaturas FicLoSrvApp;//INTERFAZ CRUD
        private string _FicLabelIdInv;

        public FicVmCatAsignaturas(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public ObservableCollection<eva_cat_asignaturas> _SfDataGrid_ItemSource_Asignaturas;
        public ObservableCollection<eva_cat_asignaturas> SfDataGrid_ItemSource_Asignaturas
        {
            get { return _SfDataGrid_ItemSource_Asignaturas; }
            set
            {
                _SfDataGrid_ItemSource_Asignaturas = value;
                RaisePropertyChanged();
            }
        }

        private eva_cat_asignaturas _SfDataGrid_SelectItem_Asignatura;
        public eva_cat_asignaturas SfDataGrid_SelectItem_Asignatura
        {
            get { return _SfDataGrid_SelectItem_Asignatura; }
            set
            {
                _SfDataGrid_SelectItem_Asignatura = value;
                RaisePropertyChanged();
            }
        }

        //FicMetGetListAsignaturas

        private ICommand AddNewAsignatura;
        public ICommand FicMetAddCommand
        {
            get { return AddNewAsignatura = AddNewAsignatura ?? new FicVmDelegateCommand(AddNewAsignaturaExecute); }
        }
        private void AddNewAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturasAdd>(null);
        }

        private ICommand EditAsignatura;
        public ICommand FicMetEditCommand
        {
            get { return EditAsignatura = EditAsignatura ?? new FicVmDelegateCommand(EditAsignaturaExecute); }
        }
        private void EditAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturasUpdate>(SfDataGrid_SelectItem_Asignatura);
        }

        private ICommand DetailsAsignatura;
        public ICommand FicMetDetailsCommand
        {
            get { return DetailsAsignatura = DetailsAsignatura ?? new FicVmDelegateCommand(DetailsAsignaturaExecute); }
        }
        private void DetailsAsignaturaExecute()
        {
            var temp = _SfDataGrid_SelectItem_Asignatura;
            if (temp != null)
            {
                FicLoSrvNavigation.FicMetNavigateTo<FicVmCatAsignaturasDetail>(temp);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alerta", "Por favor seleccione una Asignatura. ", "OK");
            }

        }

        private ICommand DeleteAsignatura;
        public ICommand FicMetDeleteCommand
        {
            get { return DeleteAsignatura = DeleteAsignatura ?? new FicVmDelegateCommand(DeleteAsignaturaExecute); }
        }
        private void DeleteAsignaturaExecute()
        {

        }

        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            var resultadoAsignaturas = await FicLoSrvApp.FicMetGetListAsignaturas();

            SfDataGrid_ItemSource_Asignaturas = new ObservableCollection<eva_cat_asignaturas>();

            foreach (var asignatura in resultadoAsignaturas)
            {
                SfDataGrid_ItemSource_Asignaturas.Add(asignatura);
            }
        }

    }
}
