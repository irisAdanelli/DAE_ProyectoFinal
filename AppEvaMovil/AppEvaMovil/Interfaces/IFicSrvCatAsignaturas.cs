using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using AppEvaMovil.Models;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatAsignaturas
    {
        //ASIGNATURAS
        Task<IList<eva_cat_asignaturas>> FicMetGetListAsignaturas();
        Task FicMetRemoveAsignaturas(eva_cat_asignaturas eva_cat_asignaturas);
        //Task<eva_cat_asignaturas> FicMetGetMaxAsignaturasId();
        Task FicMetInsertAsignaturas(eva_cat_asignaturas eva_cat_asignaturas);
        Task FicMetUpdateAsignatura(eva_cat_asignaturas eva_cat_asignaturas);
        //void FicMetUpdateCarrera(eva_cat_asignaturas eva_Cat_Asignaturas);
    }
}
