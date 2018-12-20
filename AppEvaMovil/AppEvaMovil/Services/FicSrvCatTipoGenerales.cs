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
    public class FicSrvCatTipoGenerales : IFicSrvCatTipoGenerales
    {
        #region cat_tipo_generales

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatTipoGenerales()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }



        public async Task<IList<cat_tipo_generales>> FicMetGetListTipoGenerales()
        {
            var items = new List<cat_tipo_generales>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCGE in FicLoBDContext.cat_generales
                                   select new
                                   { FicCGE };
                   resultado.ToList().ForEach(x => items.Add(x.FicCGE));*/
                var resultado = from FicCGE in FicLoBDContext.cat_tipo_generales
                                select new cat_tipo_generales
                                {//FechaPlanEstudios
                                    IdTipoGeneral = FicCGE.IdTipoGeneral,
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


        public async Task FicMetRemoveTipoGenerales(cat_tipo_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<cat_tipo_generales> FicMetGetMaxTipoGeneralesId()
        {
            var item = new cat_tipo_generales();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.cat_generales.Max(x => x.IdTipoGeneral);
                item.IdTipoGeneral = r;
            }
            return item;
        }

        public async Task FicMetInsertTipoGenerales(cat_tipo_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_tipo_generales.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateTipoGenerales(cat_tipo_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_tipo_generales.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<cat_tipo_generales>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
