using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatReticulasAsignaturas
    {
        //RETICULAS-ASIGNATURAS
        Task<IList<eva_reticulas_asignaturas>> FicMetGetListReticulasAsignaturas();
        Task FicMetRemoveReticulasAsignaturas(eva_reticulas_asignaturas eva_reticulas_asignaturas);
        Task<eva_reticulas_asignaturas> FicMetGetMaxReticulasAsignaturasId();
        Task FicMetInsertReticulasAsignaturas(eva_reticulas_asignaturas eva_reticulas_asignaturas);
        Task FicMetUpdateReticulasAsignaturas(eva_reticulas_asignaturas eva_reticulas_asignaturas);

    }
}
