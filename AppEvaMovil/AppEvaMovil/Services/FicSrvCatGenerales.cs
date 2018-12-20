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
    public class FicSrvCatGenerales : IFicSrvCatGenerales
    {
        #region cat_generales

        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvCatGenerales()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }



        public async Task<IList<cat_generales>> FicMetGetListGenerales()
        {
            var items = new List<cat_generales>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCGE in FicLoBDContext.cat_generales
                                   select new
                                   { FicCGE };
                   resultado.ToList().ForEach(x => items.Add(x.FicCGE));*/
                var resultado = from FicCGE in FicLoBDContext.cat_generales
                                select new cat_generales
                                {//FechaPlanEstudios
                                    IdGeneral = FicCGE.IdGeneral,
                                    IdTipoGeneral = FicCGE.IdTipoGeneral,
                                    Clave = FicCGE.Clave,
                                    DesGeneral = FicCGE.DesGeneral,
                                    IdLlaveClasifica = FicCGE.IdLlaveClasifica,
                                    Referencia = FicCGE.Referencia,
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


        public async Task FicMetRemoveGenerales(cat_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<cat_generales> FicMetGetMaxGeneralesId()
        {
            var item = new cat_generales();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.cat_generales.Max(x => x.IdGeneral);
                item.IdGeneral = r;
            }
            return item;
        }

        public async Task FicMetInsertGenerales(cat_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_generales.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateGenerales(cat_generales item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.cat_generales.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<cat_generales>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
