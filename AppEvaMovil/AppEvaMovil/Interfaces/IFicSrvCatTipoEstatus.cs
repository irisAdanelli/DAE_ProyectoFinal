using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;


namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatTipoEstatus
    {
        //TIPO ESTATUS
        Task<IList<cat_tipo_estatus>> FicMetGetListTipoEstatus();
        Task FicMetRemoveTipoEstatus(cat_tipo_estatus cat_tipo_estatus);
        //Task<cat_tipo_estatus> FicMetGetMaxTipoEstatusId();
        Task FicMetInsertTipoEstatus(cat_tipo_estatus cat_tipo_estatus);
        Task FicMetUpdateTipoEstatus(cat_tipo_estatus cat_tipo_estatus);
        //void FicMetUpdateEstatus(cat_tipo_estatus cat_tipo_estatus);
    }
}
