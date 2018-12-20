using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppEvaMovil.Models;


namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatEstatus
    {
        //ESTATUS
        Task<IList<cat_estatus>> FicMetGetListEstatus();
        Task FicMetRemoveEstatus(cat_estatus cat_estatus);
        //Task<cat_estatus> FicMetGetMaxEstatusId();
        Task FicMetInsertEstatus(cat_estatus cat_estatus);
        Task FicMetUpdateEstatus(cat_estatus cat_estatus);
        //void FicMetUpdateEstatus(cat_estatus cat_estatus);
    }
}
