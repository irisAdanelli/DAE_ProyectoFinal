using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using AppEvaMovil.Models;
using Xamarin.Forms;
using AppEvaMovil.Services;
using AppEvaMovil.Data;
using AppEvaMovil.Interfaces.SQLite;


namespace AppEvaMovil.Data
{
    //class FicDBContext
    //{}


        public class FicDBContext : DbContext
        {
            private readonly string FicDataBasePath;

            public FicDBContext(string FicPaDataBasePath)
            {
                FicDataBasePath = FicPaDataBasePath;
                FicMetCrearDB();
            }

        public FicDBContext(DbContextOptions<FicDBContext> ficOptions) : base(ficOptions)
        {

        }

        public async void FicMetCrearDB()
            {
                try
                {
                    //FIC: SE crea la base de datos en base al esquema
                    await Database.EnsureCreatedAsync();
                }
                catch (Exception err)
                {
                    await new Page().DisplayAlert("ALERTA", err.Message.ToString(), "OK");
                }
            }//ESTE METODO CREA LA BASE DE DATOS

            protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionBuilder)
            {
                try
                {
                    FicPaOptionBuilder.UseSqlite($"Filename={FicDataBasePath}");
                    FicPaOptionBuilder.EnableSensitiveDataLogging();
                }
                catch (Exception err)
                {
                    await new Page().DisplayAlert("ALERTA", err.Message.ToString(), "OK");
                }
            }//CONFIGURACION DE LA CONECXION

            //GESTION DE INVENTARIOS
            public DbSet<eva_cat_reticulas> Eva_cat_reticulas { get; set; }
            public DbSet<eva_cat_asignaturas> Eva_cat_asignaturas { get; set; }
            public DbSet<cat_estatus> Cat_estatus { get; set; }
            public DbSet<cat_tipo_estatus> Cat_tipo_estatus { get; set; }

            //protected async override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    try
            //    {
            //        //EVA_CAT_reticulas
            //        modelBuilder.Entity<eva_cat_reticulas>().HasKey(pk => new { pk.IdEdificio });

            //        //EVA_CAT_asignaturas
            //        modelBuilder.Entity<eva_cat_asignaturas>().HasKey(pk => new { pk.IdEspacio });
            //        modelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.eva_cat_reticulas).WithMany().HasForeignKey(fk => new { fk.IdEspacio });
            //        modelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.cat_estatus).WithMany().HasForeignKey(fk => new { fk.IdTipoEstatus, fk.IdEstatus });

            //        //CAT_ESTATUS
            //        modelBuilder.Entity<cat_estatus>().HasKey(pk => new { pk.IdEstatus, pk.IdTipoEstatus });
            //        modelBuilder.Entity<cat_estatus>().HasOne(fk => fk.cat_tipo_estatus).WithMany().HasForeignKey(fk => new { fk.IdTipoEstatus });


            //        //CAT_TIPO_ESTATUS
            //        modelBuilder.Entity<cat_tipo_estatus>().HasKey(pk => new { pk.IdTipoEstatus });
            //    }
            //    catch (Exception e)
            //    {
            //        await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            //    }
            //}//AL CREAR EL MODELO




            

            protected async override void OnModelCreating(ModelBuilder FicPaModelBuilder)
            {
                try
                {

                //public DbSet<eva_reticulas_asignaturas> eva_reticulas_asignaturas { get; set; }
                #region eva_reticulas_asignaturas  

                //FicPaModelBuilder.Entity<eva_cat_carreras>().HasKey(c => new { c.IdTipoGenGradoEscolar, c.IdGenGradoEscolar, c.IdTipoGenModalidad, c.IdGenModalidad });
                // FicPaModelBuilder.Entity<eva_carreras_reticulas>().HasKey(c => new { c.IdCarrera, c.IdReticula });


                //Correccion de Asignacion de las PK y FK de las clases modelo
                FicPaModelBuilder.Entity<eva_cat_carreras_consulta>().HasKey(pk => new { pk.IdConsulta });
                FicPaModelBuilder.Entity<cat_tipo_estatus>().HasKey(pk => new { pk.IdTipoEstatus });
                FicPaModelBuilder.Entity<cat_tipo_generales>().HasKey(pk => new { pk.IdTipoGeneral });
                FicPaModelBuilder.Entity<eva_reticulas_asignaturas>().HasKey(c => new { c.IdReticulaAsignatura });
                FicPaModelBuilder.Entity<cat_estatus>().HasKey(pk => new { pk.IdEstatus });
                FicPaModelBuilder.Entity<eva_cat_reticulas>().HasKey(pk => new { pk.IdReticula });
                FicPaModelBuilder.Entity<eva_cat_asignaturas>().HasKey(pk => new { pk.IdAsignatura });
                FicPaModelBuilder.Entity<cat_generales>().HasKey(pk => new { pk.IdGeneral });
                FicPaModelBuilder.Entity<eva_reticula_asignatura_ant>().HasKey(pk => new { pk.IdAsignaturaAnterior });


                FicPaModelBuilder.Entity<cat_estatus>().HasOne(fk => fk.cat_tipo_estatus).WithMany().HasForeignKey(fk => new { fk.IdTipoEstatus });
                FicPaModelBuilder.Entity<eva_reticulas_asignaturas>().HasOne(fk => fk.cat_tipo_estatus).WithMany().HasForeignKey(fk => new { fk.IdTipoEstatus });
                FicPaModelBuilder.Entity<eva_reticulas_asignaturas>().HasOne(fk => fk.eva_cat_reticulas).WithMany().HasForeignKey(fk => new { fk.IdReticula });
                FicPaModelBuilder.Entity<eva_reticulas_asignaturas>().HasOne(fk => fk.eva_cat_asignaturas).WithMany().HasForeignKey(fk => new { fk.IdAsignatura });
                FicPaModelBuilder.Entity<eva_reticulas_asignaturas>().HasOne(fk => fk.cat_estatus).WithMany().HasForeignKey(fk => new { fk.IdEstatus });
                FicPaModelBuilder.Entity<eva_cat_reticulas>().HasOne(fk => fk.cat_tipo_generales).WithMany().HasForeignKey(fk => new { fk.IdTipoGenPlanEstudios });
                FicPaModelBuilder.Entity<eva_cat_reticulas>().HasOne(fk => fk.cat_generales).WithMany().HasForeignKey(fk => new { fk.IdGenPlanEstudios });
                FicPaModelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.cat_tipo_generales).WithMany().HasForeignKey(fk => new { fk.IdTipoGeneralAsignatura });
                FicPaModelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.cat_generales).WithMany().HasForeignKey(fk => new { fk.IdGeneralAsignatura });
                FicPaModelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.cat_tipo_generales).WithMany().HasForeignKey(fk => new { fk.IdTipoGeneralNivelEscolar });
                FicPaModelBuilder.Entity<eva_cat_asignaturas>().HasOne(fk => fk.cat_generales).WithMany().HasForeignKey(fk => new { fk.IdGeneralNivelEscolar });
                FicPaModelBuilder.Entity<cat_generales>().HasOne(fk => fk.cat_tipo_generales).WithMany().HasForeignKey(fk => new { fk.IdTipoGeneral });
                FicPaModelBuilder.Entity<eva_reticula_asignatura_ant>().HasOne(fk => fk.eva_cat_asignaturas).WithMany().HasForeignKey(fk => new { fk.IdAsignatura });
                FicPaModelBuilder.Entity<eva_reticula_asignatura_ant>().HasOne(fk => fk.eva_cat_reticulas).WithMany().HasForeignKey(fk => new { fk.IdReticula });
                FicPaModelBuilder.Entity<eva_reticula_asignatura_ant>().HasOne(fk => fk.eva_cat_asignaturas).WithMany().HasForeignKey(fk => new { fk.IdAsignaturaAnterior });
                #endregion




                //FicPaModelBuilder.Ignore<eva_cat_carreras_consulta>();

                //    #region eva_cat_carreras
                //    FicPaModelBuilder.Entity<eva_cat_carreras>()
                //    .HasKey(c => new { c.IdCarrera });
                    /*
                    modelBuilder.Entity<eva_cat_carreras>()
                     .HasOne(s => s.rh_cat_areas_deptos).
                     WithMany().HasForeignKey(s => new { s.IdAreaDepto });
                     modelBuilder.Entity<eva_cat_carreras>()
                    .HasOne(s => s.cat_tipos_generales).
                   WithMany().HasForeignKey(s => new { s.IdTipoGenGradoEscolar });

                    * 
                   modelBuilder.Entity<eva_cat_carreras>()
                  .HasOne(s => s.cat_generales).
                  WithMany().HasForeignKey(s => new { s.IdGenGradoEscolar });
                   modelBuilder.Entity<eva_cat_carreras>()
                  .HasOne(s => s.cat_tipos_generales_modalidad).
                  WithMany().HasForeignKey(s => new { s.IdTipoGenModalidad });
                   modelBuilder.Entity<eva_cat_carreras>()
                  .HasOne(s => s.cat_generales_modalidad).
                  WithMany().HasForeignKey(s => new { s.IdGenModalidad }); */
                    //#endregion

                    //#region eva_cat_especialidades
                    //FicPaModelBuilder.Entity<eva_cat_especialidades>()
                    //  .HasKey(c => new { c.IdEspecialidad });
                    //#endregion

                    //#region eva_carreras_especialidades

                    //FicPaModelBuilder.Entity<eva_carreras_especialidades>()
                    // .HasKey(c => new { c.IdCarreraEspecilidad });
                    //FicPaModelBuilder.Entity<eva_carreras_especialidades>()
                    //.HasOne(s => s.eva_cat_carreras).
                    //WithMany().HasForeignKey(s => new { s.IdCarrera });
                    //FicPaModelBuilder.Entity<eva_carreras_especialidades>()
                    //.HasOne(s => s.eva_cat_especialidades).
                    //WithMany().HasForeignKey(s => new { s.IdEspecialidad }).OnDelete(DeleteBehavior.Restrict);

                    //#endregion


                    //#region cat_generales
                    //FicPaModelBuilder.Entity<cat_generales>()
                    //.HasKey(c => new { c.IdGeneral });
                    //#endregion


                    //#region eva_cat_reticulas
                    //FicPaModelBuilder.Entity<eva_cat_reticulas>()
                    //.HasKey(c => new { c.IdReticula });

                    //#endregion

                    //#region eva_carreras_reticulas
                    //FicPaModelBuilder.Entity<eva_carreras_reticulas>()
                    //.HasKey(c => new { c.IdCarreraRiticula });

                    //#endregion

                    //region

                }


                catch (Exception e)
                {
                    await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                    //await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                }

            }//abri la movil bien de antes
             //y esta es la movil, de las dos
             //Aun esta en proceso de merge la movil de las dos...

            //public DbSet<eva_cat_carreras> eva_cat_carreras { get; set; }
            //public DbSet<eva_cat_especialidades> eva_cat_especialidades { get; set; }
            //public DbSet<eva_carreras_especialidades> eva_carreras_especialidades { get; set; }
            public DbSet<cat_tipo_generales> cat_tipo_generales { get; set; }
            public DbSet<cat_generales> cat_generales { get; set; }
            public DbSet<eva_cat_carreras_consulta> eva_cat_carreras_consulta { get; set; }

            public DbSet<eva_cat_reticulas> eva_cat_reticulas { get; set; }

            //public DbSet<eva_carreras_reticulas> eva_carreras_reticulas { get; set; }

            public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
            public DbSet<eva_reticulas_asignaturas> eva_reticulas_asignaturas { get; set; }
            public DbSet<cat_estatus> cat_estatus { get; set; }
            public DbSet<cat_tipo_estatus> cat_tipo_estatus { get; set; }
            public DbSet<eva_reticula_asignatura_ant> eva_reticula_asignatura_ant { get; set; }




        }



    
}
