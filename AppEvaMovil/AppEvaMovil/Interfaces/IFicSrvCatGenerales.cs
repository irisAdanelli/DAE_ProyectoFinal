using System;
using System.Collections.Generic;
using System.Text;
using AppEvaMovil.Models;
using System.Threading.Tasks;

namespace AppEvaMovil.Interfaces
{
    public interface IFicSrvCatGenerales
    {
        //GENERALES
        Task<IList<cat_generales>> FicMetGetListGenerales();
        Task FicMetRemoveGenerales(cat_generales cat_generales);
        //Task<cat_generales> FicMetGetMaxGeneralesId();
        Task FicMetInsertGenerales(cat_generales cat_generales);
        Task FicMetUpdateGenerales(cat_generales cat_generales);
        //void FicMetUpdateGenerales(cat_generales cat_generales);
    }
}
