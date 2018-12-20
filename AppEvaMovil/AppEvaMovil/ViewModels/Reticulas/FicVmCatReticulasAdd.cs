using AppEvaMovil.Data;
using AppEvaMovil.Interfaces;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.ViewModels.Reticulas;
using System; 
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppEvaMovil.Models;
using AppEvaMovil.Interfaces.Navigation;

namespace AppEvaMovil.ViewModels.Reticulas
{
    public class FicVmCatReticulasAdd : FicViewModelBase
    {
        private IFicSrvNavigation FicLoSrvNavigation;//INTERFAZ NVEGACION
        private IFicSrvCatReticulas FicLoSrvApp;//INTERFAZ CRUD
        private IFicSrvCatGenerales FicLoCatGenerales;//PARA OBTENER LOS CATALOGO Y YA HACER EL REEMPLAZO DEL ID POR LA DESCRIPCION
        private IFicSrvCatTipoGenerales FicLoCatTipoGenerales;

        private ObservableCollection<cat_tipo_generales> _TipoPlanEstudiosDes;
        public ObservableCollection<cat_tipo_generales> TipoPlanEstudiosDes
        {
            get { return _TipoPlanEstudiosDes; }
            set
            {
                _TipoPlanEstudiosDes = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<cat_generales> _PlanEstudiosDes;
        public ObservableCollection<cat_generales> PlanEstudiosDes
        {
            get { return _PlanEstudiosDes; }
            set
            {
                _PlanEstudiosDes = value;
                RaisePropertyChanged();
            }
        }

        private cat_tipo_generales _Selected_TipoPlanEstudios;
        public cat_tipo_generales Selected_TipoPlanEstudios
        {
            get { return _Selected_TipoPlanEstudios; }
            set
            {
                _Selected_TipoPlanEstudios = value;
                RaisePropertyChanged();
            }
        }

        private cat_generales _Selected_PlanEstudios;
        public cat_generales Selected_PlanEstudios
        {
            get { return _Selected_PlanEstudios; }
            set
            {
                _Selected_PlanEstudios = value;
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
        private void BackNavgExecute()
        {
            FicLoSrvNavigation.FicMetNavigateBack();
        }
        //FicMetAddCommand
        private ICommand AddReticula;
        public ICommand FicMetAddCommand
        {
            get { return AddReticula = AddReticula ?? new FicVmDelegateCommand(AddReticulaExecute); }
        }
        private async void AddReticulaExecute()
        {
            Reticulas.IdTipoGenPlanEstudios = Selected_TipoPlanEstudios.IdTipoGeneral;
            Reticulas.IdGenPlanEstudios = Selected_PlanEstudios.IdGeneral;
            Reticulas.UsuarioMod = Reticulas.UsuarioReg;
            await FicLoSrvApp.FicMetInsertReticula(Reticulas);
            //validar entradas
            FicLoSrvNavigation.FicMetNavigateTo<FicVmCatReticulas>(null);
            await Application.Current.MainPage.DisplayAlert("Se Agrego Con Exito", "Para continuar da clic en ok", "OK");
            Reticulas = new eva_cat_reticulas();
        }


        public FicVmCatReticulasAdd(IFicSrvNavigation FicPaSrvNavigation, IFicSrvCatReticulas FicPaSrvApp, IFicSrvCatTipoGenerales TiposCatalogos, IFicSrvCatGenerales Catalogos)
        {
            FicLoSrvNavigation = FicPaSrvNavigation;
            FicLoSrvApp = FicPaSrvApp;
            FicLoCatTipoGenerales = TiposCatalogos;
            FicLoCatGenerales = Catalogos;
        }

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);
            _Reticulas = new eva_cat_reticulas();

            TipoPlanEstudiosDes = new ObservableCollection<cat_tipo_generales>();
            //OBTENER LOS REGISTROS DE LA TABLA
            var tempList = await FicLoCatTipoGenerales.FicMetGetListTipoGenerales();//CATALOGO DE TIPOS
            foreach (cat_tipo_generales ctg in tempList)
            {
                TipoPlanEstudiosDes.Add(ctg);
            }

            PlanEstudiosDes = new ObservableCollection<cat_generales>();
            var cat_asg = await FicLoCatGenerales.FicMetGetListGenerales();//CATALOGO DE GENERALES
            foreach (cat_generales cg in cat_asg)
            {
                PlanEstudiosDes.Add(cg);
                //if (temporal.IdGeneral == Reticulas.IdGenPlanEstudios)
                //{
                //    PlanEstudiosDes = temporal.DesGeneral;
                //}
            }

        }





//        StackLayout layout = new StackLayout()
//        {
//            VerticalOptions = LayoutOptions.Start,
//            HorizontalOptions = LayoutOptions.Start,
//            Padding = new Thickness(30)
//        };
//        List<String> countryNames = new List<String>();
//        countryNames.Add("Uganda");
//countryNames.Add("Ukraine");
//countryNames.Add("United Arab Emirates");
//countryNames.Add("United Kingdom");
//countryNames.Add("United States");

//SfComboBox comboBox = new SfComboBox();
//        comboBox.HeightRequest = 40;
//comboBox.DataSource = countryNames;
//comboBox.IsEditableMode = true;

//layout.Children.Add(comboBox); 
//Content = layout;

    }
}
