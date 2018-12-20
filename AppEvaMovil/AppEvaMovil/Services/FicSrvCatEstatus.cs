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
    public class FicSrvCatEstatus : IFicSrvCatEstatus
    {
        #region cat_estatus

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatEstatus()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }



        public async Task<IList<cat_estatus>> FicMetGetListEstatus()
        {
            var items = new List<cat_estatus>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCGE in FicLoBDContext.cat_estatus
                                   select new
                                   { FicCGE };
                   resultado.ToList().ForEach(x => items.Add(x.FicCGE));*/
                var resultado = from FicCGE in FicLoBDContext.cat_estatus
                                select new cat_estatus
                                {//FechaPlanEstudios
                                    IdEstatus = FicCGE.IdEstatus,
                                    IdTipoEstatus = FicCGE.IdTipoEstatus,
                                    Clave = FicCGE.Clave,
                                    DesEstatus = FicCGE.DesEstatus,
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


        public async Task FicMetRemoveEstatus(cat_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<cat_estatus> FicMetGetMaxEstatusId()
        {
            var item = new cat_estatus();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.cat_estatus.Max(x => x.IdEstatus);
                item.IdEstatus = r;
            }
            return item;
        }

        public async Task FicMetInsertEstatus(cat_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_estatus.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateEstatus(cat_estatus item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_estatus.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<cat_estatus>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
