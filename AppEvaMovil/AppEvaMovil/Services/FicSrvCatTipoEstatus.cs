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
    public class FicSrvCatTipoEstatus : IFicSrvCatTipoEstatus
    {
        #region cat_tipo_estatus

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatTipoEstatus()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }



        public async Task<IList<cat_tipo_estatus>> FicMetGetListTipoEstatus()
        {
            var items = new List<cat_tipo_estatus>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCGE in FicLoBDContext.cat_tipo_estatus
                                   select new
                                   { FicCGE };
                   resultado.ToList().ForEach(x => items.Add(x.FicCGE));*/
                var resultado = from FicCGE in FicLoBDContext.cat_tipo_estatus
                                select new cat_tipo_estatus
                                {//FechaPlanEstudios
                                    IdTipoEstatus = FicCGE.IdTipoEstatus,
                                    DesTipo = FicCGE.DesTipo,
                                    FechaReg = FicCGE.FechaReg,
                                    FechaUltMod = FicCGE.FechaUltMod,
                                    UsuarioMod = FicCGE.UsuarioMod,
                                    UsuarioReg = FicCGE.UsuarioReg,
                                    Activo = FicCGE.Activo,
                                    Borrado = FicCGE.Borrado,
                                    //\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\


                                };
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }


        public async Task FicMetRemoveTipoEstatus(cat_tipo_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<cat_tipo_estatus> FicMetGetMaxTipoEstatusId()
        {
            var item = new cat_tipo_estatus();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.cat_tipo_estatus.Max(x => x.IdTipoEstatus);
                item.IdTipoEstatus = r;
            }
            return item;
        }

        public async Task FicMetInsertTipoEstatus(cat_tipo_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_tipo_estatus.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateTipoEstatus(cat_tipo_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_tipo_estatus.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<cat_tipo_estatus>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
