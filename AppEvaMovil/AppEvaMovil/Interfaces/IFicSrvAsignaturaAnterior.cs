using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using AppEvaMovil.Models;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvAsignaturaAnterior
    {
        //ASIGNATURA-ANTERIOR
        Task<IList<eva_reticula_asignatura_ant>> FicMetGetListAsignaturaAnterior();
        Task FicMetRemoveAsignaturaAnterior(eva_reticula_asignatura_ant eva_reticula_asignatura_ant);
        //Task<eva_reticula_asignatura_ant> FicMetGetMaxAsignaturaAnteriorId();
        Task FicMetInsertAsignaturaAnterior(eva_reticula_asignatura_ant eva_reticula_asignatura_ant);
        Task FicMetUpdateAsignaturaAnterior(eva_reticula_asignatura_ant eva_reticula_asignatura_ant);

    }
}
