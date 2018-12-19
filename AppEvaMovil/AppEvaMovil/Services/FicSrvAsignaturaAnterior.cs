using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;
using AppEvaMovil.Data;
using AppEvaMovil.Helpers;
using AppEvaMovil.Interfaces.SQLite;
using AppEvaMovil.Interfaces;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppEvaMovil.Services
{
    public class FicSrvAsignaturaAnterior : IFicSrvAsignaturaAnterior
    {
        #region eva_reticula_asignatura_ant
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;


        public FicSrvAsignaturaAnterior()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }

        public async Task<IList<eva_reticula_asignatura_ant>> FicMetGetListAsignaturaAnterior()
        {
            var items = new List<eva_reticula_asignatura_ant>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicCAANT in FicLoBDContext.eva_cat_asignaturas
                                   select new
                                   { FicCAANT };
                   resultado.ToList().ForEach(x => items.Add(x.FicCAANT));*/
                var resultado = from FicCAANT in FicLoBDContext.eva_reticula_asignatura_ant
                                select new eva_reticula_asignatura_ant
                                {
                                    IdAnterior = FicCAANT.IdAnterior,

                                    IdAsignaturaAnterior = FicCAANT.IdAsignaturaAnterior,
                                    IdReticula = FicCAANT.IdReticula,
                                    IdAsignatura = FicCAANT.IdAsignatura,

                                    Activo = FicCAANT.Activo,
                                    Borrado = FicCAANT.Borrado,
                                    FechaReg = FicCAANT.FechaReg,
                                    FechaUltMod = FicCAANT.FechaUltMod,
                                    UsuarioMod = FicCAANT.UsuarioMod,
                                    UsuarioReg = FicCAANT.UsuarioReg,
                                    eva_cat_reticulas = (
                                   from FG in FicLoBDContext.eva_cat_reticulas
                                   where FG.IdReticula == FicCAANT.IdReticula
                                   select new eva_cat_reticulas
                                   {
                                       IdReticula = FG.IdReticula,
                                       DesReticula = FG.DesReticula,
                                   }).First(),
                                    eva_cat_asignaturas = (
                                   from FG2 in FicLoBDContext.eva_cat_asignaturas
                                   where FG2.IdAsignatura == FicCAANT.IdAsignatura
                                   select new eva_cat_asignaturas
                                   {
                                       IdAsignatura = FG2.IdAsignatura,
                                       DesAsignatura = FG2.DesAsignatura,
                                   }).First(),
                                    eva_cat_asignatura_anterior = (
                                   from FG2 in FicLoBDContext.eva_cat_asignaturas
                                   where FG2.IdAsignatura == FicCAANT.IdAsignaturaAnterior
                                   select new eva_cat_asignaturas
                                   {
                                       IdAsignatura = FG2.IdAsignatura,
                                       DesAsignatura = FG2.DesAsignatura,
                                   }).First(),
                                };
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }


        public async Task FicMetRemoveAsignaturaAnterior(eva_reticula_asignatura_ant item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }
        public async Task<eva_reticula_asignatura_ant> FicMetGetMaxAsignaturaAnteriorId()
        {
            var item = new eva_reticula_asignatura_ant();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.eva_reticula_asignatura_ant.Max(x => x.IdAnterior);
                item.IdAnterior = r;
            }
            return item;
        }

        public async Task FicMetInsertAsignaturaAnterior(eva_reticula_asignatura_ant item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_reticula_asignatura_ant.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateAsignaturaAnterior(eva_reticula_asignatura_ant item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_reticula_asignatura_ant.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<eva_reticula_asignatura_ant>(item).State = EntityState.Detached;
            }
        }


        #endregion

    }
}
