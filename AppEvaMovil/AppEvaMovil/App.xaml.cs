using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEvaMovil.ViewModels.Base;
using AppEvaMovil.Views.Reticulas;
using AppEvaMovil.Views;
using AppEvaMovil.Views.Navegacion;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppEvaMovil
{
    public partial class App : Application
    {
        private static FicViewModelLocator ficVmLocator;
        // FIC: Metodo
        public static FicViewModelLocator FicMetLocator
        {
            get { return ficVmLocator = ficVmLocator ?? new FicViewModelLocator(); }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FicMenuPrincipal());
             //MainPage = new Views.Navegacion.FicMasterPage(); 
            //MainPage = new NavigationPage(new Views.Reticulas.FicViCatReticulasList(null));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
