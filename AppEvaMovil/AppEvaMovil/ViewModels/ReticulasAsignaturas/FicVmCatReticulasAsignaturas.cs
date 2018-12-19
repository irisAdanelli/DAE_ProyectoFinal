using AppEvaMovil.Interfaces;
using AppEvaMovil.Services.Navigation;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels.Reticulas;
using AppEvaMovil.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.ViewModels;
using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.ViewModels.ReticulasAsignaturas;

namespace AppEvaMovil.ViewModels.ReticulasAsignaturas
{
    public  class FicVmCatReticulasAsignaturas : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulasAsignaturas FicLoSrvApp;//INTERFAZ CRUD
        private string _FicLabelIdInv;

        public FicVmCatReticulasAsignaturas(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulasAsignaturas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public ObservableCollection<eva_reticulas_asignaturas> _SfDataGrid_ItemSource_ReticulasAsignaturas;
        public ObservableCollection<eva_reticulas_asignaturas> SfDataGrid_ItemSource_ReticulasAsignaturas
        {
            get { return _SfDataGrid_ItemSource_ReticulasAsignaturas; }
            set
            {
                _SfDataGrid_ItemSource_ReticulasAsignaturas = value;
                RaisePropertyChanged();
            }
        }

        private eva_reticulas_asignaturas _SfDataGrid_SelectItem_ReticulasAsignaturas;
        public eva_reticulas_asignaturas SfDataGrid_SelectItem_ReticulasAsignaturas
        {
            get { return _SfDataGrid_SelectItem_ReticulasAsignaturas; }
            set
            {
                _SfDataGrid_SelectItem_ReticulasAsignaturas = value;
                RaisePropertyChanged();
            }
        }

        private ICommand AddNewReticulasAsignatura;
        public ICommand FicMetAddCommand
        {
            get { return AddNewReticulasAsignatura = AddNewReticulasAsignatura ?? new FicVmDelegateCommand(AddNewReticulasAsignaturaExecute); }
        }
        private void AddNewReticulasAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturasAdd>(null);
        }

        private ICommand EditReticulasAsignatura;
        public ICommand FicMetEditCommand
        {
            get { return EditReticulasAsignatura = EditReticulasAsignatura ?? new FicVmDelegateCommand(EditReticulasAsignaturaExecute); }
        }
        private void EditReticulasAsignaturaExecute()
        {
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturasUpdate>(SfDataGrid_SelectItem_ReticulasAsignaturas);
        }

        private ICommand DetailReticulasAsignatura;
        public ICommand FicMetDetailsCommand
        {
            get { return DetailReticulasAsignatura = DetailReticulasAsignatura ?? new FicVmDelegateCommand(DetailReticulasAsignaturaExecute); }
        }
        private void DetailReticulasAsignaturaExecute()
        {
            var temp = _SfDataGrid_SelectItem_ReticulasAsignaturas;
            if (temp != null)
            {
                FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulasAsignaturasDetail>(temp);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Alerta", "Por favor seleccione una Asignatura. ", "OK");
            }

        }

        private ICommand DeleteReticulasAsignatura;
        public ICommand FicMetDeleteCommand
        {
            get { return DeleteReticulasAsignatura = DeleteReticulasAsignatura ?? new FicVmDelegateCommand(DeleteReticulasAsignaturaExecute); }
        }
        private void DeleteReticulasAsignaturaExecute()
        {

        }

        public async override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);              
            var resultadoReticulasAsignaturas = await FicLoSrvApp.FicMetGetListReticulasAsignaturas();

            SfDataGrid_ItemSource_ReticulasAsignaturas = new ObservableCollection<eva_reticulas_asignaturas>();

            foreach (var reticulaasignatura in resultadoReticulasAsignaturas)
            {
                SfDataGrid_ItemSource_ReticulasAsignaturas.Add(reticulaasignatura);
            }
        }

    }
}
