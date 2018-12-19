using System;
using System.Collections.Generic;
using System.Text;
using AppEvaMovil.Data;
using AppEvaMovil.Helpers;
using AppEvaMovil.Interfaces.SQLite;
using Xamarin.Forms;
using System.Linq;
using AppEvaMovil.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppEvaMovil.Models;
using System.Threading.Tasks;

namespace AppEvaMovil.Services
{
    public class FicSrvCatReticulas : IFicSrvCatReticulas
    {
        #region eva_cat_reticulas
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatReticulas()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }

        public async Task<IList<eva_cat_reticulas>> FicMetGetListReticulas()
        {
            var items = new List<eva_cat_reticulas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicRet in FicLoBDContext.eva_cat_reticulas
                                   select new
                                   { FicRet };
                   resultado.ToList().ForEach(x => items.Add(x.FicRet));*/
                 var resultado = from FicRet in FicLoBDContext.eva_cat_reticulas
                                select new eva_cat_reticulas
                                {
                                    IdReticula = FicRet.IdReticula,
                                    DesReticula = FicRet.DesReticula,
                                    Actual = FicRet.Actual,
                                    FechaIni = FicRet.FechaIni,
                                    FechaFin = FicRet.FechaFin,
                                    Clave = FicRet.Clave,
                                    Activo = FicRet.Activo,
                                    Borrado = FicRet.Borrado,
                                    FechaReg = FicRet.FechaReg,
                                    FechaUltMod = FicRet.FechaUltMod,
                                    UsuarioMod = FicRet.UsuarioMod,
                                    UsuarioReg = FicRet.UsuarioReg,
                                    IdGenPlanEstudios = FicRet.IdGenPlanEstudios,
                                    IdTipoGenPlanEstudios = FicRet.IdTipoGenPlanEstudios
                              
                                };
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }


        public async Task FicMetRemoveReticula(eva_cat_reticulas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<eva_cat_reticulas> FicMetGetMaxReticulasId()
        {
            var item = new eva_cat_reticulas();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.eva_cat_reticulas.Max(x => x.IdReticula);
                item.IdReticula = r;
            }
            return item;
        }

        public async Task FicMetInsertReticula(eva_cat_reticulas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_cat_reticulas.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateReticula(eva_cat_reticulas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_cat_reticulas.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<eva_cat_reticulas>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
