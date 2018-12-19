using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AppEvaMovil.ViewModels.Reticulas;
using AppEvaMovil.Services;
using AppEvaMovil.Services.Navigation;
using AppEvaMovil.Interfaces.Navigation;
using AppEvaMovil.Interfaces;
using AppEvaMovil.ViewModels.AsignaturaAnterior;
using AppEvaMovil.ViewModels.Asignaturas;
using AppEvaMovil.ViewModels.ReticulasAsignaturas;

namespace AppEvaMovil.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicContainer;

        public FicViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            // Registrar cada uno de los ViewModels creados en el siguiente formato
             builder.RegisterType<FicVmCatReticulasAdd>();
             builder.RegisterType<FicVmCatReticulas>();
             builder.RegisterType<FicVmCatReticulasDetail>();
             builder.RegisterType<FicVmCatReticulasUpdate>();
            // FicVmCatAsignaturaAnterior
            builder.RegisterType<FicVmCatAsignaturaAnteriorAdd>();
            builder.RegisterType<FicVmCatAsignaturaAnterior>();
            builder.RegisterType<FicVmCatAsignaturaAnteriorDetail>();
            builder.RegisterType<FicVmCatAsignaturaAnteriorUpdate>();
            // FicVmCatAsignaturas
            builder.RegisterType<FicVmCatAsignaturasAdd>();
            builder.RegisterType<FicVmCatAsignaturas>();
            builder.RegisterType<FicVmCatAsignaturasDetail>();
            builder.RegisterType<FicVmCatAsignaturasUpdate>();
            //FicVmReticulasAsignaturas
            builder.RegisterType<FicVmCatReticulasAsignaturasAdd>();
            builder.RegisterType<FicVmCatReticulasAsignaturas>();
            builder.RegisterType<FicVmCatReticulasAsignaturasDetail>();
            builder.RegisterType<FicVmCatReticulasAsignaturasUpdate>();

            builder.RegisterType<FicVmMenuPrincipal>();



            // Servicios
            builder.RegisterType<FicSrvNavigation>().As<IFicSrvNavigation>().SingleInstance();
            //builder.RegisterType<FicSrvApp>().As<IFicSrvApp>();
            // builder.RegisterType<FicSrvImportarWebApi>().As<IFicSrvImportarWebApi>();
            // builder.RegisterType<FicSrvExportarWebApi>().As<IFicSrvExportarWebApi>();
            builder.RegisterType<FicSrvCatReticulas>().As<IFicSrvCatReticulas>();
            builder.RegisterType<FicSrvReticulasAsignaturas>().As<IFicSrvCatReticulasAsignaturas>();
            //---builder.RegisterType<FicSrvReticulasAsignaturas>().As<IFicSrvCatReticulasAsignaturas>();
            builder.RegisterType<FicSrvAsignaturaAnterior>().As<IFicSrvAsignaturaAnterior>();
            builder.RegisterType<FicSrvCatAsignaturas>().As<IFicSrvCatAsignaturas>();


            if (FicContainer != null)
            {
                FicContainer.Dispose();
            }

            FicContainer = builder.Build();
        }

        // Crear los metodos que se mandan llamar desde el archivo xaml.cs de cada vista para
        // ligar el ViewModel con la vista
        //public FicVmCatEdificiosList FicVmCatEdificiosList
        //{
        //    get { return FicContainer.Resolve<FicVmCatEdificiosList>(); }
        //}
        //Reticulas
        public FicVmCatReticulas FicVmCatReticulas
        {
            get { return FicContainer.Resolve<FicVmCatReticulas>(); }
        }
        public FicVmCatReticulasDetail FicVmCatReticulasDetail
        {
            get { return FicContainer.Resolve<FicVmCatReticulasDetail>(); }
        }
        public FicVmCatReticulasUpdate FicVmCatReticulasUpdate
        {
            get { return FicContainer.Resolve<FicVmCatReticulasUpdate>(); }
        }
        public FicVmCatReticulasAdd FicVmCatReticulasAdd
        {
            get { return FicContainer.Resolve<FicVmCatReticulasAdd>(); }
        }
        //Asignaturas
        public FicVmCatAsignaturas FicVmCatAsignaturas
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturas>(); }
        }
        public FicVmCatAsignaturasDetail FicVmCatAsignaturasDetail
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturasDetail>(); }
        }
        public FicVmCatAsignaturasUpdate FicVmCatAsignaturasUpdate
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturasUpdate>(); }
        }
        public FicVmCatAsignaturasAdd FicVmCatAsignaturasAdd
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturasAdd>(); }
        }
        //Reticulas Asignaturas
        public FicVmCatReticulasAsignaturas FicVmCatReticulasAsignaturas
        {
            get { return FicContainer.Resolve<FicVmCatReticulasAsignaturas>(); }
        }
        public FicVmCatReticulasAsignaturasDetail FicVmCatReticulasAsignaturasDetail
        {
            get { return FicContainer.Resolve<FicVmCatReticulasAsignaturasDetail>(); }
        }
        public FicVmCatReticulasAsignaturasUpdate FicVmCatReticulasAsignaturasUpdate
        {
            get { return FicContainer.Resolve<FicVmCatReticulasAsignaturasUpdate>(); }
        }
        public FicVmCatReticulasAsignaturasAdd FicVmCatReticulasAsignaturasAdd
        {
            get { return FicContainer.Resolve<FicVmCatReticulasAsignaturasAdd>(); }
        }
        //Asignatura Anterior
        public FicVmCatAsignaturaAnterior FicVmCatAsignaturaAnterior
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturaAnterior>(); }
        }
        public FicVmCatAsignaturaAnteriorDetail FicVmCatAsignaturaAnteriorDetail
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturaAnteriorDetail>(); }
        }
        public FicVmCatAsignaturaAnteriorUpdate FicVmCatAsignaturaAnteriorUpdate
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturaAnteriorUpdate>(); }
        }
        public FicVmCatAsignaturaAnteriorAdd FicVmCatAsignaturaAnteriorAdd
        {
            get { return FicContainer.Resolve<FicVmCatAsignaturaAnteriorAdd>(); }
        }
        public FicVmMenuPrincipal FicVmMenuPrincipal
        {
            get { return FicContainer.Resolve<FicVmMenuPrincipal>(); }
        }





        //public FicVmImportarWebApi FicVmImportarWebApi
        //{
        //    get { return FicContainer.Resolve<FicVmImportarWebApi>(); }
        //}

    }
}
