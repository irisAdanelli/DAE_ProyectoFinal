using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;
using AppEvaMovil.Data;
using AppEvaMovil.Helpers;
using AppEvaMovil.Interfaces.SQLite;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AppEvaMovil.Interfaces;

namespace AppEvaMovil.Services
{
    public class FicSrvReticulasAsignaturas : IFicSrvCatReticulasAsignaturas
    {
        #region eva_reticulas_asignaturas
        private static readonly IFicAsyncLock ficMutex = new IFicAsyncLock();
        private FicDBContext FicLoBDContext;

        public FicSrvReticulasAsignaturas()
        {
            FicLoBDContext = new FicDBContext(DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath());
        }

        public async Task<IList<eva_reticulas_asignaturas>> FicMetGetListReticulasAsignaturas()
        {
            var items = new List<eva_reticulas_asignaturas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                /*   var resultado = from FicRAS in FicLoBDContext.eva_cat_asignaturas
                                   select new
                                   { FicRAS };
                   resultado.ToList().ForEach(x => items.Add(x.FicRAS));*/
                var resultado = from FicRAS in FicLoBDContext.eva_reticulas_asignaturas
                                select new eva_reticulas_asignaturas
                                {
                                    //campos

                                    IdReticulaAsignatura = FicRAS.IdReticulaAsignatura,
                                    IdReticula = FicRAS.IdReticula,
                                    IdAsignatura = FicRAS.IdAsignatura,
                                    Creditos = FicRAS.Creditos,
                                    HorasTeoria = FicRAS.HorasTeoria,
                                    HorasPractica = FicRAS.HorasPractica,
                                    Semestre = FicRAS.Semestre,
                                    OrderCertificado = FicRAS.OrderCertificado,
                                    CreditosPrerequisito = FicRAS.CreditosPrerequisito,
                                    IdTipoEstatus = FicRAS.IdTipoEstatus,
                                    IdEstatus = FicRAS.IdEstatus,
                                    Especialidad = FicRAS.Especialidad,
                                    FechaUltMod = FicRAS.FechaReg,
                                    UsuarioMod = FicRAS.UsuarioMod,
                                    Activo = FicRAS.Activo,
                                    Borrado = FicRAS.Borrado,

                                   // eva_cat_reticulas = (
                                   //from FG in FicLoBDContext.eva_cat_reticulas
                                   //where FG.IdReticula == FicRAS.IdReticula
                                   //select new eva_cat_reticulas
                                   //{
                                   //    IdReticula = FG.IdReticula,
                                   //    DesReticula = FG.DesReticula,
                                   //}).First(),
                                   // eva_cat_asignaturas = (
                                   //from FG2 in FicLoBDContext.eva_cat_asignaturas
                                   //where FG2.IdAsignatura == FicRAS.IdAsignatura
                                   //select new eva_cat_asignaturas
                                   //{
                                   //    IdAsignatura = FG2.IdAsignatura,
                                   //    DesAsignatura = FG2.DesAsignatura,
                                   //}).First(),
                                   // cat_tipo_estatus = (
                                   //from FG in FicLoBDContext.cat_tipo_estatus
                                   //where FG.IdTipoEstatus == FicRAS.IdTipoEstatus
                                   //select new cat_tipo_estatus
                                   //{
                                   //    IdTipoEstatus = FG.IdTipoEstatus,
                                   //    DesTipo = FG.DesTipo,
                                   //}).First(),
                                   // cat_estatus = (
                                   //from FG2 in FicLoBDContext.cat_estatus
                                   //where FG2.IdEstatus == FicRAS.IdEstatus
                                   //select new cat_estatus
                                   //{
                                   //    IdEstatus = FG2.IdEstatus,
                                   //    DesEstatus = FG2.DesEstatus,
                                   //}).First(),
                                };
                resultado.ToList().ForEach(x => items.Add(x));
            }
            return items;
        }


        public async Task FicMetRemoveReticulasAsignaturas(eva_reticulas_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task<eva_reticulas_asignaturas> FicMetGetMaxReticulasAsignaturasId()
        {
            var item = new eva_reticulas_asignaturas();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var r = FicLoBDContext.eva_reticulas_asignaturas.Max(x => x.IdReticulaAsignatura);
                item.IdReticulaAsignatura = r;
            }
            return item;
        }

        public async Task FicMetInsertReticulasAsignaturas(eva_reticulas_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_reticulas_asignaturas.Add(item);
                FicLoBDContext.SaveChanges();
            }
        }

        public async Task FicMetUpdateReticulasAsignaturas(eva_reticulas_asignaturas item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                FicLoBDContext.eva_reticulas_asignaturas.Update(item);
                FicLoBDContext.SaveChanges();
                FicLoBDContext.Entry<eva_reticulas_asignaturas>(item).State = EntityState.Detached;
            }
        }


        #endregion
    }
}
