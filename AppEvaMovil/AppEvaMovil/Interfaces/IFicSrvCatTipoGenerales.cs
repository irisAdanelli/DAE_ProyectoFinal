using System;
using System.Collections.Generic;
using System.Text;
using AppEvaMovil.Models;
using System.Threading.Tasks;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatTipoGenerales
    {
        //TIPO GENERALES
        Task<IList<cat_tipo_generales>> FicMetGetListTipoGenerales();
        Task FicMetRemoveTipoGenerales(cat_tipo_generales cat_tipo_generales);
        //Task<cat_tipo_generales> FicMetGetMaxTipoGeneralesId();
        Task FicMetInsertTipoGenerales(cat_tipo_generales cat_tipo_generales);
        Task FicMetUpdateTipoGenerales(cat_tipo_generales cat_tipo_generales);
        //void FicMetUpdateGenerales(cat_tipo_generales cat_tipo_generales);
    }
}
