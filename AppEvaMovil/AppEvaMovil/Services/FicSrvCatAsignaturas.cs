using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using AppEvaMovil.Interfaces;
using System.Threading.Tasks;
using AppEvaMovil.Models;
using AppEvaMovil.Helpers;
using AppEvaMovil.Data;
using Xamarin.Forms;
using AppEvaMovil.Interfaces.SQLite;

namespace AppEvaMovil.Services
{
    public class FicSrvCatAsignaturas : IFicSrvCatAsignaturas
    {
        #region eva_cat_asignaturas

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatAsignaturas()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }



        public async Task<IList<eva_cat_asignaturas>> FicMetGetListAsignaturas()
        {
            var items = new List<eva_cat_asignaturas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCAS in FicLoBDContext.eva_cat_asignaturas
                                   select new
                                   { FicCAS };
                   resultado.ToList().ForEach(x => items.Add(x.FicCAS));*/
                var resultado = from FicCAS in FicLoBDContext.eva_cat_asignaturas
                                select new eva_cat_asignaturas
                                {//FechaPlanEstudios
                                    IdAsignatura = FicCAS.IdAsignatura,
                                    ClaveAsignatura = FicCAS.ClaveAsignatura,
                                    DesAsignatura = FicCAS.DesAsignatura,
                                    Matricula = FicCAS.Matricula,
                                    Actual = FicCAS.Actual,
                                    FechaPlanEstudios = FicCAS.FechaPlanEstudios,
                                    NombreCorto = FicCAS.NombreCorto,
                                    Creditos = FicCAS.Creditos,
                                    FachaReg = FicCAS.FachaReg,
                                    FechaUltMod = FicCAS.FechaUltMod,
                                    UsuarioMod = FicCAS.UsuarioMod,
                                    UsuarioReg = FicCAS.UsuarioReg,
                                    Activo = FicCAS.Activo,
                                    Borrar = FicCAS.Borrar,
                                    //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
                                    IdGeneralAsignatura = FicCAS.IdGeneralAsignatura,
                                    IdTipoGeneralAsignatura = FicCAS.IdTipoGeneralAsignatura,
                                    IdTipoGeneralNivelEscolar = FicCAS.IdTipoGeneralNivelEscolar,
                                    IdGeneralNivelEscolar = FicCAS.IdGeneralNivelEscolar,

                                    // cat_generales = (
                                    //from FG in FicLoBDContext.cat_generales
                                    //where FG.IdGeneral == FicCAS.IdGeneralAsignatura
                                    //select new cat_generales
                                    //{
                                    //    IdGeneral = FG.IdGeneral,
                                    //    DesGeneral = FG.DesGeneral,
                                    //}).First(),
                                    // cat_tipo_generales = (
                                    //from FG2 in FicLoBDContext.cat_tipo_generales
                                    //where FG2.IdTipoGeneral == FicCAS.IdTipoGeneralAsignatura
                                    //select new cat_tipo_generales
                                    //{
                                    //    IdTipoGeneral = FG2.IdTipoGeneral,
                                    //    DesTipo = FG2.DesTipo,
                                    //}).First(),
                                };
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }


        public async Task FicMetRemoveAsignaturas(eva_cat_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<eva_cat_asignaturas> FicMetGetMaxAsignaturasId()
        {
            var item = new eva_cat_asignaturas();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.eva_cat_asignaturas.Max(x => x.IdAsignatura);
                item.IdAsignatura = r;
            }
            return item;
        }

        public async Task FicMetInsertAsignaturas(eva_cat_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_cat_asignaturas.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateAsignatura(eva_cat_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_cat_asignaturas.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<eva_cat_asignaturas>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
