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
        private string _FicLabelIdInv;

        public FicVmCatReticulas(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
        }

        public ObservableCollection<eva_cat_reticulas> _SfDataGrid_ItemSource_Reticulas;
        public ObservableCollection<eva_cat_reticulas> SfDataGrid_ItemSource_Reticulas
        {
            get { return _SfDataGrid_ItemSource_Reticulas; }
            set
            {
                _SfDataGrid_ItemSource_Reticulas = value;
                RaisePropertyChanged();
            }
        }

        private eva_cat_reticulas _SfDataGrid_SelectItem_Reticulas;
        public eva_cat_reticulas SfDataGrid_SelectItem_Reticulas
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

            SfDataGrid_ItemSource_Reticulas = new ObservableCollection<eva_cat_reticulas>();

            foreach (var reticula in resultadoReticulas)
            {
                SfDataGrid_ItemSource_Reticulas.Add(reticula);
            }
        }
    }
}
