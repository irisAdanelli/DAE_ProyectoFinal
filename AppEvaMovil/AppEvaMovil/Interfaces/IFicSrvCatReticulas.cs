using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatReticulas
    {
        //RETICULAS
        Task<IList<eva_cat_reticulas>> FicMetGetListReticulas();
        Task FicMetRemoveReticula(eva_cat_reticulas eva_cat_reticulas);
        Task<eva_cat_reticulas> FicMetGetMaxReticulasId();
        Task FicMetInsertReticula(eva_cat_reticulas eva_cat_reticulas);
        Task FicMetUpdateReticula(eva_cat_reticulas eva_cat_reticulas);
    }
}
